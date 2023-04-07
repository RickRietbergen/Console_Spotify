using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Playlist
    {
        public List<Song> Songs { get; set; }
        public string name { get; set; }
        public bool playing { get; set; } = false; 

        public Playlist(string name)
        {
            this.name = name;
            Songs = Song.AllSongs;
        }

        public static List<Playlist> AllPlaylists { get; set; } = new List<Playlist>
        {
            new Playlist("cowboy"),
            new Playlist("queen")
        };

        public static void ViewPlaylists()
        {
            Console.WriteLine("\nAll playlists:");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine(playlist.name);
                foreach (Song song in playlist.Songs)
                {
                    Console.WriteLine(song.songName);
                }
            }
        }

        public static void PlayPlaylist()
        {
            Console.WriteLine("All playlists:");
            foreach (Playlist playlist in AllPlaylists)
            {
                Console.WriteLine($"- {playlist.name}");
            }

            Console.Write("Choose a playlist: ");
            string selectedPlaylistName = Console.ReadLine();
            Playlist selectedPlaylist = AllPlaylists.FirstOrDefault(p => p.name == selectedPlaylistName);

            if (AllPlaylists.Contains(selectedPlaylist))
            {
                Console.WriteLine($"playlist: '{selectedPlaylistName}':");
                Console.WriteLine("Songs:");
                foreach (Song song in selectedPlaylist.Songs)
                {
                    Console.WriteLine($"-- {song.songName}");
                }

                Console.WriteLine("Choose a song:");
                string songChoice = Console.ReadLine();
                Song selectedSong = Song.AllSongs.FirstOrDefault(s => s.songName == songChoice);

                //play the selected song
                bool playing = true;
                int songDuration = selectedSong.songDuration;

                if (Song.AllSongs.Contains(selectedSong))
                {
                    Console.WriteLine(songDuration);
                    //while (playing)
                    //{
                    //    Console.Write($"playing... {selectedSong.songName}");
                    //}
                }
            }
            else
            {
                Console.WriteLine($"Playlist '{selectedPlaylistName}' does not exist.");
            }
        }

        public static void CreatePlaylist()
        {
            Console.WriteLine("Create a new playlist.");
            Console.Write("Enter the name of the playlist: ");
            string newPlaylistName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newPlaylistName))
            {
                if (!AllPlaylists.Any(p => p.name == newPlaylistName))
                {
                    Playlist newPlaylist = new Playlist(newPlaylistName);
                    AllPlaylists.Add(newPlaylist);
                    Console.WriteLine($"Playlist '{newPlaylistName}' has been created.");

                    Console.WriteLine("all playlists:");
                    foreach (Playlist playlist in AllPlaylists)
                    {
                        Console.WriteLine(playlist.name);
                    }
                }
                else
                {
                    Console.WriteLine($"Playlist '{newPlaylistName}' already exists.");
                }
            }
            else
            {
                Console.WriteLine("Error, please provide a name for the playlist.");
            }
        }

        public static void DeletePlaylist()
        {
            Console.WriteLine("All playlists:");
            foreach (Playlist playlist in AllPlaylists)
            {
                Console.WriteLine(playlist.name);
            }

            Console.Write("\nChoose a playlist you want to delete: ");
            string deletePlaylistName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(deletePlaylistName))
            {
                Playlist playlistToDelete = AllPlaylists.FirstOrDefault(p => p.name == deletePlaylistName);
                if (playlistToDelete != null)
                {
                    AllPlaylists.Remove(playlistToDelete);
                    Console.WriteLine($"Playlist '{deletePlaylistName}' has been deleted.");

                    Console.WriteLine("all playlists:");
                    foreach (Playlist playlist in AllPlaylists)
                    {
                        Console.WriteLine(playlist.name);
                    }
                }
                else
                {
                    Console.WriteLine($"Playlist '{deletePlaylistName}' does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Error. Please enter a playlist name.");
            }
        }
    }
}
