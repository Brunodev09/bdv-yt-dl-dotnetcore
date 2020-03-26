
namespace BdvYoutubeDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            string SerializedLinks = Fs.ReadAndCache(@"./Config.json");
            Config cfg = Deserializer.Deserialize<Config>(SerializedLinks);
            Downloader youtubeDownloader = new Downloader(cfg);
        }
    }
}
