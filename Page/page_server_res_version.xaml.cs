using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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