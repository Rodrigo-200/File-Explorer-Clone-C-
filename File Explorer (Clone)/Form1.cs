using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace File_Explorer__Clone_
{
    public partial class Form1 : Form
    {
        #region Inicialização de variaveis 

        string path = Environment.CurrentDirectory + @"\";
        string logspath = Environment.CurrentDirectory + @"\" + "Logs.txt";

        List<string> OldPosition = new List<string>();
        List<string> ForwardPosition = new List<string>();
        private List<string> favoritePaths = new List<string>();
        bool Show_Hidden = false;

        private List<string> copiedFilePaths = new List<string>();
        private bool cutOperation = false;

        #endregion

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
            RefreshTreeView();
        }

        #region Eventos Keypress

        private void txt_Path_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica se a tecla primida é o Enter e se for muda o path para o texto que está na textbox e reencaminha o user até esse caminho
            if (e.KeyChar == (char)Keys.Enter)
            {
                NavigateTo(txt_Path.Text.Trim());
            }
        }
        #endregion

        #region Eventos MouseDown

        private void lvw_FileExplorer_MouseDown(object sender, MouseEventArgs e)
        {
            //Se o botão do rato primido for o direito
            if (e.Button == MouseButtons.Right)
            {
                //Cria uma variavel hittest para verificar varias coisas sobre o local onde o utilizador carregou
                var hitTestInfo = lvw_FileExplorer.HitTest(e.Location);

                //Se o local onde o utilizador carregou é um item
                if (hitTestInfo.Item != null)
                {
                    //Se o item onde o utilizador carregou estiver na lista de ficheiros favoritos
                    if (favoritePaths.Contains(Path.Combine(path, hitTestInfo.Item.Text)))
                    {
                        //Muda o texto to item "Add to favorites" do contextmenustrip para "Remove from favorite" e do botão do toolstrip
                        cms_FileOptions.Items[5].Text = "Remove from favorite";
                        tsb_Favorite.Text = "Remove from favorite";
                    }
                    else
                    {
                        //Se nao existir na lista de ficheiros favoritos mantem ou altera o texto to item "Add to favorites" do contextmenustrip para "Add to favorites"
                        cms_FileOptions.Items[5].Text = "Add to favorites";
                        tsb_Favorite.Text = "Add to favorites";
                    }
                    cms_FileOptions.Show(Cursor.Position); //Mostra o contextmenustrip com as opções dos ficheiros na posição do rato
                }
                else
                {
                    //Se o local onde o utilizador carregou não for um item mostra as opções gerais como adicionar um novo ficheiros etc..
                    cms_GeneralOptions.Show(Cursor.Position);
                }
            }

            //Se for o o botão 2 do rato (os botões laterais do rato)  anda para a frente uma posição ( como se o utilizador pressiona-se no botão de andar para a frente )
            if (e.Button == MouseButtons.XButton2)
            {
                if (ForwardPosition.Count > 0)
                {
                    OldPosition.Add(path); //Adiciona-se o caminho atual à lista que armazena os caminhos para andar para trás
                    path = ForwardPosition.Last();
                    ForwardPosition.RemoveAt(ForwardPosition.Count - 1);
                    RefreshExplorer(); // Após alterar o caminho com o da lista faz se a atualização da lisview
                }
            }

            //Se for o o botão 1 do rato (os botões laterais do rato)  anda para a trás uma posição ( como se o utilizador pressiona-se no botão de andar para trás )
            if (e.Button == MouseButtons.XButton1)
            {
                if (OldPosition.Count > 0)
                {
                    ForwardPosition.Add(path); //Adiciona-se o caminho atual à lista que armazena os caminhos para andar para a frente 
                    path = OldPosition.Last();
                    OldPosition.RemoveAt(OldPosition.Count - 1);
                    RefreshExplorer(); //Após alterar o caminho com o da lista faz se a atualização da lisview
                }
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //Cria uma variavel hittest para verificar varias coisas sobre o local onde o utilizador carregou
            var hitTestInfo = tvw_Disks.HitTest(e.Location);

            //Se o botão pressionado for o esquedo reencaminha-se o utilizador ao diretório pressionado
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (hitTestInfo.Location == TreeViewHitTestLocations.Label ||
                        hitTestInfo.Location == TreeViewHitTestLocations.Image)
                    {
                        if (hitTestInfo.Node.ImageIndex == 5 ||
                            hitTestInfo.Node.ImageIndex == 1 ||
                            hitTestInfo.Node.ImageIndex == 2 ||
                            hitTestInfo.Node.ImageIndex == 3 ||
                            hitTestInfo.Node.ImageIndex == 4 ||
                            hitTestInfo.Node.ImageIndex == 6)
                        {
                            OldPosition.Add(path);
                            ForwardPosition.Clear();

                            path = hitTestInfo.Node.Tag.ToString();
                            RefreshExplorer();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }
        }

        #endregion

        #region Eventos DoubleClick
        private void lvw_FileExplorer_DoubleClick(object sender, EventArgs e)
        {
            //Se o item pressionado for uma pasta vai navegar até ao caminho dessa pasta
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
            //Se for um ficheiro irá abrir o ficheiro começando um processo
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

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Igual ao double click da ListView Se for uma pasta irá navegar até à pasta se não irá abrir o ficheiro
            var hitTestInfo = tvw_Disks.HitTest(e.Location);
            if (hitTestInfo.Location == TreeViewHitTestLocations.Label ||
                hitTestInfo.Location == TreeViewHitTestLocations.Image && hitTestInfo.Node.Parent != null)
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
        #endregion

        #region Eventos Click

        private void tsb_Rename_Click(object sender, EventArgs e)
        {
            lvw_FileExplorer.SelectedItems[0].BeginEdit(); //Começa a edição do nome do ficheiro/diretório
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            //Ao carregar no botão de andar para trás navega um diretório para trás na se existir algum na lista
            if (OldPosition.Count > 0)
            {
                ForwardPosition.Add(path);
                path = OldPosition.Last();
                OldPosition.RemoveAt(OldPosition.Count - 1); // Remove o diretorio atual da lista para evitar repitições
                RefreshExplorer();
            }
        }

        private void btn_Foward_Click(object sender, EventArgs e)
        {
            //Ao carregar no botão de andar para a frente navega um diretório para a frente na se existir algum na lista
            if (ForwardPosition.Count > 0)
            {
                OldPosition.Add(path);
                path = ForwardPosition.Last();
                ForwardPosition.RemoveAt(ForwardPosition.Count - 1); // Remove o diretorio atual da lista para evitar repitições
                RefreshExplorer();
            }
        }

        private void btn_GoUpOneLevel_Click(object sender, EventArgs e)
        {
            //Ao carregar no botão de andar para trás um nivel navega um diretório para "cima" se existir algum na lista
            if (Directory.GetParent(path) != null)
            {
                OldPosition.Add(path);
                path = new DirectoryInfo(path).Parent.FullName + @"\";
                RefreshExplorer();
            }
        }

        private void addNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFile();
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
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                item.BackColor = Color.LightGray;
            }
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
            CreateNewFile("txt");
        }

        private void newPowerPointFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile("pptx");
        }

        private void addNewTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile("txt");
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder();
        }

        private void newWinRarFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile("rar");
        }

        private void tsb_refresh_Click(object sender, EventArgs e)
        {
            RefreshExplorer();
        }

        private void tsb_Paste_Click(object sender, EventArgs e)
        {
            PasteFiles(path);
        }

        private void tsb_Cut_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                item.BackColor = Color.LightGray;
            }
            AddToClipboard(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddToClipboard(false);
        }

        private void tsb_Favorite_Click(object sender, EventArgs e)
        {
            AddToFavorite();
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
            //No click do botão tsb_Extract é estraido os ficheiros/diretorios de um ficheiro ".rar" se for um ficheiro ".rar" se não, extrai como se fosse um ficheiro ".zip"
            try
            {
                if (lvw_FileExplorer.SelectedItems.Count == 0)
                {
                    return;
                }

                string sourceFile = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);

                string destinationPath = path;

                if (!File.Exists(sourceFile))
                {
                    return;
                }

                if (Path.GetExtension(sourceFile).ToLower() != ".zip")
                {
                    try
                    {
                        string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe";
                        if (!File.Exists(winRarPath))
                        {
                            MessageBox.Show("Não tem WinRAR instalado no seu computador", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        Process process = new Process();
                        process.StartInfo.FileName = winRarPath;
                        process.StartInfo.Arguments = $"x \"{sourceFile}\" \"{destinationPath}\" -y";

                        process.Start();
                        process.WaitForExit();
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

        private void compressAsWinRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Comprime ficheiros/Diretorios como um ficheiro ".rar"
            if (lvw_FileExplorer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo ou pasta selecionado.", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe";
            if (!File.Exists(winRarPath))
            {
                MessageBox.Show("WinRAR não está instalado no seu computador.", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    MessageBox.Show($"O caminho não existe: {sourcePath}", "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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


        private void compressAsZIPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No click do item compressAsZIPFile comprime os ficheiros selecionados como um ficheiro ".zip"
            string zipFileName = lvw_FileExplorer.SelectedItems[0].Text + ".zip";
            string destinationZipPath = Path.Combine(path, zipFileName);

            using (FileStream zipToOpen = new FileStream(destinationZipPath, FileMode.Create))
            {
                using (ZipArchive directory = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
                    {
                        string sourcePath = Path.Combine(path, item.Text);

                        if (Directory.Exists(sourcePath))
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);
                            AddDirectoryToZip(directory, dirInfo, Path.GetFileName(sourcePath));
                        }
                        else if (File.Exists(sourcePath))
                        {
                            directory.CreateEntryFromFile(sourcePath, Path.GetFileName(sourcePath));
                        }
                    }
                }
            }

            RefreshExplorer();
        }

        #endregion

        #region Eventos KeyDown
       
        private void lvw_FileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            //Se for a tecla F2 começa a editar o nome do ficheiro selecionado
            if (e.KeyCode == Keys.F2)
            {
                foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
                {
                    item.BeginEdit();
                    break;
                }
            }

            //Ao carregar em uma tecla se for a tecla delete elimina o ficheiro selecionado
            if (e.KeyCode == Keys.Delete)
            {
                deleteFile();
            }

            //Se for a tecla enter abre o ficheiro ou navega até ao diretorio selecionado
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

            //Se for ctrl+c copia o ficheiro x faz cut do ficheiro se for A seleciona todos os ficheiro se for V faz paste dos ficheiros
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
                foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
                {
                    item.BackColor = Color.LightGray;
                }
                AddToClipboard(true);
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem item in lvw_FileExplorer.Items)
                {
                    item.Selected = true;
                }
            }

            //Ctrl + L ou Alt + D faz focus da textbox Path
            if (e.Control && e.KeyCode == Keys.L || e.Alt && e.KeyCode == Keys.D)
            {
                txt_Path.Focus();
            }

            //Se for a tecla F5 faz o refresh da ListView
            if (e.KeyCode == Keys.F5)
            {
                RefreshExplorer();
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Ao carregar em uma tecla dentro da treeview se for o enter entra no diretorio ou abre um ficheiros dos favoritos

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tvw_Disks.SelectedNode.Text == "Favorites")
                    {
                    }
                    else
                    {
                        if (tvw_Disks.SelectedNode.Text == "This PC")
                        {
                        }
                        else
                        {
                            if (tvw_Disks.SelectedNode.Parent.Text == "Favorites")
                            {
                                Process.Start(tvw_Disks.SelectedNode.Tag.ToString());
                            }
                            else
                            {
                                if (tvw_Disks.SelectedNode.Parent.Text != "This PC")
                                {
                                    string selectedPath = tvw_Disks.SelectedNode.Tag.ToString();
                                    NavigateTo(selectedPath);
                                }
                                else
                                {
                                    string selectedPath = tvw_Disks.SelectedNode.Text;
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
        #endregion

        #region Evento MouseClick
        private void lvw_FileExplorer_MouseClick(object sender, MouseEventArgs e)
        {
            //Ao carregar num ficheiro se a extenção for ".rar" mostra-sw o botão tsb_Extract
            FileInfo file = new FileInfo(path + lvw_FileExplorer.SelectedItems[0].Text);
            if (file.Extension == ".rar")
            {
                tsb_Extract.Visible = true;
            }
            else
            {
                tsb_Extract.Visible = false;
            }

            //Se for um Diretorio desliga os botões de adicionar como favorito se mão mantem os botões ligados
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
        #endregion

        #region Refresh ListView/TreeView

        /// <summary>
        /// Metodo Responsavel por fazer o refresh da ListView e adicionar os diretorios na ListView
        /// </summary>
        private void RefreshExplorer()
        {
            //Limpa os items todos da lvw para evitar repitições
            lvw_FileExplorer.Items.Clear();
            txt_Path.Text = path; //Atualiza o caminho da textbox
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                //Percorre todos os diretorios e mostra na ListView os ficheiros e diretorios dentro do diretorio do caminho (path)
                foreach (var item in dir.GetDirectories())
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
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                }
                //Percorre os ficheiros para os adicionar na ListView do caminho (path)
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
                        listViewItem.ImageKey = GetImageKeyForPath(filePath);
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

        /// <summary>
        /// Metodo Responsavel por fazer o refresh da Treeview e adicionar os diretorios como nós da TreeView
        /// </summary>
        private void RefreshTreeView()
        {
            //Limpa todos os nos da TreeView 
            tvw_Disks.Nodes.Clear();

            // Adiciona o no Favoritos à Treeview
            TreeNode favoritesNode = new TreeNode("Favorites");
            favoritesNode.ImageIndex = 7;
            favoritesNode.SelectedImageIndex = 7;
            tvw_Disks.Nodes.Add(favoritesNode);

            // Adiciona os caficheiros favoritos ao no favoritos
            foreach (string favPath in favoritePaths)
            {
                if (File.Exists(favPath))
                {

                    //Cria um no com o ficheiro correspondente da Lista
                    TreeNode favNode = new TreeNode(Path.GetFileName(favPath))
                    {
                        Tag = favPath,
                        ImageKey = GetImageKeyForPath(favPath),
                        SelectedImageKey = GetImageKeyForPath(favPath),
                    };

                    favoritesNode.Nodes.Add(favNode);
                }
            }

            // Adiciona o nó parent com o texto (This PC)
            TreeNode parent = new TreeNode("This PC");
            parent.ImageIndex = 0;

            // Adiciona todos os discos ao no "Parent" ("This PC")
            foreach (var item in Environment.GetLogicalDrives())
            {
                try
                {
                    DriveInfo driver = new DriveInfo(item);
                    TreeNode disk = new TreeNode(driver.Name);
                    disk.Tag = driver.Name;

                    // Muda o icon do no com a sua imagem corrspondente
                    switch (driver.DriveType)
                    {
                        case DriveType.Fixed:
                            disk.ImageIndex = 1;
                            disk.SelectedImageIndex = 1;
                            break;
                        case DriveType.Removable:
                            disk.ImageIndex = 2;
                            disk.SelectedImageIndex = 2;
                            break;
                        case DriveType.Network:
                            disk.ImageIndex = 3;
                            disk.SelectedImageIndex = 3;
                            break;
                        case DriveType.CDRom:
                            disk.ImageIndex = 4;
                            disk.SelectedImageIndex = 4;
                            break;
                        default:
                            disk.ImageIndex = 1;
                            disk.SelectedImageIndex = 1;
                            break;
                    }

                    // Muda a imagem do disco que contem a instalação do windows 
                    string driveLetter = Path.GetPathRoot(driver.Name);
                    string systemDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                    if (driveLetter.Equals(systemDrive, StringComparison.OrdinalIgnoreCase))
                    {
                        disk.ImageIndex = 6;
                        disk.SelectedImageIndex = 6;
                    }

                    DirectoryInfo dir = new DirectoryInfo(driver.Name);
                    foreach (var directory in dir.GetDirectories())
                    {
                        if (!directory.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            TreeNode directoryNode = new TreeNode(directory.Name)
                            {
                                Tag = directory.FullName, //Guarda o caminho total do diretorio
                                ImageIndex = 5,
                                SelectedImageIndex = 5
                            };
                            // Adiciona-se um nó para que apareça o botão de expandir
                            if (directory.GetDirectories().Length != 0)
                            {
                                directoryNode.Nodes.Add(new TreeNode("Loading..."));
                            }
                            disk.Nodes.Add(directoryNode);
                        }
                    }

                    parent.Nodes.Add(disk); //Adiciona o nó do disk ao no "parent" que contem o texto "This PC" 
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }

            tvw_Disks.Nodes.Add(parent); //Adiciona o nó parent (This PC) à treeview 
            //Expande o nó favoritesNode e o parent
            favoritesNode.Expand(); 
            parent.Expand();
        }
        #endregion

        #region Evento AfterLabelEdit
        private void lvw_FileExplorer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //Se nao houver texto cancela a edição
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            //Se não, muda o nome do ficheiro com o novo nome que o utilizador alterou
            string originalFullPath = Path.Combine(path, lvw_FileExplorer.Items[e.Item].Text);
            string newFullPath = Path.Combine(path, e.Label);

            try
            {
                if (lvw_FileExplorer.FocusedItem.ImageIndex != 0)
                {
                        File.Move(originalFullPath, newFullPath);
                }
                else
                {
                    Directory.Move(lvw_FileExplorer.SelectedItems[0].Text, e.Label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true; //Em caso e erro cancela a edição da label
                LogError(ex.Message);
            }
        }
        #endregion

        #region Evento TextChanged

        private void txt_Path_TextChanged(object sender, EventArgs e)
        {
            //Ao alterar o texto da TextBox muda a variavel global path com o texto
            path = txt_Path.Text;
        }

        #endregion

        #region AddDirectoryToZip
        /// <summary>
        /// Adiciona um diretorio a um ficheiro ".zip"
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="dirInfo"></param>
        /// <param name="relativePath"></param>
        private void AddDirectoryToZip(ZipArchive directory, DirectoryInfo dirInfo, string relativePath)
        {
            //Adiciona o diretorio/ficheiro a um ficheiro zip

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                string entryName = Path.Combine(relativePath, file.Name);
                directory.CreateEntryFromFile(file.FullName, entryName, CompressionLevel.Optimal);
            }

            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                string tempPath = Path.Combine(relativePath, subdir.Name);
                AddDirectoryToZip(directory, subdir, tempPath);
            }
        }

        #endregion

        #region ItemSelectionChanged

        private void lvw_FileExplorer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //Quando o item selecionado muda verifica se é um .rar e liga um botão de estrair ficheiros .rar
            FileInfo file = new FileInfo(path + e.Item.Text);
            if (file.Extension == ".rar")
            {
                tsb_Extract.Visible = true;
            }
            else
            {
                tsb_Extract.Visible = false;
            }

            if (lvw_FileExplorer.SelectedItems.Count == 1)
            {
                tsb_Rename.Visible = true;
            }
            else
            {
                tsb_Rename.Visible = false;
            }

        }

        #endregion

        #region LogError

        /// <summary>
        /// Metodo para fazer um log de um erro que tenha occorido no programa para que mais tarde se o utilizador quiser saber possa ver o que aconteceu
        /// </summary>
        /// <param name="message">String que recebe a mensagem de erro a "logar" no ficheiro</param>
        private void LogError(string message)
        {
            //Verifica se o ficheiro já existe e se não existir cria-se um novo
            if (File.Exists(logspath))
            {
                string error = File.ReadAllText(logspath) + "Ocorreu um Erro inesperado: " + "\n" + message + //Adiciona a mensagem de erro a data e hora a que o erro ocorreu
                               DateTime.Now + "\n";

                //Escreve no ficheiro a mensagem de erro
                using (StreamWriter writetext = new StreamWriter("Logs.txt"))
                {
                    writetext.WriteLine(error);
                }
            }
            else
            {
                //Se o ficheiro não existe cria e escreve a mensagem
                using (FileStream filestream = File.Create(logspath))
                {
                }

                string error = File.ReadAllText(logspath) + "Ocorreu um Erro inesperado: " + "\n" + message +
                               DateTime.Now + "\n";


                using (StreamWriter writetext = new StreamWriter("Logs.txt"))
                {
                    writetext.WriteLine(error);
                }
            }
        }

        #endregion

        #region AddToFavorite

        /// <summary>
        /// Adiciona o(s) ficheiro(s) selecionado(s) à lista de ficheiros favoritos
        /// </summary>
        private void AddToFavorite()
        {
            //Se o texto do botão pressionado for Remove... retira da lista o ficheiro selecionado
            //Se for Add... adiciona o ficheiro selecionado à lista de ficheiros favoritos

            if (cms_FileOptions.Items[5].Text == "Remove from favorite" || tsb_Favorite.Text == "Remove from favorite")
            {
                int cnt = 0;
                foreach (var item in lvw_FileExplorer.SelectedItems)
                {
                    string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[cnt].Text);
                    favoritePaths.Remove(selectedPath);

                    cnt++;
                }
                RefreshTreeView();
            }
            else
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

                        RefreshTreeView();
                    }
                    else
                    {
                        string selectedPath = Path.Combine(path, lvw_FileExplorer.SelectedItems[0].Text);
                        if (!favoritePaths.Contains(selectedPath))
                        {
                            favoritePaths.Add(selectedPath);
                            RefreshTreeView();
                        }
                    }
                }
            }
        }

        #endregion

        #region Copy/Pate/Cut/Delete

        /// <summary>
        /// Metodo que adiciona um ficheiro/diretorio à "clipboard"
        /// </summary>
        /// <param name="cut">Variavel do tipo bool para saber se é uma operação cut ou não</param>
        private void AddToClipboard(bool cut)
        {
            copiedFilePaths.Clear();
            cutOperation = cut; //Muda a variavel global dependendo do valor de cut
            
            //Precorre todos os item selecionados e adiciona à "clipboard"
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                string fullPath = Path.Combine(path, item.Text);
                copiedFilePaths.Add(fullPath);
            }
        }

        /// <summary>
        /// Metodo para colar ficheiros num determinado caminho
        /// </summary>
        /// <param name="destinationPath">Variavel correpondente ao caminho no qual se devem colar os ficheiros</param>
        private void PasteFiles(string destinationPath)
        {
            //Precorre todos os ficheiros dentro da "clipboard" e cola no caminho "destinationPath"
            foreach (string sourcePath in copiedFilePaths)
            {
                string destPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));
                //Se for um diretorio e cut faz move se não chama o metodo "CopyDirectorys"
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
                //Se o ficheiro já existe se for uma cut operation faz move do ficheiro copiado com o do caminho a colar o ficheiro se nao copia e dá replace
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
            //Se for uma operação de cut após colar os ficheiros limpa a "clipboard"
            if (cutOperation)
            {
                copiedFilePaths.Clear();
            }

            RefreshExplorer();
        }

        /// <summary>
        /// Metodo Recursivo para copiar ficheiros de um diretorio, percorre todos os diretorios e ficheiros do diretorio copiado e faz paste no caminho pretendido
        /// </summary>
        /// <param name="source">Variavel com o caminho do ficheiro copiado</param>
        /// <param name="target">Variavel com o caminho para onde o ficheiro deve ser copiado</param>
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

        /// <summary>
        /// Metodo para apagar ficheiros selecionados
        /// </summary>
        private void deleteFile()
        {

            //Verifica se o ficheiro existe e se existir apagar se for um diretorio apaga o diretorio e todos os ficheiros/diretorios dentro

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

        #endregion

        #region Evento SelectedIndexChanged

        private void lvw_FileExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Quando se muda o index selecionado verifica-se se está na lista de favoritos e se estiver muda o texto ddo item 5 "Add to favorites" para "Remove from favorite"
            foreach (ListViewItem item in lvw_FileExplorer.SelectedItems)
            {
                if (favoritePaths.Contains(Path.Combine(path, item.Text)))
                {
                    cms_FileOptions.Items[5].Text = "Remove from favorite";
                    tsb_Favorite.Text = "Remove from favorite";
                }
                else
                {
                    cms_FileOptions.Items[5].Text = "Add to favorites";
                    tsb_Favorite.Text = "Add to favorites";
                }
            }
        }

        #endregion

        #region GetImageKeyForPath

        /// <summary>
        /// Metodo para estrair o icon de um ficheiro
        /// </summary>
        /// <param name="path">Recebe uma string com o caminho do ficheiro</param>
        /// <returns>A ImageKey correspondente ao icon do ficheiro</returns>
        private string GetImageKeyForPath(string path)
        {
            try
            {
                Icon icon = Icon.ExtractAssociatedIcon(path);

                if (icon != null)
                {
                    Bitmap iconBitmap = icon.ToBitmap();

                    string imageKey = path;

                    //Se a imgl_Large ainda não tiver a imagem adiciona
                    if (!imgl_Large.Images.ContainsKey(imageKey))
                    {
                        imgl_Large.Images.Add(imageKey, iconBitmap);
                    }

                    //Se a imgl_Small ainda não tiver a imagem adiciona
                    if (!imgl_Small.Images.ContainsKey(imageKey))
                    {
                        imgl_Small.Images.Add(imageKey, iconBitmap);
                    }

                    //Se a imgl_Drivers ainda não tiver a imagem adiciona
                    if (!imgl_Drivers.Images.ContainsKey(imageKey))
                    {
                        imgl_Drivers.Images.Add(imageKey, iconBitmap);
                    }
                    return imageKey;
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

            return "default_file";
        }
        #endregion

        #region Load recursivo a diretorios na treeview

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //Guarda numa variavel do tipo TreeNode 
            TreeNode node = e.Node;

            //Se tiver o texto "Loading..." e chama o metodo recursivo LoadDirecotries para mostrar os diretorios todos dentro de um diretorio
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "Loading...")
            {
                node.Nodes.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo((string)node.Tag);
                LoadDirectories(node, directoryInfo);
            }
        }


        private void LoadDirectories(TreeNode node, DirectoryInfo directoryInfo)
        {
            try
            {
                //Precorre cada diretorio e os seus respetivos diretorios
                foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                {

                    if (!subdir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        TreeNode subNode = new TreeNode(subdir.Name)
                        {
                            Tag = subdir.FullName, // Store the full path
                            ImageIndex = 5,
                            SelectedImageIndex = 5
                        };
                        // Adiciona um nó com o texto "Loading..." para mostrar o botão de expandir o nó
                        if (subdir.GetDirectories().Length != 0)
                        {
                            subNode.Nodes.Add(new TreeNode("Loading..."));
                        }

                        node.Nodes.Add(subNode);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Failed to load directories from {directoryInfo.FullName}: {ex.Message}");
            }
        }

        #endregion

        #region Evento ColumnClick

        private void lvw_FileExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Utiliza a classe lvwColumnSorter para ordenar os ficheiros por nome, data de modificação, e extenção (retirado do site oficial da microsoft)
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
            //Usa o metodo Sort para ordenar
            this.lvw_FileExplorer.Sort();
        }

        #endregion

        #region GetFileTypeDescription

        /// <summary>
        /// Altera a extenção para Maiusculas e file a frente.
        /// </summary>
        /// <param name="filePath">Recebe uma string que corresponde ao caminho do ficheiro</param>
        /// <returns>A extenção em Maiusculas + "file"</returns>
        private string GetFileTypeDescription(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return Path.GetExtension(filePath).TrimStart('.').ToUpper() + " File";
        }

        #endregion

        #region CreateNewFile

        /// <summary>
        /// Metodo para criar um novo ficheiro to tipo "type"
        /// </summary>
        /// <param name="type">Variavel que recebe um tipo de ficheiro a ser criado</param>
        private void CreateNewFile(string type)
        {
            int cnt = 0;
            string newFileName = $"New File.{type}";

            DirectoryInfo dir = new DirectoryInfo(path);

            //Procura se já existe um ficheiro com o nome "New File" ou "New File (cnt)" e se existir aumenta o numero do cnt e muda o nome para "New file" e o numero do cnt entre ()
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
                    newFileName = newFileName + "(" + cnt + ")" + $".{type}";
                }
            }

            string fullPath = Path.Combine(path, newFileName);

            try
            {
                using (FileStream filestream = File.Create(fullPath)) { } //Cria o ficheiro

                RefreshExplorer();

                //Após cirar o ficheiro começa a edição do nome como no windows file explorer
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
        #endregion

        #region NewFolder

        /// <summary>
        /// Metodo para criar uma nova pasta
        /// </summary>
        private void NewFolder()
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
        #endregion

        #region txt_Path_Enter
        private void txt_Path_Enter(object sender, EventArgs e)
        {
            //Se o caminho da textbox não acabar em \ adiciona \
            if (!txt_Path.Text.EndsWith(@"\"))
            {
                txt_Path.Text += @"\";
            }
        }
        #endregion
    }
}