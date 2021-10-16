using System.Windows;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_server_res_selection
    {
        public page_server_res_selection()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private void bttn_click_vanilla(object sender, RoutedEventArgs e)
        {

            mw.pageMirror.Content = new page_server_res_version();
        }

        private void bttn_click_bukkit(object sender, RoutedEventArgs e)
        {

            mw.pageMirror.Content = new page_server_res_version();
        }

        private void bttn_click_spigot(object sender, RoutedEventArgs e)
        {

            mw.pageMirror.Content = new page_server_res_version();
        }
    }
}
