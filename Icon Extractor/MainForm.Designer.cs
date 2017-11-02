
namespace Icon_Extractor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button addB;
		private System.Windows.Forms.Label sizeL;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.ListBox filesLB;
		private System.Windows.Forms.Button deleteB;
		private System.Windows.Forms.Button cleanB;
		private System.Windows.Forms.GroupBox filesGB;
		private System.Windows.Forms.GroupBox optionsGB;
		private System.Windows.Forms.ComboBox sizeCB;
		private System.Windows.Forms.Label tipL;
		private System.Windows.Forms.Label previewL;
		private System.Windows.Forms.PictureBox previewPB;
		private System.Windows.Forms.Button extractSelectedB;
		private System.Windows.Forms.Button extractAllB;
		private System.Windows.Forms.ComboBox formatCB;
		private System.Windows.Forms.Label formatL;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label spamL;
		private System.Windows.Forms.NumericUpDown sizeImgNUD;
		private System.Windows.Forms.Label sizeImgL;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.addB = new System.Windows.Forms.Button();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.filesLB = new System.Windows.Forms.ListBox();
			this.deleteB = new System.Windows.Forms.Button();
			this.cleanB = new System.Windows.Forms.Button();
			this.filesGB = new System.Windows.Forms.GroupBox();
			this.previewPB = new System.Windows.Forms.PictureBox();
			this.tipL = new System.Windows.Forms.Label();
			this.previewL = new System.Windows.Forms.Label();
			this.optionsGB = new System.Windows.Forms.GroupBox();
			this.spamL = new System.Windows.Forms.Label();
			this.sizeImgNUD = new System.Windows.Forms.NumericUpDown();
			this.sizeImgL = new System.Windows.Forms.Label();
			this.formatCB = new System.Windows.Forms.ComboBox();
			this.formatL = new System.Windows.Forms.Label();
			this.extractSelectedB = new System.Windows.Forms.Button();
			this.extractAllB = new System.Windows.Forms.Button();
			this.sizeL = new System.Windows.Forms.Label();
			this.sizeCB = new System.Windows.Forms.ComboBox();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.filesGB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.previewPB)).BeginInit();
			this.optionsGB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sizeImgNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// addB
			// 
			this.addB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addB.Location = new System.Drawing.Point(170, 86);
			this.addB.Name = "addB";
			this.addB.Size = new System.Drawing.Size(103, 24);
			this.addB.TabIndex = 0;
			this.addB.Text = "Añadir archivos(s)";
			this.addB.UseVisualStyleBackColor = true;
			this.addB.Click += new System.EventHandler(this.SearchBClick);
			// 
			// ofd
			// 
			this.ofd.Filter = "Todos los archivos|*";
			this.ofd.Multiselect = true;
			this.ofd.Title = "Elija los archivos de los cuales desea extraer el icono";
			// 
			// filesLB
			// 
			this.filesLB.AllowDrop = true;
			this.filesLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.filesLB.FormattingEnabled = true;
			this.filesLB.Location = new System.Drawing.Point(6, 26);
			this.filesLB.Name = "filesLB";
			this.filesLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.filesLB.Size = new System.Drawing.Size(158, 264);
			this.filesLB.TabIndex = 3;
			this.filesLB.SelectedIndexChanged += new System.EventHandler(this.FilesLBSelectedIndexChanged);
			this.filesLB.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilesLBDragDrop);
			this.filesLB.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesLBDragEnter);
			this.filesLB.MouseLeave += new System.EventHandler(this.FilesLBMouseLeave);
			this.filesLB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FilesLBMouseMove);
			// 
			// deleteB
			// 
			this.deleteB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteB.Enabled = false;
			this.deleteB.Location = new System.Drawing.Point(170, 56);
			this.deleteB.Name = "deleteB";
			this.deleteB.Size = new System.Drawing.Size(103, 24);
			this.deleteB.TabIndex = 4;
			this.deleteB.Text = "Eliminar archivo(s)";
			this.deleteB.UseVisualStyleBackColor = true;
			this.deleteB.Click += new System.EventHandler(this.DeleteBClick);
			// 
			// cleanB
			// 
			this.cleanB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cleanB.Location = new System.Drawing.Point(170, 26);
			this.cleanB.Name = "cleanB";
			this.cleanB.Size = new System.Drawing.Size(77, 24);
			this.cleanB.TabIndex = 5;
			this.cleanB.Text = "Limpiar lista";
			this.cleanB.UseVisualStyleBackColor = true;
			this.cleanB.Click += new System.EventHandler(this.CleanBClick);
			// 
			// filesGB
			// 
			this.filesGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.filesGB.Controls.Add(this.previewPB);
			this.filesGB.Controls.Add(this.tipL);
			this.filesGB.Controls.Add(this.filesLB);
			this.filesGB.Controls.Add(this.previewL);
			this.filesGB.Controls.Add(this.cleanB);
			this.filesGB.Controls.Add(this.addB);
			this.filesGB.Controls.Add(this.deleteB);
			this.filesGB.Location = new System.Drawing.Point(12, 12);
			this.filesGB.Name = "filesGB";
			this.filesGB.Size = new System.Drawing.Size(294, 309);
			this.filesGB.TabIndex = 6;
			this.filesGB.TabStop = false;
			this.filesGB.Text = "Archivos";
			// 
			// previewPB
			// 
			this.previewPB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.previewPB.Location = new System.Drawing.Point(238, 116);
			this.previewPB.Name = "previewPB";
			this.previewPB.Size = new System.Drawing.Size(48, 48);
			this.previewPB.TabIndex = 3;
			this.previewPB.TabStop = false;
			// 
			// tipL
			// 
			this.tipL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tipL.Location = new System.Drawing.Point(170, 234);
			this.tipL.Name = "tipL";
			this.tipL.Size = new System.Drawing.Size(103, 58);
			this.tipL.TabIndex = 6;
			this.tipL.Text = "Consejo: También puedes arrastrrar y soltar archivos a la lista para añadirlos.";
			// 
			// previewL
			// 
			this.previewL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.previewL.Location = new System.Drawing.Point(167, 128);
			this.previewL.Name = "previewL";
			this.previewL.Size = new System.Drawing.Size(66, 17);
			this.previewL.TabIndex = 2;
			this.previewL.Text = "Vista previa";
			// 
			// optionsGB
			// 
			this.optionsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsGB.Controls.Add(this.spamL);
			this.optionsGB.Controls.Add(this.sizeImgNUD);
			this.optionsGB.Controls.Add(this.sizeImgL);
			this.optionsGB.Controls.Add(this.formatCB);
			this.optionsGB.Controls.Add(this.formatL);
			this.optionsGB.Controls.Add(this.extractSelectedB);
			this.optionsGB.Controls.Add(this.extractAllB);
			this.optionsGB.Controls.Add(this.sizeL);
			this.optionsGB.Controls.Add(this.sizeCB);
			this.optionsGB.Location = new System.Drawing.Point(312, 12);
			this.optionsGB.Name = "optionsGB";
			this.optionsGB.Size = new System.Drawing.Size(220, 309);
			this.optionsGB.TabIndex = 7;
			this.optionsGB.TabStop = false;
			this.optionsGB.Text = "Opciones";
			// 
			// spamL
			// 
			this.spamL.Location = new System.Drawing.Point(6, 212);
			this.spamL.Name = "spamL";
			this.spamL.Size = new System.Drawing.Size(203, 94);
			this.spamL.TabIndex = 8;
			this.spamL.Text = "Icon Extractor - Aplicación creada por Lonami.\r\n\r\nPara soporte, por favor visite " +
	"http://lonamiwebs.github.io\r\n\r\nLonamiWebs (C) 2015";
			// 
			// sizeImgNUD
			// 
			this.sizeImgNUD.Location = new System.Drawing.Point(125, 50);
			this.sizeImgNUD.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.sizeImgNUD.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.sizeImgNUD.Name = "sizeImgNUD";
			this.sizeImgNUD.Size = new System.Drawing.Size(71, 20);
			this.sizeImgNUD.TabIndex = 7;
			this.sizeImgNUD.Value = new decimal(new int[] {
			48,
			0,
			0,
			0});
			this.sizeImgNUD.ValueChanged += new System.EventHandler(this.SizeImgNUDValueChanged);
			// 
			// sizeImgL
			// 
			this.sizeImgL.Location = new System.Drawing.Point(6, 52);
			this.sizeImgL.Name = "sizeImgL";
			this.sizeImgL.Size = new System.Drawing.Size(113, 20);
			this.sizeImgL.TabIndex = 6;
			this.sizeImgL.Text = "Tamaño de imágenes:";
			// 
			// formatCB
			// 
			this.formatCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.formatCB.FormattingEnabled = true;
			this.formatCB.Items.AddRange(new object[] {
			".ico",
			".png",
			".jpg",
			".bmp"});
			this.formatCB.Location = new System.Drawing.Point(139, 83);
			this.formatCB.Name = "formatCB";
			this.formatCB.Size = new System.Drawing.Size(57, 21);
			this.formatCB.TabIndex = 5;
			this.toolTip.SetToolTip(this.formatCB, "Puedes extraer el icono de un archivo a diferentes formatos");
			this.formatCB.SelectedIndexChanged += new System.EventHandler(this.FormatCBSelectedIndexChanged);
			// 
			// formatL
			// 
			this.formatL.Location = new System.Drawing.Point(6, 86);
			this.formatL.Name = "formatL";
			this.formatL.Size = new System.Drawing.Size(127, 21);
			this.formatL.TabIndex = 4;
			this.formatL.Text = "Extraer iconos al formato:";
			this.toolTip.SetToolTip(this.formatL, "Puedes extraer el icono de un archivo a diferentes formatos");
			// 
			// extractSelectedB
			// 
			this.extractSelectedB.Enabled = false;
			this.extractSelectedB.Location = new System.Drawing.Point(6, 186);
			this.extractSelectedB.Name = "extractSelectedB";
			this.extractSelectedB.Size = new System.Drawing.Size(203, 23);
			this.extractSelectedB.TabIndex = 3;
			this.extractSelectedB.Text = "Extraer los iconos de los archivos seleccionados";
			this.extractSelectedB.UseVisualStyleBackColor = true;
			this.extractSelectedB.Click += new System.EventHandler(this.ExtractSelectedBClick);
			// 
			// extractAllB
			// 
			this.extractAllB.Location = new System.Drawing.Point(6, 157);
			this.extractAllB.Name = "extractAllB";
			this.extractAllB.Size = new System.Drawing.Size(203, 23);
			this.extractAllB.TabIndex = 2;
			this.extractAllB.Text = "Extraer los iconos de todos los archivos";
			this.extractAllB.UseVisualStyleBackColor = true;
			this.extractAllB.Click += new System.EventHandler(this.ExtractAllBClick);
			// 
			// sizeL
			// 
			this.sizeL.Location = new System.Drawing.Point(6, 26);
			this.sizeL.Name = "sizeL";
			this.sizeL.Size = new System.Drawing.Size(50, 21);
			this.sizeL.TabIndex = 1;
			this.sizeL.Text = "Tamaño:";
			this.toolTip.SetToolTip(this.sizeL, "Este tamaño es el que se utilizará para extraer\r\nel icono de todo aquello que no " +
		"sea una imagen");
			// 
			// sizeCB
			// 
			this.sizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sizeCB.FormattingEnabled = true;
			this.sizeCB.Items.AddRange(new object[] {
			"Pequeño",
			"Grande"});
			this.sizeCB.Location = new System.Drawing.Point(62, 23);
			this.sizeCB.Name = "sizeCB";
			this.sizeCB.Size = new System.Drawing.Size(134, 21);
			this.sizeCB.TabIndex = 0;
			this.toolTip.SetToolTip(this.sizeCB, "Este tamaño es el que se utilizará para extraer\r\nel icono de todo aquello que no " +
		"sea una imagen");
			this.sizeCB.SelectedIndexChanged += new System.EventHandler(this.SizeCBSelectedIndexChanged);
			// 
			// sfd
			// 
			this.sfd.Filter = "Todos los archivos|*";
			// 
			// toolTip
			// 
			this.toolTip.IsBalloon = true;
			this.toolTip.ShowAlways = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 327);
			this.Controls.Add(this.optionsGB);
			this.Controls.Add(this.filesGB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(555, 366);
			this.Name = "MainForm";
			this.Text = "Extractor de iconos";
			this.filesGB.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.previewPB)).EndInit();
			this.optionsGB.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sizeImgNUD)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
