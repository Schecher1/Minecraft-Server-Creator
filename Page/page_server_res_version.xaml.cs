using System;
using System.Linq;
using System.Windows;
using Minecraft_Server_Creator.Class;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_server_res_version
    {
        public page_server_res_version()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private void bttn_click_download(object sender, RoutedEventArgs e)
        {
            try
            {
                VersionManager.download(VersionManager.serverInformationList.Where(si => si.Version == lb_versions.SelectedItem.ToString().Split(' ')[1]).First());
                Class.SideBarModel.Bttn_CreateServerSettings = true;
                mw.pageMirror.Content = new page_server_settings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PageOnLoad(object sender, RoutedEventArgs e)
        {
            gb_ListOfVersions.Header = "Server Versions (" + VersionManager.choosenVersion + ")";
            VersionManager.init();
            lb_versions.Items.Clear();
            foreach (ServerInformation si in VersionManager.serverInformationList)
                lb_versions.Items.Add("Version: " + si.Version);
        }

        private void lb_versions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            cb_download.IsEnabled = lb_versions.SelectedIndex != -1;
            ServerInformation serverInformation = VersionManager.search(lb_versions.SelectedItem.ToString().Split(' ')[1]);

            msgbox_version.Content = ("Version:" + Environment.NewLine + serverInformation.Version);
            msgbox_ReleaseDate.Content = ("Release date:" + Environment.NewLine + serverInformation.ReleaseDate);
            msgbox_filesize.Content = ("File size:" + Environment.NewLine + serverInformation.Size);
            cb_download.Content = ("Yes," + Environment.NewLine + "i would like to download the version " + Environment.NewLine + serverInformation.Version + " from " + VersionManager.choosenVersion + ".");
        }

        private void cb_download_Unchecked(object sender, RoutedEventArgs e) => bttn_download.IsEnabled = false;

        private void cb_download_Checked(object sender, RoutedEventArgs e) => bttn_download.IsEnabled = true;
    }
}