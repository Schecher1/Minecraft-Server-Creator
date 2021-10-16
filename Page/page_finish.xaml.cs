using System;
using System.Diagnostics;
using System.Windows;
using Minecraft_Server_Creator.Class;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_finish
    {
        public page_finish()
        {
            InitializeComponent();
        }

        private void bttn_click_close(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", ServerCreatorCache.serverPath);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
