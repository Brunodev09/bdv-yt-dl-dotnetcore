using System;
using System.IO;

namespace BdvYoutubeDotnet
{
    public class Fs
    {
        public static string ReadAndCache(string Path)
        {
            try
            {
                return File.ReadAllText(Path);
            }
            catch (System.Exception Ex)
            {
                return Ex.ToString();
            }
        }

        public static void CreateFileWithContent(string Path, string Data)
        {
            try
            {
                File.WriteAllText(Path, Data);
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static void CreateFileBytes(string Path, byte[] Buffer)
        {
            try
            {
                File.WriteAllBytes(Path, Buffer);
            }
            catch (System.Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}