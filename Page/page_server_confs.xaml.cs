using System;
using System.Drawing;
using System.Windows;
using Minecraft_Server_Creator.Class;
using Minecraft_Server_Creator.Resources;

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
            try
            {
                //EULA Create
                string[] EULA = { "#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula).",
                                "#Accepted on " + DateTime.Now,
                                "eula=true"};
                System.IO.File.WriteAllLines($@"{ServerCreatorCache.serverPath}\eula.txt", EULA);

                //Properties Create
                string[] Properties = { tb_conf.Text };
                System.IO.File.WriteAllLines($@"{ServerCreatorCache.serverPath}\server.properties", Properties);

                //BAT Create
                string[] BAT = {"@echo off",
                                          ":ServerLoop",
                                          $"java -Xmx{ServerCreatorCache.serverRam}M -jar Server.jar nogui",
                                          "goto ServerLoop"};
                System.IO.File.WriteAllLines($@"{ServerCreatorCache.serverPath}\ServerStarter_Windows.bat", BAT);

                //SH Create
                string[] SH = {"#!/bin/sh",
                                        $"exec java -Xmx{ServerCreatorCache.serverRam}M -jar Server.jar nogui"};

                System.IO.File.WriteAllLines($@"{ServerCreatorCache.serverPath}\ServerStarter_Linux.sh", SH);

                //Copy Server.jar
                System.IO.File.Copy($@"C:\Users\{Environment.UserName}\AppData\Local\Temp\{ServerCreatorCache.serverJar}", $@"{ServerCreatorCache.serverPath}\Server.jar", true);

                //Copy server-icon
                if (ServerCreatorCache.iconPath == "")
                {
                    Bitmap servericon = MinecraftServerCreator_Data.server_icon;
                    servericon.Save($@"{ServerCreatorCache.serverPath}\server-icon.png");
                }
                else
                    System.IO.File.Copy($@"{ServerCreatorCache.iconPath}", $@"{ServerCreatorCache.serverPath}\server-icon.png", true);

                mw.pageMirror.Content = new page_finish();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cb_allcorrect_Checked(object sender, RoutedEventArgs e) => bttn_create.IsEnabled = true;
        private void cb_allcorrect_Unchecked(object sender, RoutedEventArgs e) => bttn_create.IsEnabled = false;
    }
}