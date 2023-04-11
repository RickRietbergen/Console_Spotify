using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Song
    {
        //properties.
        public string songName { get; set; }
        public string artistName { get; set; }
        public int songDuration { get; set; }

        public Song(string songName, string artistName, int songDuration)
        {
            //construstor for Song
            this.songName = songName;
            this.artistName = artistName;
            this.songDuration = songDuration;
        }

        public static List<Song> AllSongs { get; set; } = new List<Song>
        {
            //init some songs.
            new Song("testnummer", "Richard", 120),
            new Song("your man", "Josh Turner", 180),
            new Song("smells like teen spirit", "Nirvana", 200)
        };
        
        public static List<Song> AllAlbumSongs { get; set; } = new List<Song>
        {
            //init songs for album 'nirvana'.
            new Song("polly", "nirvana", 120),
            new Song("the man who sold the world", "nirvana", 140),
            new Song("about a girl", "nirvana", 160),
            new Song("come as you are", "Nirvana", 180),
            new Song("smells like teen spirit", "Nirvana", 200)
        };
        
        public static List<Song> FriendsSongs { get; set; } = new List<Song>
        {
            //add songs for friends.
            new Song("testnummer", "Richard", 120),
            new Song("smells like teen spirit", "Nirvana", 200),
        };

        public static void ViewSongs()
        {
            //show all songs.
            Console.WriteLine("\nAll songs: ");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine($"Playlist: {playlist.playlistName}");
                foreach (Song songs in Song.AllSongs)
                {
                    Console.WriteLine($"- {songs.songName} by {songs.artistName} ({songs.songDuration} seconds)");
                }
            }
        }

        public static void AddSong()
        {
            //ask user which playlist u want to add a song to, and show all playlists.
            Console.WriteLine("To which playlist do you want to add a song:");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine(playlist.playlistName);
            }

            Console.Write("Enter the name of the playlist you want to add the song to: ");
            string playlistName = Console.ReadLine();
            //loop through all playlists.
            Playlist addSongToPlaylist = Playlist.AllPlaylists.Find(p => p.playlistName == playlistName);

            if (addSongToPlaylist != null)
            {
                //ask user for songName, artistName, songDuration.
                Console.Write("Enter the song name: ");
                string songName = Console.ReadLine();

                Console.Write("Enter the artist name: ");
                string artistName = Console.ReadLine();

                Console.Write("Enter the song duration (in seconds): ");
                int songDuration = int.Parse(Console.ReadLine());
                //add song to chosen playlist
                addSongToPlaylist.Songs.Add(new Song(songName, artistName, songDuration));
                Console.WriteLine($"Added {songName} by {artistName} ({songDuration} seconds) to {playlistName}");
                //show all playlists.
                foreach (Playlist playlist in Playlist.AllPlaylists)
                {
                    Console.WriteLine($"Playlist: {playlist.playlistName}");

                    foreach (Song song in playlist.Songs)
                    {
                        Console.WriteLine(song.songName);
                    }
                }
                //sleep 2 sec and clear console.
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                //error message, playlist not found.
                Console.WriteLine($"Error: playlist '{playlistName}' not found");
            }
        }

        public static void RemoveSong()
        {
            //ask user from which playlist u want to delete a song, show all playlists.
            Console.WriteLine("From which playlist do you want to remove a song:");
            foreach (Playlist playlist in Playlist.AllPlaylists)
            {
                Console.WriteLine(playlist.playlistName);
            }

            Console.Write("Enter the name of the playlist you want to remove the song from: ");
            string playlistName = Console.ReadLine();
            //loop through all playlists.
            Playlist removeSongFromPlaylist = Playlist.AllPlaylists.Find(p => p.playlistName == playlistName);

            if (removeSongFromPlaylist != null)
            {
                //read songname that needs to be deleted.
                Console.Write("Enter the name of the song you want to remove: ");
                foreach (Song song in AllSongs)
                {
                    Console.WriteLine(song.songName);
                }
                string songName = Console.ReadLine();

                //find song in playlist.
                Song removeSong = Song.AllSongs.Find(s => s.songName == songName);

                if (removeSong != null)
                {
                    if (removeSongFromPlaylist.Songs.Remove(removeSong))
                    {
                        Console.WriteLine($"Removed {songName} by {removeSong.artistName} from {playlistName}");

                        // Print the updated playlist
                        Playlist.ViewPlaylists();

                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        //error songName not found.
                        Console.WriteLine($"Error: {songName} not found in {playlistName}");
                    }
                }
                else
                {
                    //error songName not found.
                    Console.WriteLine($"Error: song '{songName}' not found");
                }
            }
            else
            {
                //error playlistName not found.
                Console.WriteLine($"Error: playlist '{playlistName}' not found");
            }
        }
    }
}