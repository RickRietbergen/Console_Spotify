using Spotiy;
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
        public string playlistName { get; set; }
        public static bool isPlaying { get; set; } = false; 
        public static bool paused { get; set; } = false;
        public static int timeElapsed { get; set; } = 0;

        public Playlist(string playlistName, List<Song> songs = null)
        {
            this.playlistName = playlistName;
            Songs = songs ?? new List<Song>();
        }

        public static List<Playlist> AllPlaylists { get; set; } = new List<Playlist>
        {
            new Playlist("cowboy", new List<Song>(Song.AllSongs)),
            new Playlist("queen", new List<Song>(Song.AllSongs.Take(2)))
        };

        public static void ViewPlaylists()
        {
            Console.WriteLine("All playlists:");
            foreach (Playlist playlist in AllPlaylists)
            {
                Console.WriteLine($"- {playlist.playlistName}");
            }
            PlayPlaylist();
        }

        public static void PlayPlaylist()
        {
            Console.WriteLine("To Exit Press Key: Q");
            Console.Write("Choose a playlist: ");
            string selectedPlaylistName = Console.ReadLine();
            Playlist selectedPlaylist = AllPlaylists.FirstOrDefault(p => p.playlistName == selectedPlaylistName);

            if (selectedPlaylistName.ToLower() == "q" || selectedPlaylistName == null)
            {
                Console.Clear();
                return;     
            }
            else
            {
                Console.Clear();
                if (AllPlaylists.Contains(selectedPlaylist))
                {
                    Console.WriteLine("Choose 'shuffle' to play a random song, or choose a song u want to play.");
                    Console.WriteLine($"playlist: '{selectedPlaylistName}':");
                    Console.WriteLine("Songs:");
                    foreach (Song song in selectedPlaylist.Songs)
                    {
                        Console.WriteLine($"-- {song.songName}");
                    }

                    Console.WriteLine("Choose a song:");
                    string songChoice = Console.ReadLine();
                    Song selectedSong;

                    if (songChoice.ToLower() == "shuffle")
                    {
                        Random rand = new Random();
                        selectedSong = Song.AllSongs[rand.Next(0, Song.AllSongs.Count)];
                    }
                    else
                    {
                        selectedSong = Song.AllSongs.FirstOrDefault(s => s.songName == songChoice);
                    }

                    //play the selected song
                    isPlaying = true;
                    int songDuration = selectedSong.songDuration;
                    string songArtist = selectedSong.artistName;

                    if (Song.AllSongs.Contains(selectedSong))
                    {
                        Console.Clear();
                        Console.WriteLine($"Song selected: {selectedSong.songName}");
                        Console.WriteLine($"Artist: {songArtist}");
                        Console.WriteLine($"duration: {songDuration}");

                        while (isPlaying)
                        {
                            if (!paused)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write($"playing... {selectedSong.songName} ({timeElapsed}/{songDuration})");

                                if (timeElapsed > songDuration)
                                {
                                    Console.WriteLine("\nSong finished!");
                                    isPlaying = false;
                                }
                            }

                            if (Console.KeyAvailable)
                            {
                                ConsoleKey key = Console.ReadKey(true).Key;

                                switch (key)
                                {
                                    case ConsoleKey.P:
                                        if (!paused)
                                        {
                                            paused = true;
                                            Console.WriteLine("\nPaused Song.");
                                        }
                                        break;
                                    case ConsoleKey.R:
                                        if (paused)
                                        {
                                            paused = false;
                                            Console.WriteLine($"Resuming song {selectedSong.songName}.");
                                        }
                                        break;
                                    case ConsoleKey.E:
                                        if (paused)
                                        {
                                            timeElapsed = 0;
                                            Console.WriteLine($"Repeating song {selectedSong.songName}");
                                            paused = false;
                                        }
                                        break;
                                    case ConsoleKey.S:
                                        isPlaying = false;
                                        Console.WriteLine("\nSong skipped.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case ConsoleKey.Q:
                                        isPlaying = false;
                                        Console.WriteLine("\nQuitting...");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                }
                            }

                            // wait for 1 second
                            Thread.Sleep(1000);
                            if (!paused)
                            {
                                timeElapsed++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Playlist '{selectedPlaylistName}' does not exist.");
                }
            }
        }

        public static void CreatePlaylist()
        {
            Console.WriteLine("To Exit Press Key: Q");
            Console.WriteLine("Create a new playlist.");
            Console.Write("Enter the name of the playlist: ");
            string newPlaylistName = Console.ReadLine();

            if (newPlaylistName.ToLower() == "q" || newPlaylistName == null)
            {
                Console.Clear();
                return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(newPlaylistName))
                {
                    if (!AllPlaylists.Any(p => p.playlistName == newPlaylistName))
                    {
                        Playlist newPlaylist = new Playlist(newPlaylistName);
                        AllPlaylists.Add(newPlaylist);
                        Console.WriteLine($"Playlist '{newPlaylistName}' has been created.");

                        Console.WriteLine("all playlists:");
                        foreach (Playlist playlist in AllPlaylists)
                        {
                            Console.WriteLine(playlist.playlistName);
                        }
                        Thread.Sleep(2000);
                        Console.Clear();
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
        }

        public static void DeletePlaylist()
        {
            Console.WriteLine("All playlists:");
            foreach (Playlist playlist in AllPlaylists)
            {
                Console.WriteLine(playlist.playlistName);
            }

            Console.WriteLine("To Exit Press Key: Q");
            Console.Write("\nChoose a playlist you want to delete: ");
            string deletePlaylistName = Console.ReadLine();

            if (deletePlaylistName.ToLower() == "q" || deletePlaylistName == null)
            {
                Console.Clear();
                return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(deletePlaylistName))
                {
                    Playlist playlistToDelete = AllPlaylists.FirstOrDefault(p => p.playlistName == deletePlaylistName);
                    if (playlistToDelete != null)
                    {
                        AllPlaylists.Remove(playlistToDelete);
                        Console.WriteLine($"Playlist '{deletePlaylistName}' has been deleted.");

                        Console.WriteLine("all playlists:");
                        foreach (Playlist playlist in AllPlaylists)
                        {
                            Console.WriteLine(playlist.playlistName);
                        }

                        Thread.Sleep(2000);
                        Console.Clear();
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
}
