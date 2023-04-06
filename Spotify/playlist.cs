using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Playlist
    {
        public static List<string> allPlaylists { get; private set; } = new List<string> { "cowboy", "queen" };

        public static void ViewPlaylists()
        {
            Playlist playlist = new Playlist();

            Console.WriteLine("\nKies een afspeellijst:");
            foreach (string list in allPlaylists)
            {
                Console.WriteLine(list);
            }
        }

        public static void CreatePlaylist()
        {
            Console.WriteLine("Create a new playlist.");
            Console.WriteLine("Enter the name of the playlist:");
            string newPlaylistName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newPlaylistName))
            {
                if (!allPlaylists.Contains(newPlaylistName))
                {
                    allPlaylists.Add(newPlaylistName);
                    Console.WriteLine($"Playlist '{newPlaylistName}' has been created.");

                    Console.WriteLine("all playlists:");
                    foreach (string listItem in allPlaylists)
                    {
                        Console.WriteLine(listItem);
                    }
                }
                else
                {
                    Console.WriteLine($"Playlist '{newPlaylistName}' already exists.");
                }
            }
            else
            {
                Console.WriteLine("error, geef een naam aan de playlist");
            }
        }

        public static void DeletePlaylist()
        {
            Console.WriteLine("All playlists:");
            foreach (string listItem in allPlaylists)
            {
                Console.WriteLine(listItem);
            }

            Console.WriteLine("\nChoose a playlist you want to delete:");
            string deletePlaylistName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(deletePlaylistName))
            {
                if (allPlaylists.Contains(deletePlaylistName))
                {
                    allPlaylists.Remove(deletePlaylistName);
                    Console.WriteLine($"Playlist '{deletePlaylistName}' has been deleted.");

                    Console.WriteLine("all playlists:");
                    foreach (string listItem in allPlaylists)
                    {
                        Console.WriteLine(listItem);
                    }
                }
                else
                {
                    Console.WriteLine($"Playlist '{deletePlaylistName}' does not exist.");
                }
                Console.WriteLine(deletePlaylistName);
            }
            else
            {
                Console.WriteLine("Please enter a playlist name.");
            }
        }
    }
}
