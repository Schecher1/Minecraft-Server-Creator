using Minecraft_Server_Creator.Page;
using Minecraft_Server_Creator.Resources;
using System.IO;
using System.Windows;
using System.Windows.Input;

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

        public void JoinPage_finish(object sender, ExecutedRoutedEventArgs e)
        {  
            if (Class.SideBarModel.Bttn_CreateServer)
                pageMirror.Content = new page_finish();
        }
        public void JoinPage_main(object sender, ExecutedRoutedEventArgs e) => pageMirror.Content = new page_main();
        public void JoinPage_server_confs(object sender, ExecutedRoutedEventArgs e)
        {
            if (Class.SideBarModel.Bttn_CreateServerConfigs)
                pageMirror.Content = new page_server_confs();
        }
        public void JoinPage_server_res_selection(object sender, ExecutedRoutedEventArgs e)
        {
                pageMirror.Content = new page_server_res_selection();
        }
        public void JoinPage_server_res_version(object sender, ExecutedRoutedEventArgs e)
        {
            if (Class.SideBarModel.Bttn_ChooseServerVersion)
                pageMirror.Content = new page_server_res_version();
        }
        public void JoinPage_server_settings(object sender, ExecutedRoutedEventArgs e)
        {
            if (Class.SideBarModel.Bttn_CreateServerSettings)
                pageMirror.Content = new page_server_settings();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists("versions"))
                return;
            
            Directory.CreateDirectory("versions");

            File.WriteAllText("versions/bukkit.txt", MinecraftServerCreator_Data.bukkit);
            File.WriteAllText("versions/spigot.txt", MinecraftServerCreator_Data.spigot);
            File.WriteAllText("versions/vanilla.txt", MinecraftServerCreator_Data.vanilla);
        }
    }
}
