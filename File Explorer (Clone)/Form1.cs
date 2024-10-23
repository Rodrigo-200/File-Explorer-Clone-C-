using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Explorer__Clone_
{
    public partial class Form1 : Form
    {
        string path = Environment.CurrentDirectory + @"\";
        string recent = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        List<string> OldPosition = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Path.Text = path;
            lvw_FileExplorer.View = View.Details;
            RefreshExplorer();

        }

        private void RefreshExplorer()
        {
            lvw_FileExplorer.Items.Clear();
            txt_Path.Text = path; //Mostra o path
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var item in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
            {
                try
                {
                    ListViewItem Directory = new ListViewItem();
                    Directory.Text = item.Name;
                    Directory.ImageIndex = 0;


                    ListViewItem.ListViewSubItem Mod_date = new ListViewItem.ListViewSubItem();
                    Mod_date.Text = item.LastWriteTime.ToString();
                    ListViewItem.ListViewSubItem _Type = new ListViewItem.ListViewSubItem();
                    _Type.Text = item.Extension.ToString();


                    Directory.SubItems.Add(Mod_date);
                    Directory.SubItems.Add(_Type);

                    lvw_FileExplorer.Items.Add(Directory);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            foreach (var item in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path" e vai buscar todos os ficheiros
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.Name;
                listViewItem.ImageIndex = 1;

                ListViewItem.ListViewSubItem Mod_date = new ListViewItem.ListViewSubItem();
                Mod_date.Text = item.LastWriteTime.ToString();
                ListViewItem.ListViewSubItem _Type = new ListViewItem.ListViewSubItem();
                _Type.Text = item.Extension.ToString();
                ListViewItem.ListViewSubItem Size = new ListViewItem.ListViewSubItem();
                double ByteSize = Convert.ToDouble(item.Length);
                Size.Text = (ByteSize / 1024).ToString();


                listViewItem.SubItems.Add(Mod_date);
                listViewItem.SubItems.Add(_Type);
                listViewItem.SubItems.Add(Size);

                lvw_FileExplorer.Items.Add(listViewItem);
            }



        }

        private void lvw_FileExplorer_DoubleClick(object sender, EventArgs e)
        {
            if (lvw_FileExplorer.SelectedItems[0].ImageIndex == 0)
            {
                try
                {
                    path = path += lvw_FileExplorer.SelectedItems[0].Text + @"\";
                    RefreshExplorer();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                File.Open(path + @"\" + lvw_FileExplorer.SelectedItems[0].Text, FileMode.Open);
            }

        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            path = OldPosition.Last();
            OldPosition.Remove(path);
            OldPosition.Add(path);
            
            RefreshExplorer();
        }

        private void cbb_ViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_ViewType.SelectedItem == "Details")
            {
                lvw_FileExplorer.View = View.Details;
            }
            if (cbb_ViewType.SelectedItem == "List")
            {
                lvw_FileExplorer.View = View.List;
            }
            if (cbb_ViewType.SelectedItem == "Large Icons")
            {
                lvw_FileExplorer.View = View.LargeIcon;
            }
            if (cbb_ViewType.SelectedItem == "Small Icons")
            {
                lvw_FileExplorer.View = View.SmallIcon;
            }
        }


        private void lvw_FileExplorer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                MessageBox.Show("The file name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string originalFullPath = Path.Combine(path, lvw_FileExplorer.Items[e.Item].Text);
            string newFullPath = Path.Combine(path, e.Label);

           
            try
            {
                if (lvw_FileExplorer.FocusedItem.ImageIndex == 1)
                {
                    System.IO.File.Move(originalFullPath, newFullPath);
                    lvw_FileExplorer.SelectedItems[0].Text = e.Label;

                }
                else
                {
                    System.IO.Directory.Move(lvw_FileExplorer.SelectedItems[0].Text, e.Label);
                    lvw_FileExplorer.SelectedItems[0].Text = e.Label;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }

        private void btn_Foward_Click(object sender, EventArgs e)
        {
            path = OldPosition.Last();
            OldPosition.Remove(path);
            RefreshExplorer();
        }

        private void txt_Path_TextChanged(object sender, EventArgs e)
        {
            path = txt_Path.Text;
        }


        private void txt_Path_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string oldpath = path;
                path = txt_Path.Text;

                OldPosition.Add(oldpath);
                RefreshExplorer();
            }
        }

        private void lvw_FileExplorer_MouseClick(object sender, MouseEventArgs e)
        {
            /*
             * POR ACABAR
             */
            if (lvw_FileExplorer.FocusedItem != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    lvw_FileExplorer.ContextMenuStrip = contextMenuStrip1;
                    cms_GeneralOptions.Show();

                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    lvw_FileExplorer.ContextMenuStrip = cms_GeneralOptions;
                    cms_GeneralOptions.Show();
                }
            }

        }

        private void btn_GoUpOneLevel_Click(object sender, EventArgs e)
        {
            OldPosition.Add(path);
            path = new DirectoryInfo(path).Parent.FullName + @"\";
            RefreshExplorer();
        }

        private void addNewTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFileName = "New File.txt";

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream fs = File.Create(fullPath)) { }

                RefreshExplorer();


                foreach (ListViewItem item in lvw_FileExplorer.Items)
                {
                    if (item.Text == newFileName)
                    {
                        lvw_FileExplorer.FocusedItem = item;
                        item.Selected = true;
                        item.BeginEdit();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating file: " + ex.Message);
            }
        }

        private void addNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFolderName = "New Folder";

            try
            {
                Directory.CreateDirectory(path + @"\" + newFolderName);

                RefreshExplorer();


                foreach (ListViewItem item in lvw_FileExplorer.Items)
                {
                    if (item.Text == newFolderName)
                    {
                        lvw_FileExplorer.FocusedItem = item;
                        item.Selected = true;
                        item.BeginEdit();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Directory: " + ex.Message);
            }
        }
    }

}

