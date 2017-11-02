
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Icon_Extractor
{
	public partial class MainForm : Form
	{
		#region Variables
		
		ToolTip filesTT;
		
		int lindex = -1;
		
		public enum Format { Icon = 0, Png = 1, Jpg = 2, Bmp = 3 }
		
		string[] imagetypes = { ".tif", ".tiff", ".gif", ".jpeg", ".jpg", ".png", ".bmp" };
		
		#endregion
		
		#region Initialization
		
		public MainForm()
		{
			InitializeComponent();
			
			filesTT = new ToolTip() {
				ShowAlways = true
			};
			
			sizeCB.SelectedIndex = Settings.Default.Size;
			formatCB.SelectedItem = Settings.Default.Format;
			sizeImgNUD.Value = Settings.Default.ImageSize;
		}
		
		#endregion
		
		#region Add and remove files
		
		void SearchBClick(object sender, EventArgs e) {
			if (ofd.ShowDialog() == DialogResult.OK)
				AddFiles(ofd.FileNames);
		}
		
		void FilesLBDragEnter(object sender, DragEventArgs e)
		{ e.Effect = DragDropEffects.Copy; }
		
		void FilesLBDragDrop(object sender, DragEventArgs e)
		{ AddFiles((string[])e.Data.GetData(DataFormats.FileDrop)); }
		
		void AddFiles(string[] files) {
			foreach (var file in files)
				if (!filesLB.Items.Contains(file))
					filesLB.Items.Add(file);
		}
		
		
		void CleanBClick(object sender, EventArgs e)
		{
			filesLB.Items.Clear();
		}
		
		void DeleteBClick(object sender, EventArgs e)
		{
			var items = new List<object>();
			for (int i = 0; i < filesLB.Items.Count; i++)
				if (!filesLB.SelectedIndices.Contains(i))
					items.Add(filesLB.Items[i]);
			
			filesLB.Items.Clear();
			filesLB.Items.AddRange(items.ToArray());
		}
		
		#endregion
		
		#region Tool tip
		
		void FilesLBMouseMove(object sender, MouseEventArgs e)
		{
			int i = filesLB.IndexFromPoint(filesLB.PointToClient(Cursor.Position));
			
			if (i < 0) {
				filesTT.Active = false;
				lindex = i;
				return;
			}
			
			filesTT.Active = true;
			
			if (lindex == i)
				return;
			lindex = i;
			
			filesTT.SetToolTip(filesLB, filesLB.Items[i].ToString());
		}
		
		void FilesLBMouseLeave(object sender, EventArgs e)
		{
			lindex = -1;
			filesTT.Active = false;
		}
		
		#endregion
		
		#region Preview
		
		void SizeCBSelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshPreview();
			
			Settings.Default.Size = sizeCB.SelectedIndex;
			Settings.Default.Save();
		}
		
		void FilesLBSelectedIndexChanged(object sender, EventArgs e)
		{ RefreshPreview(); }
		
		void RefreshPreview() {
			if (filesLB.SelectedIndex > -1) {
				IconSize size = GetSize();
				deleteB.Enabled = extractSelectedB.Enabled = true;
				previewPB.Image = IconFromFile(filesLB.SelectedItem.ToString()).ToBitmap();
			} else {
				deleteB.Enabled = extractSelectedB.Enabled = false;
				previewPB.Image = null;
			}
		}
		
		#endregion
		
		#region Extract
		
		
		void ExtractAllBClick(object sender, EventArgs e)
		{
			if (filesLB.Items.Count == 0)
			{
				MessageBox.Show("No se ha añadido ningún archivo", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			var filenames = new string[filesLB.Items.Count];
			for (int i = 0; i < filesLB.Items.Count; i++)
				filenames[i] = filesLB.Items[i].ToString();
			Extract(filenames);
		}
		
		void Extract(string[] filenames)
		{	
			string ext = GetExtension();
			
			if (filenames.Length == 1)
			{
				string orifilename = filenames[0];
				sfd.FileName = Path.GetFileNameWithoutExtension(orifilename) + ext;
				sfd.Filter = GetFilter();
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					SaveIcon(orifilename, sfd.FileName);
					
					MessageBox.Show("Se ha extraido el icono correctamente", "Icono extraido",
					                MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					foreach (var orifilename in filenames)
						SaveIcon(orifilename, Path.Combine(fbd.SelectedPath,
			                                   Path.GetFileNameWithoutExtension(orifilename)) + ext);
					
					MessageBox.Show("Se han extraido los iconos correctamente", "Iconos extraidos",
					                MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		
		void SaveIcon(string orifilename, string filename) {
			var icon = IconFromFile(orifilename);
			
			switch ((Format)formatCB.SelectedIndex) {
				case Format.Icon:
					IconUtils.SaveIcon(icon, filename);
					break;
				case Format.Png:
					Image png = icon.ToBitmap();
					png.Save(filename, ImageFormat.Png);
					break;
				case Format.Jpg:
					Image jpg = icon.ToBitmap();
					jpg.Save(filename, ImageFormat.Jpeg);
					break;
				case Format.Bmp:
					Image bmp = icon.ToBitmap();
					bmp.Save(filename, ImageFormat.Bmp);
					break;
			}
		}
		
		// Or even better: save the this as string and not int, meh lazy
		string GetExtension() {
			switch ((Format)formatCB.SelectedIndex) {
				case Format.Icon:
					return ".ico";
				case Format.Png:
					return ".png";
				case Format.Jpg:
					return ".jpg";
				case Format.Bmp:
					return ".bmp";
				default:
					return "";
			}
		}
		
		void FormatCBSelectedIndexChanged(object sender, EventArgs e)
		{
			Settings.Default.Format = formatCB.SelectedItem.ToString();
			Settings.Default.Save();
		}
		
		
		#endregion
		
		#region Others
		
		string GetFilter() {
			switch ((Format)formatCB.SelectedIndex) {
				case Format.Icon:
					return "Archivo de icono|*.ico";
				case Format.Png:
					return "Archivo de imagen|*.png";
				case Format.Jpg:
					return "Archivo de imagen|*.jpg";
				case Format.Bmp:
					return "Archivo de mapa de bits|*.bmp";
				default:
					return "Todos los archivos|*";
			}
		}
		
		IconSize GetSize() {
			return sizeCB.SelectedIndex == 0 ? IconSize.Small : IconSize.Large;
		}
		
		Icon IconFromFile(string filename) {
			IconSize size = GetSize();
			int imgsize = (int)sizeImgNUD.Value;
			
			return IsImage(filename) ? IconUtils.IconFromImage(Image.FromFile(filename),
                                      imgsize, imgsize) : IconUtils.ExtractIcon(filename, size);
		}
		
		bool IsImage(string filename) {
			return imagetypes.Contains(Path.GetExtension(filename).ToLower());
		}
		
		void SizeImgNUDValueChanged(object sender, EventArgs e) {
			Settings.Default.ImageSize = (int)sizeImgNUD.Value;
			Settings.Default.Save();
		}
		
		void ExtractSelectedBClick(object sender, EventArgs e)
		{
			var files = new string[filesLB.SelectedIndices.Count];
			for (int i = 0; i < filesLB.SelectedIndices.Count; i++)
				files[i] = filesLB.SelectedItems[i].ToString();
			Extract(files);
		}
		
		#endregion
	}
}