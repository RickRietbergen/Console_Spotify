using System;
using NAudio.Wave;
using System.Timers;
using System.Media;

namespace Spotiy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> playlist = new List<string>();
            //string[] files = Directory.GetFiles(@"C:\Users\rbps3\OneDrive - ROC Nijmegen\Bureaublad\schooljaar_2\C#\ConsoleSpotify\Spotify\Spotify\Songs\", "*.mp3");
            //foreach (string file in files)
            //{
            //    playlist.Add(file);
            //}
            //foreach (string song in playlist)
            //{
            //    Console.WriteLine("Playing {0}", song);
            //    // Code to play the song goes here
            //}

            string filePath = "C:\\Users\\rbps3\\OneDrive - ROC Nijmegen\\Bureaublad\\schooljaar_2\\C#\\ConsoleSpotify\\Spotify\\Spotify\\Songs\\Josh Turner - Your Man.mp3";
            using (var player = new System.Media.SoundPlayer(filePath))
            {
                player.Play();
                
            }

            Console.Read();
        }
    }
}