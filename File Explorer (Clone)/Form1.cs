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
        string path = @"c:\";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Path.Text = path;
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
                        lvw_FileExplorer.Items.Add(new ListViewItem(item.Name, 0));   
                }
                catch (Exception)
                {

                    throw;
                }

            }
            foreach (var item in dir.GetFiles()) // Vai a cada diretorio dentro do diretorio "path" e vai buscar todos os ficheiros
            {
                lvw_FileExplorer.Items.Add(new ListViewItem(item.Name, 1));
            }
        }

        private void lvw_FileExplorer_DoubleClick(object sender, EventArgs e)
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

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            path = new DirectoryInfo(path).Parent.FullName;
            RefreshExplorer();
        }

        private void cbb_ViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_ViewType.SelectedItem == "Detalhes")
            {
                lvw_FileExplorer.View = View.Details;
            }
            if (cbb_ViewType.SelectedItem == "Lista")
            {
                lvw_FileExplorer.View = View.List;
            }
            if (cbb_ViewType.SelectedItem == "Icons Grandes")
            {
                lvw_FileExplorer.View = View.LargeIcon;
            }
        }
    }
}
