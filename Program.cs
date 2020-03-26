using System.Threading.Tasks;

namespace BdvYoutubeDotnet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string SerializedLinks = Fs.ReadAndCache(@"./Config.json");
            Config cfg = Deserializer.Deserialize<Config>(SerializedLinks);
            await Downloader.GetVideos(cfg);
        }

    }
}
