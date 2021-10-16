using System.Windows;

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
            mw.pageMirror.Content = new page_server_settings();
        }
    }
}