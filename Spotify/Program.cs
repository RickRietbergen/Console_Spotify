using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Timers;
using System.Media;

namespace Spotiy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the spotify app!");
            Console.WriteLine("Make by: Rick");
            Console.WriteLine("===========================");

            List<string> playlists = new List<string>();
            playlists.Add("Playlist 1");
            playlists.Add("Playlist 2");
            playlists.Add("Playlist 3");

            while (true)
            {
                Console.WriteLine("-- Commands --:");
                Console.WriteLine("");
                //1. view all the playlists, choose one to view the songs inside the chosen playlist. choos shuffle or select a song
                Console.WriteLine("1. view playlists");
                //2. goes to another readline where u can create, delete playlists
                Console.WriteLine("2. manage playlists");
                //
                Console.WriteLine("3. add song");
                //4. view all the albums, choose albums or exit the option, suffle album or choose song
                Console.WriteLine("4. view albums");
                Console.WriteLine("5. afspeellijst afspelen");
                Console.WriteLine("6. afspeellijst afspelen");

                var choice = Console.ReadLine();
            }

            Console.WriteLine("Kies een afspeellijst:");
            foreach (string playlist in playlists)
            {
                Console.WriteLine(playlist);
            }

            Console.Write("Welke afspeellijst wil je afspelen? ");
            string gekozenPlaylist = Console.ReadLine();

            Console.WriteLine("De afspeellijst " + gekozenPlaylist + " wordt afgespeeld.");
            // Hier kun je code schrijven om de geselecteerde afspeellijst af te spelen.

            Console.Read();
        }
    }
}