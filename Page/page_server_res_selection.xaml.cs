using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Minecraft_Server_Creator.Class;

namespace Minecraft_Server_Creator.Page
{
    public partial class page_server_res_selection
    {
        public page_server_res_selection()
        {
            InitializeComponent();
        }

        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private void bttn_click(object sender, RoutedEventArgs e)
        {
            VersionManager.choosenVersion = ((Button)sender).Content.ToString();
            mw.pageMirror.Content = new page_server_res_version();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sP_version.Children.Clear();

            foreach (var item in Directory.GetFiles("versions"))
            {
                var versionButton = new Button()
                {
                    Content = item.Split('\\')[1].Split('.')[0].ToLower(),
                    Height = 80,
                    FontFamily = new FontFamily("Comic Sans MS"),
                    FontSize = 30,
                    Foreground = new SolidColorBrush(Color.FromRgb(126, 126, 126)),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 100),
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Minecraft-Server-Creator;component/Resources/wood_sign.png")))
                };
                versionButton.Click += bttn_click;

                sP_version.Children.Add(versionButton);
            }
        }
    }
}
