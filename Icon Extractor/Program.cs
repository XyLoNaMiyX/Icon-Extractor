
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Icon_Extractor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	sealed class Program
	{
	    // defines for commandline output
	    [DllImport("kernel32.dll")]
	    static extern bool AttachConsole(int dwProcessId);
	    const int ATTACH_PARENT_PROCESS = -1;

		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length == 0) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			} else
			{
		        AttachConsole(ATTACH_PARENT_PROCESS);
		        
				var size = (IconSize)Settings.Default.Size;
				int imgsize = Settings.Default.ImageSize;
				string format = Settings.Default.Format;
				
				foreach (var arg in args) {
					if (arg == "--help" || arg == "-h" || arg == "?" || arg == "/?")
					{
						Console.WriteLine();
						Console.WriteLine(@"Available commands por Icon Extractor:");
						Console.WriteLine();
						Console.WriteLine(@"--help, -h, ?, /? - Shows this help");
						Console.WriteLine();
						Console.WriteLine("--size:<size>, -s:<size> - Specifies a size for extracting the icon. Examples:");
						Console.WriteLine(@"""Icon Extractor"" --size:large C:\path\to\file.exe");
						Console.WriteLine(@"""Icon Extractor"" -s:small C:\path\to\file.dll");
						Console.WriteLine();
						Console.WriteLine(@"--isize:<size>, -is:<size> - Specifies a size for generating an icon from an image. Examples:");
						Console.WriteLine(@"""Icon Extractor"" --isize:48 C:\path\to\image.png");
						Console.WriteLine(@"""Icon Extractor"" -is:32 C:\path\to\image.jpg");
						Console.WriteLine();
						Console.WriteLine(@"--format:<format>, -f:<format> - Specifies the format of the extracted icon. Examples:");
						Console.WriteLine(@"""Icon Extractor"" --format:ico C:\path\to\file.exe");
						Console.WriteLine(@"""Icon Extractor"" -f:jpg C:\path\to\file.exe");
						Console.WriteLine();
						Console.WriteLine(@"""Icon Extractor"" <file> - Extracts the specified file to the same directory");
					}
					else if (arg.StartsWith("--size") || arg.StartsWith("-s"))
					{
						string siz = arg.Split(':')[1];
						if (siz == "large")
							size = IconSize.Large;
						else if (siz == "small")
							size = IconSize.Small;
					}
					else if (arg.StartsWith("--isize") || arg.StartsWith("-is"))
						Int32.TryParse(arg.Split(':')[1], out imgsize);
					else if (arg.StartsWith("--format") || arg.StartsWith("-f"))
						format = "." + arg.Split(':')[1];
					else
						try {
							Extract(arg.Trim('"'), format, size, imgsize);
						} catch { Console.WriteLine("Could not extract " + arg); }
				}
			}
		}
		
		static void Extract(string filename, string format, IconSize size, int imgsize)
		{	
			string saveto = Path.Combine(Path.GetDirectoryName(filename),
			                             Path.GetFileNameWithoutExtension(filename) + format);
			
			var icon = IsImage(filename) ? IconUtils.IconFromImage(Image.FromFile(filename),
                                      imgsize, imgsize) : IconUtils.ExtractIcon(filename, size);
			
			switch (format) {
				case ".ico":
					IconUtils.SaveIcon(icon, saveto);
					break;
				case ".png":
					icon.ToBitmap().Save(saveto, ImageFormat.Png);
					break;
				case ".jpg":
					icon.ToBitmap().Save(saveto, ImageFormat.Jpeg);
					break;
				case ".bmp":
					icon.ToBitmap().Save(saveto, ImageFormat.Bmp);
					break;
			}
		}
		
		static bool IsImage(string filename)
		{
			return new [] { ".tif", ".tiff", ".gif", ".jpeg", ".jpg", ".png", ".bmp" }
			.Contains(Path.GetExtension(filename).ToLower());
		}
	}
}
