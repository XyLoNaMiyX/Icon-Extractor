using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

public enum IconSize : uint { Large = 0x0, Small = 0x1 }

public static class IconUtils
{
	#region Consts, structs and extern

	const int Resolution = 72;

	const uint SHGFI_ICON = 0x100;

	[StructLayout(LayoutKind.Sequential)]
	struct SHFILEINFO
	{
		public IntPtr hIcon;
		public IntPtr iIcon;
		public uint dwAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	};

	[DllImport("shell32.dll")]
	static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
	                                   ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

	#endregion

	#region Public static methods

	/// <summary>
	/// Saves an icon to the desired location
	/// </summary>
	/// <param name="icon">The icon to be saved</param>
	/// <param name="filename">The location where it will be saved</param>
	public static void SaveIcon(Icon icon, string filename)
	{
		ConvertToIcon(icon.ToBitmap(), new FileStream(filename, FileMode.OpenOrCreate), icon.Size.Width, icon.Size.Height); }

	/// <summary>
	/// Saves an image as an icon to the desired location
	/// </summary>
	/// <param name="image">The image that will be saved as icon</param>
	/// <param name="filename">The location where it will be saved</param>
	/// <param name="width">The icon width</param>
	/// <param name="height">The icon height</param>
	public static void SaveImageAsIcon(Image image, string filename, int width, int height)
	{
		SaveIcon(IconFromImage(image, width, height), filename); }

	/// <summary>
	/// Gets an icon from the given image
	/// </summary>
	/// <param name="image">The image</param>
	/// <param name="width">The icon width</param>
	/// <param name="height">The icon height</param>
	/// <returns>The generated icon</returns>
	public static Icon IconFromImage(Image image, int width, int height)
	{
		var bitmap = new Bitmap(image.GetThumbnailImage(width, height, null, IntPtr.Zero));
		bitmap.SetResolution(Resolution, Resolution);
		return Icon.FromHandle(bitmap.GetHicon());
	}

	/// <summary>
	/// Extracts the icon from the desired file.
	/// Note that this will extract the shown icon, not the icons contained in the executable.
	/// </summary>
	/// <param name="filename">The file</param>
	/// <param name="size">The icon size (large or small)</param>
	/// <returns>The extracted icon</returns>
	public static Icon ExtractIcon(string filename, IconSize size = IconSize.Large)
	{
		IntPtr hIcon;
		var shinfo = new SHFILEINFO();

		hIcon = SHGetFileInfo(filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | (uint)size);

		return Icon.FromHandle(shinfo.hIcon);
	}

	#endregion

	#region Private static methods

	static void ConvertToIcon(Image bitmap, Stream output, int width, int height)
	{
		using (var memoryStream = new MemoryStream())
		{
			bitmap.Save(memoryStream, ImageFormat.Png);
			var iconWriter = new BinaryWriter(output);
			
			if (width >= 256)
				width = 0;
			
			if (height >= 256)
				height = 0;

			// 0-1 reserved, 0
            iconWriter.Write((byte)0);
			iconWriter.Write((byte)0);

			// 2-3 image type, 1 = icon, 2 = cursor
            iconWriter.Write((short)1);

			// 4-5 number of images
            iconWriter.Write((short)1);

			// 6 image width
            iconWriter.Write((byte)width);
			// 7 image height
            iconWriter.Write((byte)height);

			// 8 number of colors
			iconWriter.Write((byte)0); // 0 = no color palette

			// 9 reserved
			iconWriter.Write((byte)0);

			// A-B color planes
			iconWriter.Write((short)0);

			// C-D bits per pixel
			iconWriter.Write((short)32); // TODO a setting for this

			// E-F size of image data
            iconWriter.Write((int)memoryStream.Length);

			// 10-11-12-13 offset of image data
            iconWriter.Write((int)(6 + 16));

			// write image data
			// png data must contain the whole png data file
            iconWriter.Write(memoryStream.ToArray());

            iconWriter.Flush();
        }
    }
	
	#endregion
	
}