using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Song
    {
        public string songName { get; set; }
        public string artistName { get; set; }
        public int songDuration { get; set; }

        public Song(string songName, string artistName, int songDuration)
        {
            this.songName = songName;
            this.artistName = artistName;
            this.songDuration = songDuration;
        }

        public static List<Song> AllSongs { get; set; } = new List<Song>
        {
            new Song("testnummer", "testartiest", 200),
            new Song("AnusVet", "rick", 180)
        };

        public static void ViewSongs()
        {
            Console.WriteLine("\nAll songs: ");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine($"Playlist: {playlist.name}");
                foreach (Song songs in Song.AllSongs)
                {
                    Console.WriteLine($"- {songs.songName} by {songs.artistName} ({songs.songDuration} seconds)");
                }
            }
        }

        public static void AddSong()
        {
            Console.WriteLine("To which playlist do you want to add a song:");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine(playlist.name);
            }

            Console.Write("Enter the name of the playlist you want to add the song to: ");
            string playlistName = Console.ReadLine();

            Playlist addSongToPlaylist = Playlist.AllPlaylists.Find(p => p.name == playlistName);

            if (addSongToPlaylist != null)
            {
                Console.Write("Enter the song name: ");
                string songName = Console.ReadLine();

                Console.Write("Enter the artist name: ");
                string artistName = Console.ReadLine();

                Console.Write("Enter the song duration (in seconds): ");
                int songDuration = int.Parse(Console.ReadLine());

                addSongToPlaylist.Songs.Add(new Song(songName, artistName, songDuration));
                Console.WriteLine($"Added {songName} by {artistName} ({songDuration} seconds) to {playlistName}");

                foreach (Playlist playlist in Playlist.AllPlaylists)
                {
                    Console.WriteLine($"Playlist: {playlist.name}");

                    foreach (Song song in playlist.Songs)
                    {
                        Console.WriteLine(song.songName);
                    }
                }

                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Error: playlist '{playlistName}' not found");
            }
        }

        public static void RemoveSong()
        {
            Console.WriteLine("From which playlist do you want to remove a song:");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine(playlist.name);
            }

            Console.Write("Enter the name of the playlist you want to remove the song from: ");
            string playlistName = Console.ReadLine();

            Playlist removeSongFromPlaylist = Playlist.AllPlaylists.Find(p => p.name == playlistName);

            if (removeSongFromPlaylist != null)
            {
                Console.Write("Enter the name of the song you want to remove: ");
                string songName = Console.ReadLine();

                Song removeSong = Song.AllSongs.Find(s => s.songName == songName);

                if (removeSong != null)
                {
                    if (removeSongFromPlaylist.Songs.Remove(removeSong))
                    {
                        Console.WriteLine($"Removed {songName} by {removeSong.artistName} from {playlistName}");

                        // Print the updated playlist
                        Playlist.ViewPlaylists();

                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {songName} not found in {playlistName}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: song '{songName}' not found");
                }
            }
            else
            {
                Console.WriteLine($"Error: playlist '{playlistName}' not found");
            }
        }
    }
}