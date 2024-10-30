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
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Diagnostics.Eventing.Reader;


namespace File_Explorer__Clone_
{
    public partial class Form1 : Form
    {
        string path = Environment.CurrentDirectory + @"\";
        string logspath = Environment.CurrentDirectory + @"\" + "Logs.txt";
        string recent = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "Microsoft" + @"\" + "Windows" + @"\" + "Recent";
        List<string> OldPosition = new List<string>();
        List<string> ForwardPosition = new List<string>();
        private List<string> favoritePaths = new List<string>();
        bool Show_Hidden = false;

        private List<string> copiedFilePaths = new List<string>();
        private bool cutOperation = false;

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
            refreshTreeView();
        }


        private void RefreshExplorer()
        {
            lvw_FileExplorer.Items.Clear();
            txt_Path.Text = path;
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                foreach (var item in dir.GetDirectories())
                {
                    try
                    {
                        if (!Show_Hidden)
                        {
                            if (item.Attributes.HasFlag(FileAttributes.Hidden)) { }
                            else
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
                        }
                        else
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
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                }
                foreach (var item in dir.GetFiles())
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
                        }
                        else
                        {
                            listViewItem.ImageIndex = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }

                    _Type.Text = GetFileTypeDescription(item.FullName);

                    listViewItem.SubItems.Add(Mod_date);
                    listViewItem.SubItems.Add(_Type);
                    listViewItem.SubItems.Add(Size);

                    lvw_FileExplorer.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        private string GetFileTypeDescription(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return Path.GetExtension(filePath).TrimStart('.').ToUpper() + " File";
        }

        private void lvw_FileExplorer_DoubleClick(object sender, EventArgs e)
        {
            if (lvw_FileExplorer.SelectedItems[0].ImageIndex == 0)
            {
                try
                {
                    string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text + @"\");
                    NavigateTo(selectedPath);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
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
                        LogError(ex.Message);
                    }
            }

        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            if (OldPosition.Count > 0)
            {
                ForwardPosition.Add(path);
                path = OldPosition.Last();
                OldPosition.RemoveAt(OldPosition.Count - 1);
                RefreshExplorer();
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
                LogError(ex.Message);
            }
        }

        private void btn_Foward_Click(object sender, EventArgs e)
        {
            if (ForwardPosition.Count > 0)
            {
                OldPosition.Add(path);
                path = ForwardPosition.Last();
                ForwardPosition.RemoveAt(ForwardPosition.Count - 1);
                RefreshExplorer();
            }
        }

        private void txt_Path_TextChanged(object sender, EventArgs e)
        {
            path = txt_Path.Text;
        }


        private void txt_Path_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NavigateTo(txt_Path.Text.Trim());
            }
        }

        private void lvw_FileExplorer_MouseClick(object sender, MouseEventArgs e)
        {
            FileInfo file = new FileInfo(path + lvw_FileExplorer.SelectedItems[0].Text);
            if (file.Extension == ".rar")
            {
                tsb_Extract.Visible = true;
            }
            else
            {
                tsb_Extract.Visible = false;
            }

            if (Directory.Exists(Path.Combine(path, lvw_FileExplorer.HitTest(e.Location).Item.Text)))
            {
                tsb_Favorite.Enabled = false;
                addToFavoritesToolStripMenuItem.Enabled = false;
            }
            else
            {
                tsb_Favorite.Enabled = true;
                addToFavoritesToolStripMenuItem.Enabled = true;
            }
        }

        private void btn_GoUpOneLevel_Click(object sender, EventArgs e)
        {
            if (Directory.GetParent(path) != null)
            {
                OldPosition.Add(path);
                path = new DirectoryInfo(path).Parent.FullName + @"\";
                RefreshExplorer();
            }
        }

        private void addNewTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.txt";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles())
                {
                    if (item2.Name == newFileName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFileName = "New File";
                    newFileName = newFileName + "(" + cnt + ")" + ".txt";
                }
            }

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream filestream = File.Create(fullPath)) { }

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
                LogError(ex.Message);
            }
        }

        private void addNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFolderName = "New Folder";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetDirectories())
                {
                    if (item2.Name == newFolderName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFolderName = "New Folder";
                    newFolderName = newFolderName + "(" + cnt + ")";
                }
            }

            string fullPath = Path.Combine(path, newFolderName);

            try
            {
                Directory.CreateDirectory(fullPath);

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
                LogError(ex.Message);
            }
        }

        private void lvw_FileExplorer_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = lvw_FileExplorer.HitTest(e.Location);

                if (hitTestInfo.Item != null)
                {
                    cms_FileOptions.Show(Cursor.Position);
                }
                else
                {
                    cms_GeneralOptions.Show(Cursor.Position);
                }
            }

            if (e.Button == MouseButtons.XButton2)
            {
                if (ForwardPosition.Count > 0)
                {
                    OldPosition.Add(path);
                    path = ForwardPosition.Last();
                    ForwardPosition.RemoveAt(ForwardPosition.Count - 1);
                    RefreshExplorer();
                }
            }

            if (e.Button == MouseButtons.XButton1)
            {
                if (OldPosition.Count > 0)
                {
                    ForwardPosition.Add(path);
                    path = OldPosition.Last();
                    OldPosition.RemoveAt(OldPosition.Count - 1);
                    RefreshExplorer();
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFile();
        }

        private void deleteFile()
        {
            int cnt = 0;
            foreach (var item in lvw_FileExplorer.SelectedItems)
            {
                if (lvw_FileExplorer.SelectedItems[cnt].ImageIndex != 0)
                {

                    FileInfo file = new FileInfo(path + lvw_FileExplorer.SelectedItems[cnt].Text);
                    if (file.Exists)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            LogError(ex.Message);
                        }

                    }
                }
                else
                {
                    DirectoryInfo directory = new DirectoryInfo(path + lvw_FileExplorer.SelectedItems[cnt].Text);
                    if (directory.Exists)
                    {
                        try
                        {
                            directory.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            LogError(ex.Message);
                        }

                    }
                }
                cnt++;

            }
            RefreshExplorer();
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
            if (e.Column == lvwColumnSorter.SortColumn)
            {
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
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lvw_FileExplorer.Sort();
        }

        private void lvw_FileExplorer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lvw_FileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
                {

                        item.BeginEdit();
                        break;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                deleteFile();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (File.Exists(path + lvw_FileExplorer.SelectedItems[0].Text))
                {
                    Process.Start(path + lvw_FileExplorer.SelectedItems[0].Text);
                }
                else
                {
                    string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);
                    NavigateTo(selectedPath);
                }
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                AddToClipboard(false);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFiles(path);
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                AddToClipboard(true);
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem item in lvw_FileExplorer.Items)
                {
                        item.Selected = true;
                }
            }

            if (e.Control && e.KeyCode == Keys.L || e.Alt && e.KeyCode == Keys.D)
            {
                txt_Path.Focus();
            }

            if (e.KeyCode == Keys.F5)
            {
                RefreshExplorer();
            }


        }

        private void showHiddenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Show_Hidden)
            {
                Show_Hidden = true;
            }
            else
            {
                Show_Hidden = false;
            }

            RefreshExplorer();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToClipboard(true);
        }

        private void NavigateTo(string newPath)
        {
            OldPosition.Add(path);
            path = newPath;
            ForwardPosition.Clear();
            RefreshExplorer();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.Details;
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.List;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.View = View.SmallIcon;
        }

        private void tsb_delete_Click(object sender, EventArgs e)
        {
            deleteFile();
        }

        private void newtextfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.txt";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles())
                {
                    if (item2.Name == newFileName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFileName = "New File";
                    newFileName = newFileName + "(" + cnt + ")" + ".txt";
                }
            }

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream filestream = File.Create(fullPath)) { }

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
                LogError(ex.Message);
            }
        }

        private void newPowerPointFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.pptx";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles())
                {
                    if (item2.Name == newFileName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFileName = "New File";
                    newFileName = newFileName + "(" + cnt + ")" + ".pptx";
                }
            }

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream filestream = File.Create(fullPath)) { }

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
                LogError(ex.Message);
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFolderName = "New Folder";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetDirectories())
                {
                    if (item2.Name == newFolderName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFolderName = "New Folder";
                    newFolderName = newFolderName + "(" + cnt + ")";
                }
            }

            string fullPath = Path.Combine(path, newFolderName);



            try
            {
                Directory.CreateDirectory(fullPath);

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
                LogError(ex.Message);
            }
        }

        private void newWinRarFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.rar";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles())
                {
                    if (item2.Name == newFileName)
                    {
                        cnt++;
                    }
                }
                if (cnt != 0)
                {
                    newFileName = "New File";
                    newFileName = newFileName + "(" + cnt + ")" + ".rar";
                }
            }

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream filestream = File.Create(fullPath)) { }

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
                LogError(ex.Message);
            }
        }

        private void tsb_refresh_Click(object sender, EventArgs e)
        {
            RefreshExplorer();
        }

        private void refreshTreeView()
        {
            treeView1.Nodes.Clear();

            TreeNode favoritesNode = new TreeNode("Favorites");
            treeView1.Nodes.Add(favoritesNode);

            foreach (string favPath in favoritePaths)
            {
                if (File.Exists(favPath))
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(favPath);
                    if (fileIcon != null && !imgl_Drivers.Images.ContainsKey(favPath))
                    {
                        imgl_Drivers.Images.Add(favPath, fileIcon.ToBitmap());
                    }

                    TreeNode favNode = new TreeNode(Path.GetFileName(favPath))
                    {
                        Tag = favPath,
                        ImageKey = favPath,
                        SelectedImageKey = favPath
                    };

                    favoritesNode.Nodes.Add(favNode);
                }
                else { }
            }




            TreeNode parent = new TreeNode("This PC");

            parent.ImageIndex = 0;

            foreach (var item in Environment.GetLogicalDrives())
            {
                try
                {


                    TreeNode son = new TreeNode();
                    DriveInfo driver = new DriveInfo(item);
                    son.Text = driver.Name;

                    switch (driver.DriveType)
                    {
                        case DriveType.Fixed:
                            son.ImageIndex = 1;
                            son.SelectedImageIndex = 1;
                            break;

                        case DriveType.Removable:
                            son.ImageIndex = 2;
                            son.SelectedImageIndex = 2;
                            break;

                        case DriveType.Network:
                            son.ImageIndex = 3;
                            son.SelectedImageIndex = 3;
                            break;

                        case DriveType.CDRom:
                            son.ImageIndex = 4;
                            son.SelectedImageIndex = 4;
                            break;

                        default:
                            son.ImageIndex = 1;
                            son.SelectedImageIndex = 1;
                            break;
                    }
                    string driveLetter = Path.GetPathRoot(driver.Name);
                    string systemDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                    if (driveLetter.Equals(systemDrive, StringComparison.OrdinalIgnoreCase))
                    {
                        son.ImageIndex = 6;
                        son.SelectedImageIndex = 6;
                    }

                    DirectoryInfo dir = new DirectoryInfo(driver.Name);

                    foreach (var directorys in dir.GetDirectories())
                    {
                        try
                        {
                            if (directorys.Attributes.HasFlag(FileAttributes.Hidden))
                            {
                            }
                            else
                            {
                                TreeNode Directory = new TreeNode();
                                Directory.Text = directorys.Name;
                                Directory.Tag = "directorys";
                                Directory.ImageIndex = 5;
                                Directory.SelectedImageIndex = 5;

                                foreach (var subdirecotry in directorys.GetDirectories())
                                {

                                    try
                                    {
                                        if (subdirecotry.Exists)
                                        {
                                            if (subdirecotry.Attributes.HasFlag(FileAttributes.Hidden))
                                            {
                                            }
                                            else
                                            {

                                                TreeNode directoryindir = new TreeNode();
                                                directoryindir.Text = subdirecotry.Name;
                                                directoryindir.Tag = "directorys";
                                                directoryindir.ImageIndex = 5;
                                                directoryindir.SelectedImageIndex = 5;


                                                Directory.Nodes.Add(directoryindir);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogError(ex.Message);
                                    }
                                }

                                son.Nodes.Add(Directory);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError(ex.Message);
                        }
                    }

                    parent.Nodes.Add(son);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }
            treeView1.Nodes.Add(parent);
            favoritesNode.Expand();
            parent.Expand();

        }


        private string GetImageKeyForPath(string path)
        {
            string imageKey = path;

            if (Directory.Exists(path))
            {
                return "folder";
            }
            else if (File.Exists(path))
            {
                try
                {
                    Icon icon = Icon.ExtractAssociatedIcon(path);
                    if (icon != null)
                    {
                        Bitmap iconBitmap = icon.ToBitmap();

                        if (!imgl_Large.Images.ContainsKey(imageKey))
                        {
                            imgl_Large.Images.Add(imageKey, iconBitmap);
                        }


                        if (!imgl_Drivers.Images.ContainsKey(imageKey))
                        {
                            imgl_Drivers.Images.Add(imageKey, iconBitmap);
                        }

                        return imageKey;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
                return "default_file";
            }
            return "unknown";
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFile();
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (treeView1.SelectedNode.Text == "Favorites") { }
                    else
                    {
                        if (treeView1.SelectedNode.Text == "This PC") { }
                        else
                        {
                            if (treeView1.SelectedNode.Parent.Text == "Favorites")
                            {
                                Process.Start(treeView1.SelectedNode.Tag.ToString());
                            }
                            else
                            {

                                if (treeView1.SelectedNode.Parent.Text != "This PC")
                                {
                                    string selectedPath = treeView1.SelectedNode.Parent.FullPath.Remove(0, 7) + @"\" + treeView1.SelectedNode.Text;
                                    NavigateTo(selectedPath);
                                }
                                else
                                {
                                    string selectedPath = treeView1.SelectedNode.Text;
                                    NavigateTo(selectedPath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            string favpath = "";
            var hitTestInfo = treeView1.HitTest(e.Location);
            try
            {
                if (hitTestInfo.Location == TreeViewHitTestLocations.Label || hitTestInfo.Location == TreeViewHitTestLocations.Image)
                {
                    if (hitTestInfo.Node.Parent != null)
                    {
                        favpath = hitTestInfo.Node.Text.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
            finally
            {
                if (e.Button == MouseButtons.Right)
                {

                    if (hitTestInfo.Node != null)
                    {
                        cms_FileOptions.Show(Cursor.Position);
                    }
                    else
                    {

                        cms_GeneralOptions.Show(Cursor.Position);
                    }
                }
                else
                {
                    try
                    {
                        if (Directory.Exists(favpath))
                        {
                            OldPosition.Add(path);
                            ForwardPosition.Clear();
                            path = Path.Combine(favpath + @"\");
                            RefreshExplorer();
                        }
                        else
                        {
                            if (hitTestInfo.Location == TreeViewHitTestLocations.Label || hitTestInfo.Location == TreeViewHitTestLocations.Image)
                            {
                                if (hitTestInfo.Node.Tag.ToString() == "directorys" || hitTestInfo.Node.Tag.ToString() == "disks")
                                {
                                    OldPosition.Add(path);
                                    ForwardPosition.Clear();
                                    path = hitTestInfo.Node.Parent.FullPath.Remove(0, 7) + @"\" + favpath;
                                    RefreshExplorer();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                }
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitTestInfo = treeView1.HitTest(e.Location);
            if (hitTestInfo.Location == TreeViewHitTestLocations.Label || hitTestInfo.Location == TreeViewHitTestLocations.Image && hitTestInfo.Node.Parent != null)
            {
                try
                {
                    string favpath = hitTestInfo.Node.Tag.ToString();
                    if (Directory.Exists(favpath))
                    {
                        path = Path.Combine(favpath + @"\");
                        RefreshExplorer();
                    }
                    else
                    {
                        Process.Start(favpath);

                    }

                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }
        }


        private void tsb_Paste_Click(object sender, EventArgs e)
        {
            PasteFiles(path);
        }

        private void tsb_Cut_Click(object sender, EventArgs e)
        {
            AddToClipboard(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddToClipboard(false);
        }

        private void lvw_FileExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void AddToClipboard(bool cut)
        {
            copiedFilePaths.Clear();
            cutOperation = cut;
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                string fullPath = Path.Combine(path, item.Text);
                copiedFilePaths.Add(fullPath);
            }
        }

        private void PasteFiles(string destinationPath)
        {
            foreach (string sourcePath in copiedFilePaths)
            {
                string destPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));
                if (Directory.Exists(sourcePath))
                {
                    DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
                    DirectoryInfo destDir = new DirectoryInfo(destPath);
                    if (cutOperation)
                    {
                        Directory.Move(sourcePath, destPath);
                    }
                    else
                    {
                        CopyDirectory(sourceDir, destDir);
                    }
                }
                else if (File.Exists(sourcePath))
                {
                    if (cutOperation)
                    {
                        File.Move(sourcePath, destPath);
                    }
                    else
                    {
                        File.Copy(sourcePath, destPath, true);
                    }
                }
            }

            if (cutOperation)
            {
                copiedFilePaths.Clear();
            }
            RefreshExplorer();
        }

        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyDirectory(subDir, nextTargetSubDir);
            }
        }

        private void tsb_Favorite_Click(object sender, EventArgs e)
        {
            AddToFavorite();
        }

        private void AddToFavorite()
        {
            if (lvw_FileExplorer.SelectedItems.Count > 0)
            {
                if (lvw_FileExplorer.SelectedItems.Count > 1)
                {
                    int cnt = 0;
                    foreach (var item in lvw_FileExplorer.SelectedItems)
                    {
                        string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[cnt].Text);
                        if (!favoritePaths.Contains(selectedPath))
                        {
                            favoritePaths.Add(selectedPath);

                        }
                        cnt++;
                    }
                    refreshTreeView();
                }
                else
                {
                    string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);
                    if (!favoritePaths.Contains(selectedPath))
                    {
                        favoritePaths.Add(selectedPath);
                        refreshTreeView();
                    }
                }
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddToClipboard(false);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFiles(path + lvw_FileExplorer.SelectedItems[0].Text);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PasteFiles(path);
        }

        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToFavorite();
        }

        private void tsb_Extract_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lvw_FileExplorer.SelectedItems.Count == 0) { return; }

                string sourceFile = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);

                string destinationPath = path;

                if (!File.Exists(sourceFile)) { return; }

                if (Path.GetExtension(sourceFile).ToLower() != ".zip")
                {
                    try
                    {
                        string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe";
                        if (!File.Exists(winRarPath))
                        {
                            MessageBox.Show("Não tem WinRAR instalado no seu computador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Process process = new Process();
                        process.StartInfo.FileName = winRarPath;
                        process.StartInfo.Arguments = $"x \"{sourceFile}\" \"{destinationPath}\" -y";

                        process.Start();
                        process.WaitForExit();

                        if (process.ExitCode == 0) { }
                        else { }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                    RefreshExplorer();
                    return;
                }

                ZipFile.ExtractToDirectory(sourceFile, destinationPath);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

            RefreshExplorer();

        }

        private void tsb_Compress_Click(object sender, EventArgs e)
        {

        }


        private void LogError(string message)
        {
            if (File.Exists(logspath))
            {
                string error = File.ReadAllText(logspath) + "Ocorreu um Erro inesperado: " + "\n" + message + DateTime.Now + "\n";

                using (StreamWriter writetext = new StreamWriter("Logs.txt"))
                {
                    writetext.WriteLine(error);
                }
            }
            else
            {

                using (FileStream filestream = File.Create(logspath)) { }

                string error = File.ReadAllText(logspath) + "Ocorreu um Erro inesperado: " + "\n" + message + DateTime.Now + "\n";



                using (StreamWriter writetext = new StreamWriter("Logs.txt"))
                {
                    writetext.WriteLine(error);
                }
            }
        }

        private void compressAsWinRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvw_FileExplorer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo ou pasta selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe";
            if (!File.Exists(winRarPath))
            {
                MessageBox.Show("WinRAR não está instalado no seu computador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string rarFileName = $"{lvw_FileExplorer.SelectedItems[0].Text}.rar";
            string destinationPath = $"{path}\\{rarFileName}";

            StringBuilder fileList = new StringBuilder();
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                string sourcePath = path + @"\" + item.Text;
                if (!File.Exists(sourcePath) && !Directory.Exists(sourcePath))
                {
                    MessageBox.Show($"O caminho não existe: {sourcePath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                fileList.Append($"\"{sourcePath}\" ");
            }

            // -ep1 para retirar o caminho do completo do diretório
            string arguments = $"a -ep1 -r \"{destinationPath}\" {fileList.ToString()}";

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = winRarPath;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

            RefreshExplorer();
        }

        private void lvw_FileExplorer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            FileInfo file = new FileInfo(path + e.Item.Text);
            if (file.Extension == ".rar")
            {
                tsb_Extract.Visible = true;
            }
            else
            {
                tsb_Extract.Visible = false;
            }
        }

        private void compressAsZIPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string zipFileName = lvw_FileExplorer.SelectedItems[0].Text + ".zip";
            string destinationZipPath = Path.Combine(path, zipFileName);

            using (FileStream zipToOpen = new FileStream(destinationZipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
                    {
                        string sourcePath = Path.Combine(path, item.Text);

                        if (Directory.Exists(sourcePath))
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);
                            AddDirectoryToZip(archive, dirInfo, Path.GetFileName(sourcePath));
                        }
                        else if (File.Exists(sourcePath))
                        {
                            archive.CreateEntryFromFile(sourcePath, Path.GetFileName(sourcePath));
                        }
                    }
                }
            }
            
            RefreshExplorer();
        }


        private void AddDirectoryToZip(ZipArchive archive, DirectoryInfo dirInfo, string relativePath)
        {
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string entryName = Path.Combine(relativePath, file.Name);
                archive.CreateEntryFromFile(file.FullName, entryName, CompressionLevel.Optimal);
            }

            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                string tempPath = Path.Combine(relativePath, subdir.Name);
                AddDirectoryToZip(archive, subdir, tempPath);
            }
        }
    }

}