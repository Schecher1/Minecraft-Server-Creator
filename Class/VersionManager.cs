using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Windows;
using Minecraft_Server_Creator.Resources;
using System.Threading.Tasks;

namespace Minecraft_Server_Creator.Class
{
    class VersionManager
    {
        public static WebClient webClient = new WebClient();
        public static List<ServerInformation> serverInformationList = new List<ServerInformation>();
        public static string choosenVersion = "";

        public static bool downloadState = false;

        public static ServerInformation search(String version)
        {
            return serverInformationList.Where<ServerInformation>(si => si.Version == version).First();
        }

        public static void download(ServerInformation serverInformation)
        {
            Task.Run(() =>
            {
                downloadState = true;
                string download_link = serverInformation.Download_link.Replace('\r', ' ');
                string download_version = serverInformation.Version.Replace('\r', ' ');
                webClient.DownloadFile(new Uri(download_link), $@"C:\Users\{Environment.UserName}\AppData\Local\Temp\" + choosenVersion + " - " + download_version + ".jar");
                ServerCreatorCache.serverJar = (choosenVersion + " - " + download_version + ".jar");
                MessageBox.Show("Download from " + choosenVersion + "-" + serverInformation.Version + ".jar" + " was successful!");
                downloadState = false;


                string tmp_file_path = Path.Combine(Path.GetTempPath(), "msccache_jar.txt");
                string[] serverVersion =
                {
                choosenVersion + " - " + serverInformation.Version + ".jar"
            };
                File.WriteAllLines(tmp_file_path, serverVersion);
            });
        }

        public static void init()
        {
            try
            {
                string[] fileContent = File.ReadAllLines($@"versions\{choosenVersion}.txt");

                serverInformationList.Clear();
                
                for (int i = 0; i < fileContent.Length; i += (2 * 4))
                {
                    serverInformationList.Add(new ServerInformation(fileContent[i + 1], fileContent[i + 5], fileContent[i + 3], fileContent[i + 7]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}