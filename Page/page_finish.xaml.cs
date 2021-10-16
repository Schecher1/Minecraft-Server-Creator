using System.Diagnostics;
using System.Windows;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_finish
    {
        public page_finish()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private void bttn_click_close(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe");
            Application.Current.Shutdown();
        }
    }
}
