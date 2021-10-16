using Minecraft_Server_Creator.Page;
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

namespace Minecraft_Server_Creator
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand GoToPage_finish { get; } = new RoutedCommand("GoToPage_finish", typeof(MainWindow));
        public static RoutedCommand GoToPage_main { get; } = new RoutedCommand("GoToPage_main", typeof(MainWindow));
        public static RoutedCommand GoToPage_server_confs { get; } = new RoutedCommand("GoToPage_server_confs", typeof(MainWindow));
        public static RoutedCommand GoToPage_server_res_selection { get; } = new RoutedCommand("GoToPage_server_res_selection", typeof(MainWindow));
        public static RoutedCommand GoToPage_server_res_version { get; } = new RoutedCommand("GoToPage_server_res_version", typeof(MainWindow));
        public static RoutedCommand GoToPage_server_settings { get; } = new RoutedCommand("GoToPage_server_settings", typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(GoToPage_finish, JoinPage_finish, CanExecuteNextPageCommand));
            CommandBindings.Add(new CommandBinding(GoToPage_main, JoinPage_main, CanExecuteNextPageCommand));
            CommandBindings.Add(new CommandBinding(GoToPage_server_confs, JoinPage_server_confs, CanExecuteNextPageCommand));
            CommandBindings.Add(new CommandBinding(GoToPage_server_res_selection, JoinPage_server_res_selection, CanExecuteNextPageCommand));
            CommandBindings.Add(new CommandBinding(GoToPage_server_res_version, JoinPage_server_res_version, CanExecuteNextPageCommand));
            CommandBindings.Add(new CommandBinding(GoToPage_server_settings, JoinPage_server_settings, CanExecuteNextPageCommand));


            pageMirror.Content = new page_main();
        }

        private void CanExecuteNextPageCommand(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void JoinPage_finish(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_finish();
        private void JoinPage_main(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_main();
        private void JoinPage_server_confs(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_server_confs();
        private void JoinPage_server_res_selection(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_server_res_selection();
        private void JoinPage_server_res_version(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_server_res_version();
        private void JoinPage_server_settings(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_server_settings();
    }
}
