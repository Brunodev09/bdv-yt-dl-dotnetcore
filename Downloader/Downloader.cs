using System;
using System.Collections.Generic;
using VideoLibrary;
using System.Threading.Tasks;

namespace BdvYoutubeDotnet
{
    public class Downloader
    {
        private static int _id;
        public static async Task GetVideos(Config cfg)
        {
            List<Task> tasks = new List<Task>();

            foreach (var link in cfg.Collection)
            {
                tasks.Add(Task.Run(() =>
                {
                    Downloader.Download(link, cfg.DestinationPath);

                }));
            }

            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("Done...");

        }

        private static Task<int> Download(string videoLink, string path)
        {
            try
            {
                int current = ++_id;
                Console.WriteLine($"[Task-{current}] Downloading video from link " + videoLink);
                var Youtube = YouTube.Default;
                var Video = Youtube.GetVideo(videoLink);
                Fs.CreateFileBytes(path + Video.FullName, Video.GetBytes());
                Console.WriteLine($"[Task-{current}] Download and cache finished for link {videoLink}.");
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