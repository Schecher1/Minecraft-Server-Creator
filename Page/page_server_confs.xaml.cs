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
    public partial class page_server_confs
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public page_server_confs()
        {
            InitializeComponent();
            tb_conf.Text =
                ("# Minecraft server properties" + Environment.NewLine +
                "spawn-protection=16" + Environment.NewLine +
                "max-tick-time=60000" + Environment.NewLine +
                "query.port=25565" + Environment.NewLine +
                "generator-settings=" + Environment.NewLine +
                "force-gamemode=false" + Environment.NewLine +
                "allow-nether=true" + Environment.NewLine +
                "enforce-whitelist=false" + Environment.NewLine +
                "gamemode=survival" + Environment.NewLine +
                "broadcast-console-to-ops=true" + Environment.NewLine +
                "enable-query=false" + Environment.NewLine +
                "player-idle-timeout=0" + Environment.NewLine +
                "difficulty=easy" + Environment.NewLine +
                "spawn-monsters=true" + Environment.NewLine +
                "broadcast-rcon-to-ops=true" + Environment.NewLine +
                "op-permission-level=4" + Environment.NewLine +
                "pvp=true" + Environment.NewLine +
                "snooper-enabled=true" + Environment.NewLine +
                "level-type=default" + Environment.NewLine +
                "hardcore=false" + Environment.NewLine +
                "enable-command-block=false" + Environment.NewLine +
                "max-players=20" + Environment.NewLine +
                "network-compression-threshold=256" + Environment.NewLine +
                "resource-pack-sha1=" + Environment.NewLine +
                "max-world-size=29999984" + Environment.NewLine +
                "function-permission-level=2" + Environment.NewLine +
                "rcon.port=25575" + Environment.NewLine +
                "server-port=25565" + Environment.NewLine +
                "debug=false" + Environment.NewLine +
                "server-ip=127.0.0.1" + Environment.NewLine +
                "spawn-npcs=true" + Environment.NewLine +
                "allow-flight=false" + Environment.NewLine +
                "level-name=world" + Environment.NewLine +
                "view-distance=10" + Environment.NewLine +
                "resource-pack=" + Environment.NewLine +
                "spawn-animals=true" + Environment.NewLine +
                "white-list=false" + Environment.NewLine +
                "rcon.password=" + Environment.NewLine +
                "generate-structures=true" + Environment.NewLine +
                "max-build-height=256" + Environment.NewLine +
                "online-mode=true" + Environment.NewLine +
                "level-seed=" + Environment.NewLine +
                "use-native-transport=true" + Environment.NewLine +
                "prevent-proxy-connections=false" + Environment.NewLine +
                "enable-rcon=false" + Environment.NewLine +
                "motd=A Minecraft Server, made with Server-creator from GermanNightmare");
        }

        private void bttn_click_create(object sender, RoutedEventArgs e)
        {

            mw.pageMirror.Content = new page_finish();
        }
    }
}
