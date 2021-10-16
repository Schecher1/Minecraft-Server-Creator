using System.Windows;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_server_settings
    {
        public page_server_settings()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private void bttn_click_save(object sender, RoutedEventArgs e)
        {
            mw.pageMirror.Content = new page_server_confs();
        }
    }
}
