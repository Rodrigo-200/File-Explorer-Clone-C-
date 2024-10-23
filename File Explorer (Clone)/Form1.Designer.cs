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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvw_FileExplorer = new System.Windows.Forms.ListView();
            this.ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cms_GeneralOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbb_ViewType = new System.Windows.Forms.ComboBox();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.btn_GoUpOneLevel = new System.Windows.Forms.Button();
            this.btn_Foward = new System.Windows.Forms.Button();
            this.btn_GoBack = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_GeneralOptions.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(951, 558);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(182, 558);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "document.png");
            // 
            // lvw_FileExplorer
            // 
            this.lvw_FileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Name,
            this.ch_Modified,
            this.ch_Type,
            this.ch_Size});
            this.lvw_FileExplorer.ContextMenuStrip = this.cms_GeneralOptions;
            this.lvw_FileExplorer.FullRowSelect = true;
            this.lvw_FileExplorer.HideSelection = false;
            this.lvw_FileExplorer.LabelEdit = true;
            this.lvw_FileExplorer.LargeImageList = this.imageList1;
            this.lvw_FileExplorer.Location = new System.Drawing.Point(8, 63);
            this.lvw_FileExplorer.Name = "lvw_FileExplorer";
            this.lvw_FileExplorer.Size = new System.Drawing.Size(760, 491);
            this.lvw_FileExplorer.SmallImageList = this.imageList1;
            this.lvw_FileExplorer.TabIndex = 6;
            this.lvw_FileExplorer.UseCompatibleStateImageBehavior = false;
            this.lvw_FileExplorer.View = System.Windows.Forms.View.Details;
            this.lvw_FileExplorer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvw_FileExplorer_AfterLabelEdit);
            this.lvw_FileExplorer.DoubleClick += new System.EventHandler(this.lvw_FileExplorer_DoubleClick);
            this.lvw_FileExplorer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvw_FileExplorer_MouseClick);
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
            this.ch_Size.Width = 85;
            // 
            // cms_GeneralOptions
            // 
            this.cms_GeneralOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.cms_GeneralOptions.Name = "cms_GeneralOptions";
            this.cms_GeneralOptions.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTextFileToolStripMenuItem,
            this.addNewFolderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addNewTextFileToolStripMenuItem
            // 
            this.addNewTextFileToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.document;
            this.addNewTextFileToolStripMenuItem.Name = "addNewTextFileToolStripMenuItem";
            this.addNewTextFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewTextFileToolStripMenuItem.Text = "Add new Text File";
            this.addNewTextFileToolStripMenuItem.Click += new System.EventHandler(this.addNewTextFileToolStripMenuItem_Click);
            // 
            // addNewFolderToolStripMenuItem
            // 
            this.addNewFolderToolStripMenuItem.Image = global::File_Explorer__Clone_.Properties.Resources.folder;
            this.addNewFolderToolStripMenuItem.Name = "addNewFolderToolStripMenuItem";
            this.addNewFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewFolderToolStripMenuItem.Text = "Add New Folder";
            this.addNewFolderToolStripMenuItem.Click += new System.EventHandler(this.addNewFolderToolStripMenuItem_Click);
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
            this.cbb_ViewType.Location = new System.Drawing.Point(666, 36);
            this.cbb_ViewType.Name = "cbb_ViewType";
            this.cbb_ViewType.Size = new System.Drawing.Size(97, 21);
            this.cbb_ViewType.TabIndex = 5;
            this.cbb_ViewType.SelectedIndexChanged += new System.EventHandler(this.cbb_ViewType_SelectedIndexChanged);
            // 
            // txt_Path
            // 
            this.txt_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Path.Location = new System.Drawing.Point(103, 11);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(669, 20);
            this.txt_Path.TabIndex = 4;
            this.txt_Path.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Path_KeyPress);
            // 
            // btn_GoUpOneLevel
            // 
            this.btn_GoUpOneLevel.FlatAppearance.BorderSize = 0;
            this.btn_GoUpOneLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GoUpOneLevel.Location = new System.Drawing.Point(71, 10);
            this.btn_GoUpOneLevel.Name = "btn_GoUpOneLevel";
            this.btn_GoUpOneLevel.Size = new System.Drawing.Size(27, 20);
            this.btn_GoUpOneLevel.TabIndex = 3;
            this.btn_GoUpOneLevel.Text = "↑";
            this.btn_GoUpOneLevel.UseVisualStyleBackColor = true;
            this.btn_GoUpOneLevel.Click += new System.EventHandler(this.btn_GoUpOneLevel_Click);
            // 
            // btn_Foward
            // 
            this.btn_Foward.FlatAppearance.BorderSize = 0;
            this.btn_Foward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Foward.Location = new System.Drawing.Point(39, 10);
            this.btn_Foward.Name = "btn_Foward";
            this.btn_Foward.Size = new System.Drawing.Size(27, 20);
            this.btn_Foward.TabIndex = 2;
            this.btn_Foward.Text = "→";
            this.btn_Foward.UseVisualStyleBackColor = true;
            this.btn_Foward.Click += new System.EventHandler(this.btn_Foward_Click);
            // 
            // btn_GoBack
            // 
            this.btn_GoBack.FlatAppearance.BorderSize = 0;
            this.btn_GoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GoBack.Location = new System.Drawing.Point(8, 10);
            this.btn_GoBack.Name = "btn_GoBack";
            this.btn_GoBack.Size = new System.Drawing.Size(27, 20);
            this.btn_GoBack.TabIndex = 1;
            this.btn_GoBack.Text = "←";
            this.btn_GoBack.UseVisualStyleBackColor = true;
            this.btn_GoBack.Click += new System.EventHandler(this.btn_GoBack_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 558);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_GeneralOptions.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btn_GoBack;
        private TextBox txt_Path;
        private Button btn_GoUpOneLevel;
        private Button btn_Foward;
        private ComboBox cbb_ViewType;
        private TreeView treeView1;
        private ImageList imageList1;
        private ListView lvw_FileExplorer;
        private ColumnHeader ch_Name;
        private ColumnHeader ch_Modified;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem addNewTextFileToolStripMenuItem;
        private ToolStripMenuItem addNewFolderToolStripMenuItem;
        private ContextMenuStrip cms_GeneralOptions;
        private ColumnHeader ch_Type;
        private ColumnHeader ch_Size;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem apagarToolStripMenuItem;
    }
}
