using System;
using VideoLibrary;
using System.Threading.Tasks;

namespace BdvYoutubeDotnet
{
    public class Downloader
    {
        private string Path;
        private int id;
        public Downloader(Config cfg)
        {
            this.Path = cfg.DestinationPath;

            foreach (var link in cfg.Collection)
            {
                this.Download(link);
            }
            Console.WriteLine("Done...");
        }

        private Task<int> Download(string videoLink)
        {
            try
            {
                id++;
                Console.WriteLine($"[Task-{id}] Downloading video from link " + videoLink);
                var Youtube = YouTube.Default;
                var Video = Youtube.GetVideo(videoLink);
                Fs.CreateFileBytes(this.Path + Video.FullName, Video.GetBytes());
                return Task.FromResult(0);
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return Task.FromResult(1);
            }
        }
    }
}