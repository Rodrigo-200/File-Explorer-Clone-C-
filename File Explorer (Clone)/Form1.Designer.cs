
namespace File_Explorer__Clone_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.lvw_FileExplorer = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.cbb_ViewType = new System.Windows.Forms.ComboBox();
            this.btn_GoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvw_FileExplorer
            // 
            this.lvw_FileExplorer.HideSelection = false;
            this.lvw_FileExplorer.LargeImageList = this.imageList1;
            this.lvw_FileExplorer.Location = new System.Drawing.Point(184, 90);
            this.lvw_FileExplorer.Name = "lvw_FileExplorer";
            this.lvw_FileExplorer.Size = new System.Drawing.Size(604, 348);
            this.lvw_FileExplorer.TabIndex = 0;
            this.lvw_FileExplorer.UseCompatibleStateImageBehavior = false;
            this.lvw_FileExplorer.DoubleClick += new System.EventHandler(this.lvw_FileExplorer_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "document.png");
            this.imageList1.Images.SetKeyName(2, "folder (1).png");
            this.imageList1.Images.SetKeyName(3, "hidden.png");
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(121, 12);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(667, 22);
            this.txt_Path.TabIndex = 1;
            // 
            // cbb_ViewType
            // 
            this.cbb_ViewType.FormattingEnabled = true;
            this.cbb_ViewType.Items.AddRange(new object[] {
            "Detalhes",
            "Lista",
            "Icons Grandes"});
            this.cbb_ViewType.Location = new System.Drawing.Point(323, 60);
            this.cbb_ViewType.Name = "cbb_ViewType";
            this.cbb_ViewType.Size = new System.Drawing.Size(102, 24);
            this.cbb_ViewType.TabIndex = 2;
            this.cbb_ViewType.SelectedIndexChanged += new System.EventHandler(this.cbb_ViewType_SelectedIndexChanged);
            // 
            // btn_GoBack
            // 
            this.btn_GoBack.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GoBack.Location = new System.Drawing.Point(0, 13);
            this.btn_GoBack.Name = "btn_GoBack";
            this.btn_GoBack.Size = new System.Drawing.Size(48, 23);
            this.btn_GoBack.TabIndex = 3;
            this.btn_GoBack.Text = "<-";
            this.btn_GoBack.UseVisualStyleBackColor = false;
            this.btn_GoBack.Click += new System.EventHandler(this.btn_GoBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_GoBack);
            this.Controls.Add(this.cbb_ViewType);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.lvw_FileExplorer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_FileExplorer;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cbb_ViewType;
        private System.Windows.Forms.Button btn_GoBack;
    }
}

