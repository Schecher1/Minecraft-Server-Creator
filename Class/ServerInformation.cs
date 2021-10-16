namespace Minecraft_Server_Creator.forms
{
    class ServerInformation
    {
        private string version;
        private string releaseDate;
        private string size;
        private string download_link;

        public ServerInformation(string version, string releaseDate, string size, string download_link)
        {
            Version = version;
            ReleaseDate = releaseDate;
            Size = size;
            Download_link = download_link;
        }

        public string Version { get => version; set => version = value; }
        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string Size { get => size; set => size = value; }
        public string Download_link { get => download_link; set => download_link = value; }
    }
}
