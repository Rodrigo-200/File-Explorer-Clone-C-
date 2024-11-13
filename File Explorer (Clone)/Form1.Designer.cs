using System.Drawing;
using System.Windows.Forms;

namespace File_Explorer__Clone_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvw_Disks = new System.Windows.Forms.TreeView();
            this.imgl_Drivers = new System.Windows.Forms.ImageList(this.components);
            this.lbl_EncodingOptions = new System.Windows.Forms.Label();
            this.cbb_EncodingOptions = new System.Windows.Forms.ComboBox();
            this.lbl_FileContent = new System.Windows.Forms.Label();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lbl_LinePosition = new System.Windows.Forms.Label();
            this.lbl_CaracterPosition = new System.Windows.Forms.Label();
            this.txt_LinePosition = new System.Windows.Forms.TextBox();
            this.txt_CaracterPosition = new System.Windows.Forms.TextBox();
            this.btn_BinaryWriter = new System.Windows.Forms.Button();
            this.btn_StreamWriter = new System.Windows.Forms.Button();
            this.txt_FileContent = new System.Windows.Forms.TextBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdd_new = new System.Windows.Forms.ToolStripDropDownButton();
            this.newtextfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPowerPointFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWinRarFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Cut = new System.Windows.Forms.ToolStripButton();
            this.tsb_Copy = new System.Windows.Forms.ToolStripButton();
            this.tsb_Paste = new System.Windows.Forms.ToolStripButton();
            this.tsb_delete = new System.Windows.Forms.ToolStripButton();
            this.tsb_Rename = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbb_ViewType = new System.Windows.Forms.ToolStripDropDownButton();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.nameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateModifiedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ascendingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Favorite = new System.Windows.Forms.ToolStripButton();
            this.tsb_Extract = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_GoBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Foward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_GoUpOneLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_refresh = new System.Windows.Forms.ToolStripButton();
            this.txt_Path = new System.Windows.Forms.ToolStripTextBox();
            this.lvw_FileExplorer = new System.Windows.Forms.ListView();
            this.ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgl_Large = new System.Windows.Forms.ImageList(this.components);
            this.imgl_Small = new System.Windows.Forms.ImageList(this.components);
            this.cms_GeneralOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHiddenFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_FileOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressAsWinRARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressAsZIPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.cms_GeneralOptions.SuspendLayout();
            this.cms_FileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvw_Disks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_ok);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_EncodingOptions);
            this.splitContainer1.Panel2.Controls.Add(this.cbb_EncodingOptions);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_FileContent);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_FileName);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_LinePosition);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_CaracterPosition);
            this.splitContainer1.Panel2.Controls.Add(this.txt_LinePosition);
            this.splitContainer1.Panel2.Controls.Add(this.txt_CaracterPosition);
            this.splitContainer1.Panel2.Controls.Add(this.btn_BinaryWriter);
            this.splitContainer1.Panel2.Controls.Add(this.btn_StreamWriter);
            this.splitContainer1.Panel2.Controls.Add(this.txt_FileContent);
            this.splitContainer1.Panel2.Controls.Add(this.txt_FileName);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.lvw_FileExplorer);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 558);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvw_Disks
            // 
            this.tvw_Disks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_Disks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_Disks.ImageIndex = 0;
            this.tvw_Disks.ImageList = this.imgl_Drivers;
            this.tvw_Disks.Indent = 19;
            this.tvw_Disks.LineColor = System.Drawing.Color.White;
            this.tvw_Disks.Location = new System.Drawing.Point(0, 0);
            this.tvw_Disks.Name = "tvw_Disks";
            this.tvw_Disks.PathSeparator = "";
            this.tvw_Disks.SelectedImageIndex = 0;
            this.tvw_Disks.Size = new System.Drawing.Size(239, 558);
            this.tvw_Disks.StateImageList = this.imgl_Drivers;
            this.tvw_Disks.TabIndex = 0;
            this.tvw_Disks.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.tvw_Disks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            this.tvw_Disks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            this.tvw_Disks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // imgl_Drivers
            // 
            this.imgl_Drivers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_Drivers.ImageStream")));
            this.imgl_Drivers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_Drivers.Images.SetKeyName(0, "computer.png");
            this.imgl_Drivers.Images.SetKeyName(1, "hard-drive (1).png");
            this.imgl_Drivers.Images.SetKeyName(2, "flash-disk.png");
            this.imgl_Drivers.Images.SetKeyName(3, "cloud-storage.png");
            this.imgl_Drivers.Images.SetKeyName(4, "dvd-rom.png");
            this.imgl_Drivers.Images.SetKeyName(5, "folder.png");
            this.imgl_Drivers.Images.SetKeyName(6, "windows.png");
            this.imgl_Drivers.Images.SetKeyName(7, "star.png");
            // 
            // lbl_EncodingOptions
            // 
            this.lbl_EncodingOptions.AutoSize = true;
            this.lbl_EncodingOptions.Location = new System.Drawing.Point(928, 319);
            this.lbl_EncodingOptions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EncodingOptions.Name = "lbl_EncodingOptions";
            this.lbl_EncodingOptions.Size = new System.Drawing.Size(106, 13);
            this.lbl_EncodingOptions.TabIndex = 31;
            this.lbl_EncodingOptions.Text = "Metodo de Encoding";
            this.lbl_EncodingOptions.Visible = false;
            // 
            // cbb_EncodingOptions
            // 
            this.cbb_EncodingOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_EncodingOptions.FormattingEnabled = true;
            this.cbb_EncodingOptions.Items.AddRange(new object[] {
            "UTF8",
            "UTF32",
            "ASCII"});
            this.cbb_EncodingOptions.Location = new System.Drawing.Point(928, 335);
            this.cbb_EncodingOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbb_EncodingOptions.Name = "cbb_EncodingOptions";
            this.cbb_EncodingOptions.Size = new System.Drawing.Size(104, 21);
            this.cbb_EncodingOptions.TabIndex = 30;
            this.cbb_EncodingOptions.Visible = false;
            // 
            // lbl_FileContent
            // 
            this.lbl_FileContent.AutoSize = true;
            this.lbl_FileContent.Location = new System.Drawing.Point(817, 91);
            this.lbl_FileContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileContent.Name = "lbl_FileContent";
            this.lbl_FileContent.Size = new System.Drawing.Size(108, 13);
            this.lbl_FileContent.TabIndex = 29;
            this.lbl_FileContent.Text = "Conteudo do Ficheiro";
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(817, 53);
            this.lbl_FileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(90, 13);
            this.lbl_FileName.TabIndex = 28;
            this.lbl_FileName.Text = "Nome do Ficheiro";
            // 
            // lbl_LinePosition
            // 
            this.lbl_LinePosition.AutoSize = true;
            this.lbl_LinePosition.Location = new System.Drawing.Point(819, 355);
            this.lbl_LinePosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LinePosition.Name = "lbl_LinePosition";
            this.lbl_LinePosition.Size = new System.Drawing.Size(89, 13);
            this.lbl_LinePosition.TabIndex = 27;
            this.lbl_LinePosition.Text = "Posição da Linha";
            // 
            // lbl_CaracterPosition
            // 
            this.lbl_CaracterPosition.AutoSize = true;
            this.lbl_CaracterPosition.Location = new System.Drawing.Point(819, 319);
            this.lbl_CaracterPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_CaracterPosition.Name = "lbl_CaracterPosition";
            this.lbl_CaracterPosition.Size = new System.Drawing.Size(103, 13);
            this.lbl_CaracterPosition.TabIndex = 26;
            this.lbl_CaracterPosition.Text = "Posição do Caracter";
            // 
            // txt_LinePosition
            // 
            this.txt_LinePosition.Location = new System.Drawing.Point(821, 370);
            this.txt_LinePosition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_LinePosition.Name = "txt_LinePosition";
            this.txt_LinePosition.Size = new System.Drawing.Size(106, 20);
            this.txt_LinePosition.TabIndex = 25;
            // 
            // txt_CaracterPosition
            // 
            this.txt_CaracterPosition.Location = new System.Drawing.Point(820, 335);
            this.txt_CaracterPosition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_CaracterPosition.Name = "txt_CaracterPosition";
            this.txt_CaracterPosition.Size = new System.Drawing.Size(104, 20);
            this.txt_CaracterPosition.TabIndex = 24;
            // 
            // btn_BinaryWriter
            // 
            this.btn_BinaryWriter.Location = new System.Drawing.Point(928, 298);
            this.btn_BinaryWriter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_BinaryWriter.Name = "btn_BinaryWriter";
            this.btn_BinaryWriter.Size = new System.Drawing.Size(105, 19);
            this.btn_BinaryWriter.TabIndex = 23;
            this.btn_BinaryWriter.Text = "Binary Writer";
            this.btn_BinaryWriter.UseVisualStyleBackColor = true;
            this.btn_BinaryWriter.Click += new System.EventHandler(this.btn_BinaryWriter_Click);
            // 
            // btn_StreamWriter
            // 
            this.btn_StreamWriter.Location = new System.Drawing.Point(819, 298);
            this.btn_StreamWriter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_StreamWriter.Name = "btn_StreamWriter";
            this.btn_StreamWriter.Size = new System.Drawing.Size(104, 19);
            this.btn_StreamWriter.TabIndex = 22;
            this.btn_StreamWriter.Text = "Stream Writer";
            this.btn_StreamWriter.UseVisualStyleBackColor = true;
            this.btn_StreamWriter.Click += new System.EventHandler(this.btn_StreamWriter_Click);
            // 
            // txt_FileContent
            // 
            this.txt_FileContent.Location = new System.Drawing.Point(819, 106);
            this.txt_FileContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_FileContent.Multiline = true;
            this.txt_FileContent.Name = "txt_FileContent";
            this.txt_FileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_FileContent.Size = new System.Drawing.Size(215, 188);
            this.txt_FileContent.TabIndex = 21;
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(820, 68);
            this.txt_FileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(215, 20);
            this.txt_FileName.TabIndex = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdd_new,
            this.toolStripSeparator8,
            this.tsb_Cut,
            this.tsb_Copy,
            this.tsb_Paste,
            this.tsb_delete,
            this.tsb_Rename,
            this.toolStripSeparator1,
            this.cbb_ViewType,
            this.toolStripDropDownButton1,
            this.toolStripSeparator6,
            this.tsb_Favorite,
            this.tsb_Extract});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1042, 27);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsdd_new
            // 
            this.tsdd_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(237)))), ((int)(((byte)(175)))));
            this.tsdd_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtextfileToolStripMenuItem,
            this.newPowerPointFileToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.newWinRarFileToolStripMenuItem});
            this.tsdd_new.Image = global::File_Explorer__Clone_.Properties.Resources.add;
            this.tsdd_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdd_new.Name = "tsdd_new";
            this.tsdd_new.Size = new System.Drawing.Size(64, 24);
            this.tsdd_new.Text = "New";
            this.tsdd_new.ToolTipText = "New";
            // 
            // newtextfileToolStripMenuItem
            // 
            this.newtextfileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.file;
            this.newtextfileToolStripMenuItem.Name = "newtextfileToolStripMenuItem";
            this.newtextfileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newtextfileToolStripMenuItem.Text = "New Text File";
            this.newtextfileToolStripMenuItem.Click += new System.EventHandler(this.newtextfileToolStripMenuItem_Click);
            // 
            // newPowerPointFileToolStripMenuItem
            // 
            this.newPowerPointFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.pptx;
            this.newPowerPointFileToolStripMenuItem.Name = "newPowerPointFileToolStripMenuItem";
            this.newPowerPointFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newPowerPointFileToolStripMenuItem.Text = "New PowerPoint File";
            this.newPowerPointFileToolStripMenuItem.Click += new System.EventHandler(this.newPowerPointFileToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.folder;
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // newWinRarFileToolStripMenuItem
            // 
            this.newWinRarFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.rar;
            this.newWinRarFileToolStripMenuItem.Name = "newWinRarFileToolStripMenuItem";
            this.newWinRarFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newWinRarFileToolStripMenuItem.Text = "New WinRar File";
            this.newWinRarFileToolStripMenuItem.Click += new System.EventHandler(this.newWinRarFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_Cut
            // 
            this.tsb_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Cut.Image = global::File_Explorer__Clone_.Properties.Resources.scissors;
            this.tsb_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Cut.Name = "tsb_Cut";
            this.tsb_Cut.Size = new System.Drawing.Size(24, 24);
            this.tsb_Cut.Text = "toolStripButton1";
            this.tsb_Cut.Click += new System.EventHandler(this.tsb_Cut_Click);
            // 
            // tsb_Copy
            // 
            this.tsb_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Copy.Image = global::File_Explorer__Clone_.Properties.Resources.copy;
            this.tsb_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Copy.Name = "tsb_Copy";
            this.tsb_Copy.Size = new System.Drawing.Size(24, 24);
            this.tsb_Copy.Text = "tsb_Copy";
            this.tsb_Copy.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsb_Paste
            // 
            this.tsb_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Paste.Image = global::File_Explorer__Clone_.Properties.Resources.paste;
            this.tsb_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Paste.Name = "tsb_Paste";
            this.tsb_Paste.Size = new System.Drawing.Size(24, 24);
            this.tsb_Paste.Text = "toolStripButton2";
            this.tsb_Paste.Click += new System.EventHandler(this.tsb_Paste_Click);
            // 
            // tsb_delete
            // 
            this.tsb_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_delete.Image = global::File_Explorer__Clone_.Properties.Resources.delete;
            this.tsb_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_delete.Name = "tsb_delete";
            this.tsb_delete.Size = new System.Drawing.Size(24, 24);
            this.tsb_delete.Text = "Delete";
            this.tsb_delete.Click += new System.EventHandler(this.tsb_delete_Click);
            // 
            // tsb_Rename
            // 
            this.tsb_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Rename.Enabled = false;
            this.tsb_Rename.Image = global::File_Explorer__Clone_.Properties.Resources.rename;
            this.tsb_Rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Rename.Name = "tsb_Rename";
            this.tsb_Rename.Size = new System.Drawing.Size(24, 24);
            this.tsb_Rename.Text = "Rename";
            this.tsb_Rename.Click += new System.EventHandler(this.tsb_Rename_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // cbb_ViewType
            // 
            this.cbb_ViewType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.listToolStripMenuItem1,
            this.largeIconToolStripMenuItem,
            this.smallIconsToolStripMenuItem1});
            this.cbb_ViewType.Image = global::File_Explorer__Clone_.Properties.Resources.menu__1_;
            this.cbb_ViewType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbb_ViewType.Name = "cbb_ViewType";
            this.cbb_ViewType.Size = new System.Drawing.Size(65, 24);
            this.cbb_ViewType.Text = "View";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.view_list;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem1
            // 
            this.listToolStripMenuItem1.Image = global::File_Explorer__Clone_.Properties.Resources.menu__1_;
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem1.Text = "List";
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.listToolStripMenuItem1_Click);
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.check_box_empty;
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.largeIconToolStripMenuItem.Text = "Large Icons";
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.largeIconToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem1
            // 
            this.smallIconsToolStripMenuItem1.Image = global::File_Explorer__Clone_.Properties.Resources.menu;
            this.smallIconsToolStripMenuItem1.Name = "smallIconsToolStripMenuItem1";
            this.smallIconsToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem1.Text = "Small Icons";
            this.smallIconsToolStripMenuItem1.Click += new System.EventHandler(this.smallIconsToolStripMenuItem1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem1,
            this.dateModifiedToolStripMenuItem1,
            this.typeToolStripMenuItem,
            this.toolStripSeparator7,
            this.ascendingToolStripMenuItem1,
            this.descendingToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = global::File_Explorer__Clone_.Properties.Resources.arrows;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(61, 24);
            this.toolStripDropDownButton1.Text = "Sort";
            // 
            // nameToolStripMenuItem1
            // 
            this.nameToolStripMenuItem1.Name = "nameToolStripMenuItem1";
            this.nameToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.nameToolStripMenuItem1.Text = "Name";
            // 
            // dateModifiedToolStripMenuItem1
            // 
            this.dateModifiedToolStripMenuItem1.Name = "dateModifiedToolStripMenuItem1";
            this.dateModifiedToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.dateModifiedToolStripMenuItem1.Text = "Date Modified";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(146, 6);
            // 
            // ascendingToolStripMenuItem1
            // 
            this.ascendingToolStripMenuItem1.Name = "ascendingToolStripMenuItem1";
            this.ascendingToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.ascendingToolStripMenuItem1.Text = "Ascending";
            // 
            // descendingToolStripMenuItem1
            // 
            this.descendingToolStripMenuItem1.Image = global::File_Explorer__Clone_.Properties.Resources.sort;
            this.descendingToolStripMenuItem1.Name = "descendingToolStripMenuItem1";
            this.descendingToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.descendingToolStripMenuItem1.Text = "Descending";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_Favorite
            // 
            this.tsb_Favorite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Favorite.Image = global::File_Explorer__Clone_.Properties.Resources.star;
            this.tsb_Favorite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Favorite.Name = "tsb_Favorite";
            this.tsb_Favorite.Size = new System.Drawing.Size(24, 24);
            this.tsb_Favorite.Text = "Add to favorites";
            this.tsb_Favorite.Click += new System.EventHandler(this.tsb_Favorite_Click);
            // 
            // tsb_Extract
            // 
            this.tsb_Extract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Extract.Image = global::File_Explorer__Clone_.Properties.Resources.folder__1_;
            this.tsb_Extract.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Extract.Name = "tsb_Extract";
            this.tsb_Extract.Size = new System.Drawing.Size(24, 24);
            this.tsb_Extract.Text = "toolStripButton1";
            this.tsb_Extract.Visible = false;
            this.tsb_Extract.Click += new System.EventHandler(this.tsb_Extract_Click_1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_GoBack,
            this.toolStripSeparator4,
            this.btn_Foward,
            this.toolStripSeparator5,
            this.btn_GoUpOneLevel,
            this.toolStripSeparator2,
            this.tsb_refresh,
            this.txt_Path});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1042, 27);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_GoBack
            // 
            this.btn_GoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_GoBack.Enabled = false;
            this.btn_GoBack.Image = global::File_Explorer__Clone_.Properties.Resources.turn_back;
            this.btn_GoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_GoBack.Name = "btn_GoBack";
            this.btn_GoBack.Size = new System.Drawing.Size(24, 24);
            this.btn_GoBack.Text = "toolStripButton1";
            this.btn_GoBack.Click += new System.EventHandler(this.btn_GoBack_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_Foward
            // 
            this.btn_Foward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Foward.Enabled = false;
            this.btn_Foward.Image = global::File_Explorer__Clone_.Properties.Resources.redo;
            this.btn_Foward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Foward.Name = "btn_Foward";
            this.btn_Foward.Size = new System.Drawing.Size(24, 24);
            this.btn_Foward.Text = "toolStripButton2";
            this.btn_Foward.ToolTipText = "Foward";
            this.btn_Foward.Click += new System.EventHandler(this.btn_Foward_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_GoUpOneLevel
            // 
            this.btn_GoUpOneLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_GoUpOneLevel.Image = global::File_Explorer__Clone_.Properties.Resources.arrow;
            this.btn_GoUpOneLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_GoUpOneLevel.Name = "btn_GoUpOneLevel";
            this.btn_GoUpOneLevel.Size = new System.Drawing.Size(24, 24);
            this.btn_GoUpOneLevel.Text = "toolStripButton3";
            this.btn_GoUpOneLevel.Click += new System.EventHandler(this.btn_GoUpOneLevel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_refresh
            // 
            this.tsb_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_refresh.Image = global::File_Explorer__Clone_.Properties.Resources.up_to_date;
            this.tsb_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_refresh.Name = "tsb_refresh";
            this.tsb_refresh.Size = new System.Drawing.Size(24, 24);
            this.tsb_refresh.Text = "toolStripButton4";
            this.tsb_refresh.Click += new System.EventHandler(this.tsb_refresh_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(511, 27);
            this.txt_Path.Enter += new System.EventHandler(this.txt_Path_Enter);
            this.txt_Path.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Path_KeyPress);
            // 
            // lvw_FileExplorer
            // 
            this.lvw_FileExplorer.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvw_FileExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvw_FileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Name,
            this.ch_Modified,
            this.ch_Description,
            this.ch_Size});
            this.lvw_FileExplorer.FullRowSelect = true;
            this.lvw_FileExplorer.HideSelection = false;
            this.lvw_FileExplorer.LabelEdit = true;
            this.lvw_FileExplorer.LargeImageList = this.imgl_Large;
            this.lvw_FileExplorer.Location = new System.Drawing.Point(3, 53);
            this.lvw_FileExplorer.Name = "lvw_FileExplorer";
            this.lvw_FileExplorer.Size = new System.Drawing.Size(812, 501);
            this.lvw_FileExplorer.SmallImageList = this.imgl_Small;
            this.lvw_FileExplorer.TabIndex = 6;
            this.lvw_FileExplorer.UseCompatibleStateImageBehavior = false;
            this.lvw_FileExplorer.View = System.Windows.Forms.View.Details;
            this.lvw_FileExplorer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvw_FileExplorer_AfterLabelEdit);
            this.lvw_FileExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvw_FileExplorer_ColumnClick);
            this.lvw_FileExplorer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_FileExplorer_ItemSelectionChanged);
            this.lvw_FileExplorer.SelectedIndexChanged += new System.EventHandler(this.lvw_FileExplorer_SelectedIndexChanged);
            this.lvw_FileExplorer.DoubleClick += new System.EventHandler(this.lvw_FileExplorer_DoubleClick);
            this.lvw_FileExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvw_FileExplorer_KeyDown);
            this.lvw_FileExplorer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvw_FileExplorer_MouseClick);
            this.lvw_FileExplorer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvw_FileExplorer_MouseDown);
            // 
            // ch_Name
            // 
            this.ch_Name.Text = "Name";
            this.ch_Name.Width = 304;
            // 
            // ch_Modified
            // 
            this.ch_Modified.Text = "Date Modified";
            this.ch_Modified.Width = 154;
            // 
            // ch_Description
            // 
            this.ch_Description.Text = "Description";
            this.ch_Description.Width = 123;
            // 
            // ch_Size
            // 
            this.ch_Size.Text = "Size";
            this.ch_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Size.Width = 85;
            // 
            // imgl_Large
            // 
            this.imgl_Large.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_Large.ImageStream")));
            this.imgl_Large.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_Large.Images.SetKeyName(0, "folder.png");
            // 
            // imgl_Small
            // 
            this.imgl_Small.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_Small.ImageStream")));
            this.imgl_Small.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_Small.Images.SetKeyName(0, "folder.png");
            // 
            // cms_GeneralOptions
            // 
            this.cms_GeneralOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_GeneralOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.addToolStripMenuItem,
            this.sortByToolStripMenuItem,
            this.showHiddenFilesToolStripMenuItem,
            this.pasteToolStripMenuItem1});
            this.cms_GeneralOptions.Name = "cms_GeneralOptions";
            this.cms_GeneralOptions.Size = new System.Drawing.Size(182, 134);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailToolStripMenuItem});
            this.viewToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.menu;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.check_box_empty;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.largeIconsToolStripMenuItem.Text = "Large Icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.menu;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem.Text = "Small Icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.menu1;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.view_list;
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.detailToolStripMenuItem.Text = "Details";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.detailToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTextFileToolStripMenuItem,
            this.addNewFolderToolStripMenuItem});
            this.addToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.addToolStripMenuItem.Text = "New";
            // 
            // addNewTextFileToolStripMenuItem
            // 
            this.addNewTextFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.document;
            this.addNewTextFileToolStripMenuItem.Name = "addNewTextFileToolStripMenuItem";
            this.addNewTextFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addNewTextFileToolStripMenuItem.Text = "New Text File";
            this.addNewTextFileToolStripMenuItem.Click += new System.EventHandler(this.addNewTextFileToolStripMenuItem_Click);
            // 
            // addNewFolderToolStripMenuItem
            // 
            this.addNewFolderToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.folder;
            this.addNewFolderToolStripMenuItem.Name = "addNewFolderToolStripMenuItem";
            this.addNewFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addNewFolderToolStripMenuItem.Text = "New Folder";
            this.addNewFolderToolStripMenuItem.Click += new System.EventHandler(this.addNewFolderToolStripMenuItem_Click);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.dateModifiedToolStripMenuItem,
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem});
            this.sortByToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.arrows;
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.sortByToolStripMenuItem.Text = "Sort by";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // dateModifiedToolStripMenuItem
            // 
            this.dateModifiedToolStripMenuItem.Name = "dateModifiedToolStripMenuItem";
            this.dateModifiedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.dateModifiedToolStripMenuItem.Text = "Date Modified";
            this.dateModifiedToolStripMenuItem.Click += new System.EventHandler(this.dateModifiedToolStripMenuItem_Click);
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.sort;
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            // 
            // showHiddenFilesToolStripMenuItem
            // 
            this.showHiddenFilesToolStripMenuItem.Name = "showHiddenFilesToolStripMenuItem";
            this.showHiddenFilesToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.showHiddenFilesToolStripMenuItem.Text = "Show Hidden Items";
            this.showHiddenFilesToolStripMenuItem.Click += new System.EventHandler(this.showHiddenFilesToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Image = global::File_Explorer__Clone_.Properties.Resources.paste;
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // cms_FileOptions
            // 
            this.cms_FileOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_FileOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.addToFavoritesToolStripMenuItem,
            this.compressAsWinRARToolStripMenuItem,
            this.compressAsZIPFileToolStripMenuItem,
            this.openTextFileToolStripMenuItem});
            this.cms_FileOptions.Name = "contextMenuStrip1";
            this.cms_FileOptions.Size = new System.Drawing.Size(192, 238);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.delete;
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources._7725075;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.copyToolStripMenuItem.Text = "Copy as path";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.scissors;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = global::File_Explorer__Clone_.Properties.Resources.copy;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(191, 26);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.star;
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addToFavoritesToolStripMenuItem.Text = "Add to Favorites";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // compressAsWinRARToolStripMenuItem
            // 
            this.compressAsWinRARToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.pngwing_com;
            this.compressAsWinRARToolStripMenuItem.Name = "compressAsWinRARToolStripMenuItem";
            this.compressAsWinRARToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.compressAsWinRARToolStripMenuItem.Text = "Compress as WinRAR";
            this.compressAsWinRARToolStripMenuItem.Click += new System.EventHandler(this.compressAsWinRARToolStripMenuItem_Click);
            // 
            // compressAsZIPFileToolStripMenuItem
            // 
            this.compressAsZIPFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.zip_file;
            this.compressAsZIPFileToolStripMenuItem.Name = "compressAsZIPFileToolStripMenuItem";
            this.compressAsZIPFileToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.compressAsZIPFileToolStripMenuItem.Text = "Compress as ZIP File";
            this.compressAsZIPFileToolStripMenuItem.Click += new System.EventHandler(this.compressAsZIPFileToolStripMenuItem_Click);
            // 
            // openTextFileToolStripMenuItem
            // 
            this.openTextFileToolStripMenuItem.Name = "openTextFileToolStripMenuItem";
            this.openTextFileToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.openTextFileToolStripMenuItem.Text = "Open Text File";
            this.openTextFileToolStripMenuItem.Click += new System.EventHandler(this.openTextFileToolStripMenuItem_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(928, 361);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(102, 29);
            this.btn_ok.TabIndex = 32;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Visible = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 558);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Windows File Explorer (Clone)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.cms_GeneralOptions.ResumeLayout(false);
            this.cms_FileOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewColumnSorter lvwColumnSorter;
        private SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvw_Disks;
        private ImageList imgl_Large;
        private System.Windows.Forms.ListView lvw_FileExplorer;
        private ColumnHeader ch_Name;
        private ColumnHeader ch_Modified;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem addNewTextFileToolStripMenuItem;
        private ToolStripMenuItem addNewFolderToolStripMenuItem;
        private ContextMenuStrip cms_GeneralOptions;
        private ColumnHeader ch_Description;
        private ColumnHeader ch_Size;
        private ContextMenuStrip cms_FileOptions;
        private ToolStripMenuItem apagarToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private ImageList imgl_Small;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem sortByToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem dateModifiedToolStripMenuItem;
        private ToolStripMenuItem ascendingToolStripMenuItem;
        private ToolStripMenuItem descendingToolStripMenuItem;
        private ToolStripMenuItem showHiddenFilesToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btn_GoBack;
        private ToolStripButton btn_Foward;
        private ToolStripButton btn_GoUpOneLevel;
        private ToolStripButton tsb_refresh;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripTextBox txt_Path;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton tsdd_new;
        private ToolStripMenuItem newtextfileToolStripMenuItem;
        private ToolStripMenuItem newPowerPointFileToolStripMenuItem;
        private ToolStripMenuItem newFolderToolStripMenuItem;
        private ToolStripMenuItem newWinRarFileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton tsb_delete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton cbb_ViewType;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private ToolStripMenuItem smallIconsToolStripMenuItem1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem nameToolStripMenuItem1;
        private ToolStripMenuItem dateModifiedToolStripMenuItem1;
        private ToolStripMenuItem typeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem ascendingToolStripMenuItem1;
        private ToolStripMenuItem descendingToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator6;
        private ImageList imgl_Drivers;
        private ToolStripButton tsb_Copy;
        private ToolStripButton tsb_Paste;
        private ToolStripButton tsb_Cut;
        private ToolStripButton tsb_Favorite;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsb_Extract;
        private System.Windows.Forms.ToolStripMenuItem compressAsWinRARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressAsZIPFileToolStripMenuItem;
        private ToolStripButton tsb_Rename;
        private TextBox txt_LinePosition;
        private TextBox txt_CaracterPosition;
        private Button btn_BinaryWriter;
        private Button btn_StreamWriter;
        private TextBox txt_FileContent;
        private TextBox txt_FileName;
        private Label lbl_FileContent;
        private Label lbl_FileName;
        private Label lbl_LinePosition;
        private Label lbl_CaracterPosition;
        private Label lbl_EncodingOptions;
        private ComboBox cbb_EncodingOptions;
        private ToolStripMenuItem openTextFileToolStripMenuItem;
        private Button btn_ok;
    }
}
