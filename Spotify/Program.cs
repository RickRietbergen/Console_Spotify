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

            Console.WriteLine("create a playlist:");

            string input = Console.ReadLine();
            playlist.Add(input);
            Console.WriteLine("playlist created");

            foreach (string song in playlist)
            {
                Console.WriteLine($"{song}");
            }


            Console.Read();
        }
    }
}