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
            //construstor for playlist
            this.playlistName = playlistName;
            Songs = songs ?? new List<Song>();
        }

        public static List<Playlist> AllPlaylists { get; set; } = new List<Playlist>
        {
            //init 2 playlists
            new Playlist("cowboy", new List<Song>(Song.AllSongs)),
            new Playlist("queen", new List<Song>(Song.AllSongs.Take(2)))
        };

        public static void ViewPlaylists()
        {
            //show all the playlist.
            Console.WriteLine("All playlists:");
            foreach (Playlist playlist in AllPlaylists)
            {
                Console.WriteLine($"- {playlist.playlistName}");
            }
            //execute PlayPlaylist().
            PlayPlaylist();
        }

        public static void PlayPlaylist()
        {
            //ask the user to choose a playlist, or press Q to exit.
            Console.WriteLine("To Exit Press Key: Q");
            Console.Write("Choose a playlist: ");
            string selectedPlaylistName = Console.ReadLine();
            //check if AllPlaylists contains a playlist that the user has entered.
            Playlist selectedPlaylist = AllPlaylists.FirstOrDefault(p => p.playlistName == selectedPlaylistName);

            if (selectedPlaylistName.ToLower() == "q" || selectedPlaylistName == null)
            {
                //clear console and return if Q isPressed, orselectedPlaylistName == null
                Console.Clear();
                return;     
            }
            else
            {
                //clear console, if AllPlaylists contains the entered playlist then execute the if, else return error message that playlist does nog exist.
                Console.Clear();
                if (AllPlaylists.Contains(selectedPlaylist))
                {
                    //ask user to shuffle or select a song from playlist.
                    Console.WriteLine("Choose 'shuffle' to play a random song, or choose a song u want to play.");
                    Console.WriteLine($"playlist: '{selectedPlaylistName}':");
                    Console.WriteLine("Songs:");
                    //write all songnames in a playlist.
                    foreach (Song song in selectedPlaylist.Songs)
                    {
                        Console.WriteLine($"-- {song.songName}");
                    }
                    //choose a song
                    Console.WriteLine("Choose a song:");
                    string songChoice = Console.ReadLine();
                    Song selectedSong;

                    //if songChoice == shuffle, then play a random song from playlist.
                    if (songChoice.ToLower() == "shuffle")
                    {
                        Random rand = new Random();
                        selectedSong = Song.AllSongs[rand.Next(0, Song.AllSongs.Count)];
                    }
                    //else play entered song.
                    else
                    {
                        selectedSong = Song.AllSongs.FirstOrDefault(s => s.songName == songChoice);
                    }

                    //play the selected song
                    //set isPlaying to true to enter the while loop if the song is contained in the playlist.
                    isPlaying = true;
                    int songDuration = selectedSong.songDuration;
                    string songArtist = selectedSong.artistName;

                    if (Song.AllSongs.Contains(selectedSong))
                    {
                        //clear console and show data of song. name, artist, durartion of song.
                        Console.Clear();
                        Console.WriteLine($"Song selected: {selectedSong.songName}");
                        Console.WriteLine($"Artist: {songArtist}");
                        Console.WriteLine($"duration: {songDuration}");

                        //while isPlaying == true then execute this code.
                        while (isPlaying)
                        {
                            if (!paused)
                            {
                                //if paused == false then show that the song is playing.
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write($"playing... {selectedSong.songName} ({timeElapsed}/{songDuration})");

                                if (timeElapsed > songDuration)
                                {
                                    //if time is greater then songduration. stop playing en write that the song is finished.
                                    Console.WriteLine("\nSong finished!");
                                    isPlaying = false;
                                }
                            }

                            //check if a key is pressed
                            if (Console.KeyAvailable)
                            {
                                ConsoleKey key = Console.ReadKey(true).Key;

                                switch (key)
                                {
                                    case ConsoleKey.P:
                                        if (!paused)
                                        {
                                            //if P is pressed, then check if paused == false the set paused to true, and write that the song is paused.
                                            paused = true;
                                            Console.WriteLine("\nPaused Song.");
                                        }
                                        break;
                                    case ConsoleKey.R:
                                        if (paused)
                                        {
                                            //if R is pressed, then check if paused == ture the set paused to false, and write that the song is resuming with the name of the song.
                                            paused = false;
                                            Console.WriteLine($"Resuming song {selectedSong.songName}.");
                                        }
                                        break;
                                    case ConsoleKey.E:
                                        if (paused)
                                        {
                                            //if E is pressed, then check if paused == ture the set timeElapsed = 0, write that the song is repeating with the name of the song, and set pause to false.
                                            timeElapsed = 0;
                                            Console.WriteLine($"Repeating song {selectedSong.songName}");
                                            paused = false;
                                        }
                                        break;
                                    case ConsoleKey.S:
                                        //if E is pressed, isPlaying to false, write that the song is skipped and clear console after 2 sec.
                                        isPlaying = false;
                                        Console.WriteLine("\nSong skipped.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case ConsoleKey.Q:
                                        //if E is pressed, isPlaying to false, write that ur quitting and clear console after 2 sec.
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
