using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Album
    {
        public List<Album> Albums { get; set; }
        public string albumSongName { get; set; }
        public string albumArtistName { get; set; }
        public int songDuration { get; set; }
        public static bool isPlaying { get; set; } = false;
        public static bool paused { get; set; } = false;
        public static int timeElapsed { get; set; } = 0;

        public Album(string albumSongName, string albumArtistName, int songDuration)
        {
            this.albumSongName = albumSongName;
            this.albumArtistName = albumArtistName;
            this.songDuration = songDuration;
            Albums = new List<Album>();
        }

        public Album(string albumSongName, List<Album> allAlbumSongs = null)
        {
            this.albumSongName = albumSongName;
            allAlbumSongs = allAlbumSongs ?? new List<Album>();
        }

        public static List<Album> allAlbumSongs { get; set; } = new List<Album>
        {
            new Album("smells like teen spirit", "nirvana", 120),
            new Album("come as you are", "nirvana", 140),
            new Album("the man who sold the world", "Nirvana", 160),
            new Album("about a girl", "Nirvana", 180),
            new Album("polly", "Nirvana", 200)
        };

        public static List<Album> AllAlbums { get; set; } = new List<Album>
        {
            new Album("nirvana", new List<Album>(allAlbumSongs))
        };

        public static void ViewAlbums()
        {
            Console.WriteLine("All albums:");
            foreach (Album albums in AllAlbums)
            {
                Console.WriteLine($"- {albums.albumSongName}");
            }
            PlayAlbum();
        }

        public static void PlayAlbum()
        {
            Console.WriteLine("To Exit Press Key: Q");
            Console.Write("Choose an album: ");
            string selectedAlbumName = Console.ReadLine();
            Album selectedAlbum = Album.AllAlbums.FirstOrDefault(a => a.albumSongName == selectedAlbumName);

            if (selectedAlbumName.ToLower() == "q" || selectedAlbumName == null)
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                if (Album.AllAlbums.Contains(selectedAlbum))
                {
                    Console.WriteLine("Choose 'shuffle' to play a random song, or choose a song you want to play.");
                    Console.WriteLine($"album: '{selectedAlbumName}':");
                    Console.WriteLine("Songs:");
                    foreach (Album albums in allAlbumSongs)
                    {
                        Console.WriteLine($"-- {albums.albumSongName}");
                    }

                    Console.WriteLine("Choose a song:");
                    string songChoice = Console.ReadLine();
                    Album selectedSong;

                    if (songChoice.ToLower() == "shuffle")
                    {
                        Random rand = new Random();
                        selectedSong = Album.allAlbumSongs[rand.Next(0, Album.allAlbumSongs.Count)];
                    }
                    else
                    {
                        selectedSong = Album.allAlbumSongs.FirstOrDefault(s => s.albumSongName == songChoice);
                    }

                    //play the selected song
                    isPlaying = true;
                    int songDuration = selectedSong.songDuration;
                    string songArtist = selectedSong.albumArtistName;

                    if (allAlbumSongs.Contains(selectedSong))
                    {
                        Console.Clear();
                        Console.WriteLine($"Song selected: {selectedSong.albumSongName}");
                        Console.WriteLine($"Artist: {songArtist}");
                        Console.WriteLine($"Duration: {songDuration}");

                        while (isPlaying)
                        {
                            if (!paused)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write($"playing... {selectedSong.albumSongName} ({timeElapsed}/{songDuration})");

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
                                            Console.WriteLine($"Resuming song {selectedSong.albumSongName}.");
                                        }
                                        break;
                                    case ConsoleKey.E:
                                        if (paused)
                                        {
                                            timeElapsed = 0;
                                            Console.WriteLine($"Repeating song {selectedSong.albumSongName}");
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
                                        timeElapsed = 0;
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
                    Console.WriteLine($"Album '{selectedAlbumName}' does not exist.");
                }
            }
        }
    }
}
