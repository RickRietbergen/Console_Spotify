using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Playlist
    {
        public List<string> allPlaylists { get; private set; }

        public Playlist()
        {
            allPlaylists = new List<string>();
            allPlaylists.Add("cowboy");
            allPlaylists.Add("queen");
        }
        public static void ViewPlaylists()
        {
            Playlist playlist = new Playlist();

            Console.WriteLine("Kies een afspeellijst:");
            foreach (string list in playlist.allPlaylists)
            {
                Console.WriteLine(list);
            }
        }

        public static void CreatePlaylist()
        {
            Console.WriteLine("Create a new playlist.");
            Console.WriteLine("Enter the name of the playlist:");
            string newPlaylistName = Console.ReadLine();

            if (newPlaylistName != null)
            {
                Playlist playlist = new Playlist();
                playlist.allPlaylists.Add(newPlaylistName);
                Console.WriteLine($"Playlist '{newPlaylistName}' has been created.");
            }
            else
            {
                Console.WriteLine("error, geef een naam aan de playlist");
            }
        }

        public static void DeletePlaylist()
        {

        }
    }
}
