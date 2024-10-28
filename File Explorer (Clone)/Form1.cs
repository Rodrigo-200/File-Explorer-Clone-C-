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

namespace File_Explorer__Clone_
{
    public partial class Form1 : Form
    {
        string path = Environment.CurrentDirectory + @"\";
        string recent = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "Microsoft" + @"\" + "Windows" + @"\" + "Recent";
        List<string> OldPosition = new List<string>();
        List<string> ForwardPosition = new List<string>();
        private List<string> favoritePaths = new List<string>();
        bool Show_Hidden = false;

        private List<string> copiedFilePaths = new List<string>();
        private bool cutOperation = false; // To distinguish between cut and copy

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
            txt_Path.Text = path; //Mostra o path
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var item in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
            {
                try
                {
                    if (!Show_Hidden)
                    {
                        if (item.Attributes.HasFlag(FileAttributes.Hidden))
                        {

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
                    MessageBox.Show(ex.Message);
                }

               _Type.Text = GetFileTypeDescription(item.FullName);



                listViewItem.SubItems.Add(Mod_date);
                listViewItem.SubItems.Add(_Type);
                listViewItem.SubItems.Add(Size);

                lvw_FileExplorer.Items.Add(listViewItem);
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
            if (OldPosition.Count > 0)
            {
                ForwardPosition.Add(path); // Store current path for forward navigation
                path = OldPosition.Last();  // Set path to the last element in the OldPosition list
                OldPosition.RemoveAt(OldPosition.Count - 1);  // Remove the last element from OldPosition
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
            }
        }

        private void btn_Foward_Click(object sender, EventArgs e)
        {
            if (ForwardPosition.Count > 0)
            {
                OldPosition.Add(path); // Add current path back to OldPosition for possible back navigation
                path = ForwardPosition.Last();  // Move to the last forward path
                ForwardPosition.RemoveAt(ForwardPosition.Count - 1);  // Remove the last element from ForwardPosition
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
        { }

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
                foreach (var item2 in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path"
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
            }
        }

        private void addNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFolderName = "New Folder";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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

            if (e.Button == MouseButtons.XButton2)
            {
                if (ForwardPosition.Count > 0)
                {
                    OldPosition.Add(path); // Add current path back to OldPosition for possible back navigation
                    path = ForwardPosition.Last();  // Move to the last forward path
                    ForwardPosition.RemoveAt(ForwardPosition.Count - 1);  // Remove the last element from ForwardPosition
                    RefreshExplorer();
                }
            }

            if (e.Button == MouseButtons.XButton1)
            {
                if (OldPosition.Count > 0)
                {
                    ForwardPosition.Add(path); // Store current path for forward navigation
                    path = OldPosition.Last();  // Set path to the last element in the OldPosition list
                    OldPosition.RemoveAt(OldPosition.Count - 1);  // Remove the last element from OldPosition
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
                            MessageBox.Show(ex.Message);
                            throw;
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
                            MessageBox.Show(ex.Message);
                            throw;
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
            if (e.KeyCode == Keys.Enter)
            {
                string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);
                NavigateTo(selectedPath);
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
            OldPosition.Add(path);  // Add current path to back navigation history
            path = newPath;  // Update path
            ForwardPosition.Clear();  // Clear forward history since a new path has been taken
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
                foreach (var item2 in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path"
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
            }
        }

        private void newPowerPointFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.pptx";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path"
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
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFolderName = "New Folder";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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
            }
        }

        private void newWinRarFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string newFileName = "New File.rar";

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (ListViewItem item in lvw_FileExplorer.Items)
            {
                foreach (var item2 in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path"
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

            /*
             * Corrigir!!!!!!!!!!!
             * Contem
             * Bugs
             * e erros 
             */
            foreach (string favPath in favoritePaths)
            {
                TreeNode favNode = new TreeNode(Path.GetFileName(favPath))
                {
                    Tag = favPath,
                    ImageKey = GetImageKeyForPath(favPath),
                    SelectedImageKey = GetImageKeyForPath(favPath)
                };

                if (Directory.Exists(favPath)) 
                {
                    favNode.ImageIndex = 5;
                    DirectoryInfo dir = new DirectoryInfo(favPath);
                    foreach (var directorys in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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



                                foreach (var subdirecotry in directorys.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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
                                        MessageBox.Show(ex.Message);
                                        throw;
                                    }
                                }

                                favoritesNode.Nodes.Add(Directory);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }


                }


                favoritesNode.Nodes.Add(favNode);


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
                    son.Tag = "disks";
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

                    DirectoryInfo dir = new DirectoryInfo(driver.Name);

                    foreach (var directorys in dir.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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



                                foreach (var subdirecotry in directorys.GetDirectories()) // Vai a cada diretorio dentro do diretorio "path"
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
                                        MessageBox.Show(ex.Message);
                                        throw;
                                    }
                                }

                                son.Nodes.Add(Directory);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }


                    parent.Nodes.Add(son);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            treeView1.Nodes.Add(parent);
            favoritesNode.Expand();
            parent.Expand();

        }


        private string GetImageKeyForPath(string path)
        {
            string imageKey = path; // Unique key based on the path

            if (Directory.Exists(path))
            {
                return "folder";  // A default icon key for folders
            }
            else if (File.Exists(path))
            {
                try
                {
                    Icon icon = Icon.ExtractAssociatedIcon(path);
                    if (icon != null)
                    {
                        Bitmap iconBitmap = icon.ToBitmap();

                        // Add to ListView ImageList if not present
                        if (!imgl_Large.Images.ContainsKey(imageKey))
                        {
                            imgl_Large.Images.Add(imageKey, iconBitmap);
                        }

                        // Also add to TreeView ImageList
                        if (!imgl_Drivers.Images.ContainsKey(imageKey))
                        {
                            imgl_Drivers.Images.Add(imageKey, iconBitmap);
                        }

                        return imageKey;
                    }
                }
                catch
                {
                    // Log or handle exceptions as needed
                }
                return "default_file";  // Default file icon if extraction fails
            }
            return "unknown";  // Default for unknown file types
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFile();
            }
            if (e.KeyCode == Keys.Enter)
            {
                string selectedPath = treeView1.SelectedNode.FullPath.Remove(0, 7);
                NavigateTo(selectedPath);
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
                        favpath = hitTestInfo.Node.Tag.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
                            path = Path.Combine(favpath + @"\");
                            RefreshExplorer();
                        }
                        else
                        {
                            if (hitTestInfo.Location == TreeViewHitTestLocations.Label || hitTestInfo.Location == TreeViewHitTestLocations.Image)
                            {
                                if (hitTestInfo.Node.Tag.ToString() == "directorys" || hitTestInfo.Node.Tag.ToString() == "disks")
                                {
                                    path = Path.Combine(path, treeView1.HitTest(e.Location).Node.FullPath.Remove(0, 7) + @"\");
                                    RefreshExplorer();
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitTestInfo = treeView1.HitTest(e.Location);
            string favpath = hitTestInfo.Node.Tag.ToString();
            if (hitTestInfo.Location == TreeViewHitTestLocations.Label || hitTestInfo.Location == TreeViewHitTestLocations.Image)
            {
                try
                {
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
                    MessageBox.Show(ex.Message);
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
                    foreach(var item in lvw_FileExplorer.SelectedItems)
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
    }

}

