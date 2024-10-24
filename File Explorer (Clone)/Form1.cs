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
using System.Linq.Expressions;
using System.Diagnostics;

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
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvw_FileExplorer.ListViewItemSorter = lvwColumnSorter;

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
                    _Type.Text = "File Folder";


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


                ListViewItem.ListViewSubItem Mod_date = new ListViewItem.ListViewSubItem();
                Mod_date.Text = item.LastWriteTime.ToString();
                ListViewItem.ListViewSubItem _Type = new ListViewItem.ListViewSubItem();
                _Type.Text = item.Extension.ToString();
                ListViewItem.ListViewSubItem Size = new ListViewItem.ListViewSubItem();
                double ByteSize = Convert.ToDouble(item.Length);
                double size = Math.Ceiling((ByteSize / 1024));
                Size.Text = size.ToString() + " KB";
                


                switch (item.Extension)
                {
                case ".txt":
                        listViewItem.ImageIndex = 1;
                        _Type.Text = "Text Document"; break;

                    case ".rar":
                        listViewItem.ImageIndex = 2;
                        _Type.Text = "Compressed Archive Folder"; break;

                    case ".pdb":
                        listViewItem.ImageIndex = 3;
                        _Type.Text = "Program Debug Database"; break;

                    case ".config":
                        listViewItem.ImageIndex = 4;
                        _Type.Text = "CONFIG File"; break;

                    case ".exe":
                        listViewItem.ImageIndex = 5;
                        _Type.Text = "Application"; break;

                    case ".pptx":
                        listViewItem.ImageIndex = 6;
                        _Type.Text = "Microsoft PowerPoint Presentation"; break;

                    case ".docx":
                        listViewItem.ImageIndex = 7;
                        _Type.Text = "Microsoft Word Document";  break;

                    case ".png":
                        listViewItem.ImageIndex = 8;
                        _Type.Text = "PNG File"; break;

                    case ".lua":
                        listViewItem.ImageIndex = 9;
                        _Type.Text = "Lua Source File"; break;

                    case ".lnk": 
                            try
                            {

                                string filePath = Path.Combine(item.FullName);

                                Icon icon = Icon.ExtractAssociatedIcon(filePath);


                                if (icon != null)
                                {

                                    Bitmap iconBitmap = icon.ToBitmap();


                                    string imageKey = filePath;


                                    if (!imgl_Large.Images.ContainsKey(imageKey))
                                    {
                                        imgl_Large.Images.Add(imageKey, iconBitmap);
                                    }

                                    if (!imgl_Small.Images.ContainsKey(imageKey))
                                    {
                                        imgl_Small.Images.Add(imageKey, iconBitmap);
                                    }


                                    listViewItem.ImageKey = imageKey;
                                    _Type.Text = "Shortcut";
                                }
                                else
                                {
                                    listViewItem.ImageIndex = 0; 
                                    _Type.Text = "Shortcut";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            } break;

                    case ".docm":
                        listViewItem.ImageIndex = 10;
                        _Type.Text = "Microsoft Word macro-enabled document"; break;

                    case ".mp4":
                        listViewItem.ImageIndex = 11;
                        _Type.Text = "MPEG 4 video"; break;

                    default:
                        listViewItem.ImageIndex = 1; break;


                }



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
                try
                {
                    string filePath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);
                    Process.Start(filePath); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
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
                return;
            }

            string originalFullPath = Path.Combine(path, lvw_FileExplorer.Items[e.Item].Text);
            string newFullPath = Path.Combine(path, e.Label);

           
            try
            {
                if (lvw_FileExplorer.FocusedItem.ImageIndex == 1)
                {
                    File.Move(originalFullPath, newFullPath);
                    lvw_FileExplorer.SelectedItems[0].Text = e.Label;

                }
                else
                {
                    Directory.Move(lvw_FileExplorer.SelectedItems[0].Text, e.Label);
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
        { }

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

        private void lvw_FileExplorer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Right-click detected
            {
                // Use HitTest to determine what was clicked
                var hitTestInfo = lvw_FileExplorer.HitTest(e.Location);

                if (hitTestInfo.Item != null) // If an item was clicked
                {
                    // Show item-specific context menu (contextMenuStrip1) at the cursor's position
                    cms_FileOptions.Show(Cursor.Position);
                }
                else // No item was clicked (clicked on empty space)
                {
                    // Show the general context menu (cms_GeneralOptions) at the cursor's position
                    cms_GeneralOptions.Show(Cursor.Position);
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFile();
        }

        private void deleteFile()
        {
            FileInfo file = new FileInfo(path + lvw_FileExplorer.SelectedItems[0].Text);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                RefreshExplorer();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(path + lvw_FileExplorer.SelectedItems[0].Text);
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.SmallIcon;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.List;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.Details;
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvw_FileExplorer.Sorting == SortOrder.Ascending)
            {
                lvw_FileExplorer.Sort();
                lvw_FileExplorer.Sorting = SortOrder.Descending;
            }
            else
            { 
            lvw_FileExplorer.Sort();
            lvw_FileExplorer.Sorting = SortOrder.Ascending;
        }
        }

        private void dateModifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * POR FAZER
             */
        }

        private void lvw_FileExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvw_FileExplorer.Sort();
        }

        private void lvw_FileExplorer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lvw_FileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFile();
            }
        }
    }

}

