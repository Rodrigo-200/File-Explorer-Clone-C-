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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imgl_Large = new System.Windows.Forms.ImageList(this.components);
            this.lvw_FileExplorer = new System.Windows.Forms.ListView();
            this.ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgl_Small = new System.Windows.Forms.ImageList(this.components);
            this.cbb_ViewType = new System.Windows.Forms.ComboBox();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.btn_GoUpOneLevel = new System.Windows.Forms.Button();
            this.btn_Foward = new System.Windows.Forms.Button();
            this.btn_GoBack = new System.Windows.Forms.Button();
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
            this.cms_FileOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHiddenFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_GeneralOptions.SuspendLayout();
            this.cms_FileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvw_FileExplorer);
            this.splitContainer1.Panel2.Controls.Add(this.cbb_ViewType);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Path);
            this.splitContainer1.Panel2.Controls.Add(this.btn_GoUpOneLevel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Foward);
            this.splitContainer1.Panel2.Controls.Add(this.btn_GoBack);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 687);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(242, 687);
            this.treeView1.StateImageList = this.imgl_Large;
            this.treeView1.TabIndex = 0;
            // 
            // imgl_Large
            // 
            this.imgl_Large.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_Large.ImageStream")));
            this.imgl_Large.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_Large.Images.SetKeyName(0, "folder.png");
            this.imgl_Large.Images.SetKeyName(1, "txt.png");
            this.imgl_Large.Images.SetKeyName(2, "rar.png");
            this.imgl_Large.Images.SetKeyName(3, "pdb-file-format-variant.png");
            this.imgl_Large.Images.SetKeyName(4, "configfile.png");
            this.imgl_Large.Images.SetKeyName(5, "exe (1).png");
            this.imgl_Large.Images.SetKeyName(6, "pptx.png");
            this.imgl_Large.Images.SetKeyName(7, "doc.png");
            this.imgl_Large.Images.SetKeyName(8, "png-file.png");
            this.imgl_Large.Images.SetKeyName(9, "lua.png");
            this.imgl_Large.Images.SetKeyName(10, "docmfile.png");
            this.imgl_Large.Images.SetKeyName(11, "audio.png");
            // 
            // lvw_FileExplorer
            // 
            this.lvw_FileExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_FileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Name,
            this.ch_Modified,
            this.ch_Type,
            this.ch_Size});
            this.lvw_FileExplorer.FullRowSelect = true;
            this.lvw_FileExplorer.HideSelection = false;
            this.lvw_FileExplorer.LabelEdit = true;
            this.lvw_FileExplorer.LargeImageList = this.imgl_Large;
            this.lvw_FileExplorer.Location = new System.Drawing.Point(4, 78);
            this.lvw_FileExplorer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvw_FileExplorer.Name = "lvw_FileExplorer";
            this.lvw_FileExplorer.Size = new System.Drawing.Size(1022, 603);
            this.lvw_FileExplorer.SmallImageList = this.imgl_Small;
            this.lvw_FileExplorer.TabIndex = 6;
            this.lvw_FileExplorer.UseCompatibleStateImageBehavior = false;
            this.lvw_FileExplorer.View = System.Windows.Forms.View.Details;
            this.lvw_FileExplorer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvw_FileExplorer_AfterLabelEdit);
            this.lvw_FileExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvw_FileExplorer_ColumnClick);
            this.lvw_FileExplorer.DoubleClick += new System.EventHandler(this.lvw_FileExplorer_DoubleClick);
            this.lvw_FileExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvw_FileExplorer_KeyDown);
            this.lvw_FileExplorer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvw_FileExplorer_KeyPress);
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
            // ch_Type
            // 
            this.ch_Type.Text = "Type";
            this.ch_Type.Width = 123;
            // 
            // ch_Size
            // 
            this.ch_Size.Text = "Size";
            this.ch_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Size.Width = 85;
            // 
            // imgl_Small
            // 
            this.imgl_Small.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_Small.ImageStream")));
            this.imgl_Small.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_Small.Images.SetKeyName(0, "folder.png");
            this.imgl_Small.Images.SetKeyName(1, "txt.png");
            this.imgl_Small.Images.SetKeyName(2, "rar.png");
            this.imgl_Small.Images.SetKeyName(3, "pdb-file-format-variant.png");
            this.imgl_Small.Images.SetKeyName(4, "configfile.png");
            this.imgl_Small.Images.SetKeyName(5, "exe (1).png");
            this.imgl_Small.Images.SetKeyName(6, "pptx.png");
            this.imgl_Small.Images.SetKeyName(7, "doc.png");
            this.imgl_Small.Images.SetKeyName(8, "png-file.png");
            this.imgl_Small.Images.SetKeyName(9, "lua.png");
            this.imgl_Small.Images.SetKeyName(10, "docmfile.png");
            this.imgl_Small.Images.SetKeyName(11, "audio.png");
            // 
            // cbb_ViewType
            // 
            this.cbb_ViewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_ViewType.FormattingEnabled = true;
            this.cbb_ViewType.Items.AddRange(new object[] {
            "Details",
            "List",
            "Large Icons",
            "Small Icons"});
            this.cbb_ViewType.Location = new System.Drawing.Point(894, 44);
            this.cbb_ViewType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbb_ViewType.Name = "cbb_ViewType";
            this.cbb_ViewType.Size = new System.Drawing.Size(124, 24);
            this.cbb_ViewType.TabIndex = 5;
            this.cbb_ViewType.SelectedIndexChanged += new System.EventHandler(this.cbb_ViewType_SelectedIndexChanged);
            // 
            // txt_Path
            // 
            this.txt_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Path.Location = new System.Drawing.Point(137, 14);
            this.txt_Path.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(881, 22);
            this.txt_Path.TabIndex = 4;
            this.txt_Path.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Path_KeyPress);
            // 
            // btn_GoUpOneLevel
            // 
            this.btn_GoUpOneLevel.FlatAppearance.BorderSize = 0;
            this.btn_GoUpOneLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GoUpOneLevel.Location = new System.Drawing.Point(95, 12);
            this.btn_GoUpOneLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_GoUpOneLevel.Name = "btn_GoUpOneLevel";
            this.btn_GoUpOneLevel.Size = new System.Drawing.Size(36, 25);
            this.btn_GoUpOneLevel.TabIndex = 3;
            this.btn_GoUpOneLevel.Text = "↑";
            this.btn_GoUpOneLevel.UseVisualStyleBackColor = true;
            this.btn_GoUpOneLevel.Click += new System.EventHandler(this.btn_GoUpOneLevel_Click);
            // 
            // btn_Foward
            // 
            this.btn_Foward.FlatAppearance.BorderSize = 0;
            this.btn_Foward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Foward.Location = new System.Drawing.Point(52, 12);
            this.btn_Foward.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Foward.Name = "btn_Foward";
            this.btn_Foward.Size = new System.Drawing.Size(36, 25);
            this.btn_Foward.TabIndex = 2;
            this.btn_Foward.Text = "→";
            this.btn_Foward.UseVisualStyleBackColor = true;
            this.btn_Foward.Click += new System.EventHandler(this.btn_Foward_Click);
            // 
            // btn_GoBack
            // 
            this.btn_GoBack.FlatAppearance.BorderSize = 0;
            this.btn_GoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GoBack.Location = new System.Drawing.Point(11, 12);
            this.btn_GoBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_GoBack.Name = "btn_GoBack";
            this.btn_GoBack.Size = new System.Drawing.Size(36, 25);
            this.btn_GoBack.TabIndex = 1;
            this.btn_GoBack.Text = "←";
            this.btn_GoBack.UseVisualStyleBackColor = true;
            this.btn_GoBack.Click += new System.EventHandler(this.btn_GoBack_Click);
            // 
            // cms_GeneralOptions
            // 
            this.cms_GeneralOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_GeneralOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.addToolStripMenuItem,
            this.sortByToolStripMenuItem,
            this.showHiddenFilesToolStripMenuItem});
            this.cms_GeneralOptions.Name = "cms_GeneralOptions";
            this.cms_GeneralOptions.Size = new System.Drawing.Size(215, 136);
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
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.check_box_empty;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.largeIconsToolStripMenuItem.Text = "Large Icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.menu;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.smallIconsToolStripMenuItem.Text = "Small Icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.menu__1_;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.view_list;
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
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
            this.addToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.addToolStripMenuItem.Text = "New";
            // 
            // addNewTextFileToolStripMenuItem
            // 
            this.addNewTextFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.document;
            this.addNewTextFileToolStripMenuItem.Name = "addNewTextFileToolStripMenuItem";
            this.addNewTextFileToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addNewTextFileToolStripMenuItem.Text = "New Text File";
            this.addNewTextFileToolStripMenuItem.Click += new System.EventHandler(this.addNewTextFileToolStripMenuItem_Click);
            // 
            // addNewFolderToolStripMenuItem
            // 
            this.addNewFolderToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.folder;
            this.addNewFolderToolStripMenuItem.Name = "addNewFolderToolStripMenuItem";
            this.addNewFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
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
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.sortByToolStripMenuItem.Text = "Sort by";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // dateModifiedToolStripMenuItem
            // 
            this.dateModifiedToolStripMenuItem.Name = "dateModifiedToolStripMenuItem";
            this.dateModifiedToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.dateModifiedToolStripMenuItem.Text = "Date Modified";
            this.dateModifiedToolStripMenuItem.Click += new System.EventHandler(this.dateModifiedToolStripMenuItem_Click);
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.sort_descending;
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.sort;
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.descendingToolStripMenuItem.Text = "Descending";
            // 
            // cms_FileOptions
            // 
            this.cms_FileOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_FileOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.cms_FileOptions.Name = "contextMenuStrip1";
            this.cms_FileOptions.Size = new System.Drawing.Size(169, 56);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.delete;
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources._7725075;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.copyToolStripMenuItem.Text = "Copy as path";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // showHiddenFilesToolStripMenuItem
            // 
            this.showHiddenFilesToolStripMenuItem.Name = "showHiddenFilesToolStripMenuItem";
            this.showHiddenFilesToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showHiddenFilesToolStripMenuItem.Text = "Show Hidden Items";
            this.showHiddenFilesToolStripMenuItem.Click += new System.EventHandler(this.showHiddenFilesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 687);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_GeneralOptions.ResumeLayout(false);
            this.cms_FileOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewColumnSorter lvwColumnSorter;
        private SplitContainer splitContainer1;
        private Button btn_GoBack;
        private TextBox txt_Path;
        private Button btn_GoUpOneLevel;
        private Button btn_Foward;
        private ComboBox cbb_ViewType;
        private TreeView treeView1;
        private ImageList imgl_Large;
        private ListView lvw_FileExplorer;
        private ColumnHeader ch_Name;
        private ColumnHeader ch_Modified;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem addNewTextFileToolStripMenuItem;
        private ToolStripMenuItem addNewFolderToolStripMenuItem;
        private ContextMenuStrip cms_GeneralOptions;
        private ColumnHeader ch_Type;
        private ColumnHeader ch_Size;
        private ContextMenuStrip cms_FileOptions;
        private ToolStripMenuItem apagarToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem largeIconsToolStripMenuItem;
        private ToolStripMenuItem smallIconsToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem detailToolStripMenuItem;
        private ImageList imgl_Small;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem sortByToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem dateModifiedToolStripMenuItem;
        private ToolStripMenuItem ascendingToolStripMenuItem;
        private ToolStripMenuItem descendingToolStripMenuItem;
        private ToolStripMenuItem showHiddenFilesToolStripMenuItem;
    }
}
