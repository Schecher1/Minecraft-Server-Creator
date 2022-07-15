using System;
using System.Windows;
using System.Windows.Forms;
using Minecraft_Server_Creator.Class;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_server_settings
    {
        public page_server_settings()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        
        string ServerPath = null;

        private void bttn_click_save(object sender, RoutedEventArgs e)
        {
            try
            {
                ServerCreatorCache.iconPath = ofd.FileName;
                ServerCreatorCache.serverRam = Convert.ToInt32(ramValue.Text) * 1024;
                ServerCreatorCache.serverPath = fbd.SelectedPath;
                Class.SideBarModel.Bttn_CreateServerConfigs = true;
                mw.pageMirror.Content = new page_server_confs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ramValue_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ramValue.Text))
                cb_allcorrect.Content = ($"yes, my server should have {Convert.ToInt32(ramValue.Text)} GB ({(Convert.ToInt32(ramValue.Text)) * 1024} MB) RAM");
        }

        private void ramUp_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(ramValue.Text) < 100) { ramValue.Text = Convert.ToString(Convert.ToInt32(ramValue.Text) + 1); }
        }
        private void ramDown_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(ramValue.Text) > 1) {ramValue.Text = Convert.ToString(Convert.ToInt32(ramValue.Text) - 1); }
        }

        private void bttn_Select_InstallPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ofd.Title = "Choose your server path!";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    ServerPath = fbd.SelectedPath;
                    msgbox_serverPath.Content = ServerPath;
                }
                if (ServerPath != null)
                    cb_allcorrect.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bttn_Select_IconPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ofd.Title = "Choose your server icon!  (64x64)";
                ofd.Filter = "PNG| *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    msgbox_iconPath.Content = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cb_allcorrect_Checked(object sender, RoutedEventArgs e) => bttn_save.IsEnabled = true;

        private void cb_allcorrect_Unchecked(object sender, RoutedEventArgs e) => bttn_save.IsEnabled = false;
    }
}