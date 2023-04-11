using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Album
    {
        //properties.
        public static List<Album> Albums { get; set; } = new List<Album>();
        public string albumName { get; set; }
        public string albumArtistName { get; set; }
        public static bool isPlaying { get; set; } = false;
        public static bool paused { get; set; } = false;
        public static int timeElapsed { get; set; } = 0;
        public List<Song> songs { get; private set; }

        public Album(string albumName, string albumArtistName, List<Song> AllAlbumSongs = null)
        {
            //construstor for Album
            this.albumName = albumName;
            this.albumArtistName = albumArtistName;
            songs = AllAlbumSongs ?? new List<Song>();
        }
        public static List<Album> AllAlbums { get; set; } = new List<Album>
        {
            //create instance of allAlbums.
            new Album("nirvana", "nirvana", new List<Song>(Song.AllAlbumSongs))
        };

        public static void ViewAlbums()
        {
            //show all albums.
            Console.WriteLine("All albums:");
            foreach (Album albums in AllAlbums)
            {
                Console.WriteLine($"- {albums.albumName}");
            }
            //execute PlayAlbum().
            PlayAlbum();
        }

        public static void PlayAlbum()
        {
            //ask the user to choose a album, or press Q to exit.
            Console.WriteLine("To Exit Press Key: Q");
            Console.Write("Choose an album: ");
            string selectedAlbumName = Console.ReadLine();
            //check if allAlbums contains a album that the user has entered.
            Album selectedAlbum = Album.AllAlbums.FirstOrDefault(a => a.albumName == selectedAlbumName);

            if (selectedAlbumName.ToLower() == "q" || selectedAlbumName == null)
            {
                //clear console and return if Q isPressed, or if selectedAlbumName == null
                Console.Clear();
                return;
            }
            else
            {
                //ask user to shuffle or select a song from album.
                Console.Clear();
                if (Album.AllAlbums.Contains(selectedAlbum))
                {
                    Console.WriteLine("Choose 'shuffle' to play a random song, or choose a song you want to play.");
                    Console.WriteLine($"album: '{selectedAlbumName}':");
                    //show all songs from album.
                    Console.WriteLine("Songs:");
                    foreach (Song songs in Song.AllAlbumSongs)
                    {
                        Console.WriteLine($"-- {songs.songName}");
                    }

                    Console.WriteLine("Choose a song:");
                    string songChoice = Console.ReadLine();
                    Song selectedSong;

                    //if songChoice == shuffle, then play a random song from the album
                    if (songChoice.ToLower() == "shuffle")
                    {
                        Random rand = new Random();
                        selectedSong = selectedAlbum.songs[rand.Next(0, selectedAlbum.songs.Count)];
                    }
                    //else play entered song
                    else
                    {
                        selectedSong = selectedAlbum.songs.FirstOrDefault(s => s.songName == songChoice);
                    }

                    //play the selected song
                    //set isPlaying to true to enter the while loop if the song is contained in the album.
                    isPlaying = true;
                    int songDuration = selectedSong.songDuration;
                    string songArtist = selectedSong.artistName;

                    if (selectedSong == null)
                    {
                        Console.WriteLine("album doesnt contain song");
                        return;
                    }
                        //clear console and show data of song. name, artist, durartion of song that is playing.
                        Console.Clear();
                        Console.WriteLine($"Song selected: {selectedSong.songName}");
                        Console.WriteLine($"Artist: {songArtist}");
                        Console.WriteLine($"Duration: {songDuration}");

                        //while isPlaying == true then execute this code.
                        while (isPlaying)
                        {
                            if (!paused)
                            {
                                //if paused == false then show that the song is playing with the timer that updates each second.
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write($"playing... {selectedSong.songName} ({timeElapsed}/{songDuration})");

                                //if timeElapsed is greater then songduration. stop playing en write that the song is finished.
                                if (timeElapsed > songDuration)
                                {
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
                                        //if S is pressed, isPlaying to false, write that the song is skipped and clear console after 2 sec.
                                        isPlaying = false;
                                        Console.WriteLine("\nSong skipped.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case ConsoleKey.Q:
                                        //if Q is pressed, isPlaying to false, write that ur quitting and clear console after 2 sec.
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
                                //add 1 to timeElapsed each second when playing.
                                timeElapsed++;
                            }
                        }
                    
                }
                else
                {
                    //write that albumName does not exist.
                    Console.WriteLine($"Album '{selectedAlbumName}' does not exist.");
                }
            }
        }

        public static void AddAlbumToPlaylist()
        {
            //show all albums
            Console.WriteLine("All albums:");
            foreach (Album album in AllAlbums)
            {
                Console.WriteLine($"- {album.albumName}");
            }

            //ask user to enter the name of the album you want to add to a specific playlist.
            Console.WriteLine("Which album do you want to add to a playlist:");
            string choiceAlbumName = Console.ReadLine();
            //loop through AllAlbums and check if there is a albumSongName that is equal to choiceAlbumName.
            Album selectedAlbum = Album.AllAlbums.FirstOrDefault(a => a.albumName == choiceAlbumName);

            //check entered input if choiceAlbumName is equal to Q, or choiceAlbumName/selectedAlbum are equal to null.
            if (choiceAlbumName.ToLower() == "q" || choiceAlbumName == null || selectedAlbum == null)
            {
                Console.WriteLine($"Album {choiceAlbumName} does not exist.");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }
            else
            {
                //show all playlists.
                Console.WriteLine("All playlists:");
                foreach (Playlist playlist in Playlist.AllPlaylists)
                {
                    Console.WriteLine($"- {playlist.playlistName}");
                }

                //ask user to enter a name of a playlist.
                Console.WriteLine("Enter the name of the playlist to add the album songs to:");
                string choicePlaylistName = Console.ReadLine();
                //loop through all playlist and see if there's a playlistname that is equal to entered name.
                Playlist chosenPlaylist = Playlist.AllPlaylists.Find(p => p.playlistName == choicePlaylistName);

                if (chosenPlaylist != null)
                {
                    foreach (Song song in selectedAlbum.songs)
                    {
                        //
                        chosenPlaylist.Songs.Add(song);
                    }
                
                    Console.WriteLine($"Added {selectedAlbum.songs.Count} songs from the '{selectedAlbum.albumName}' album to the '{chosenPlaylist.playlistName}' playlist.");
                }
                else
                {
                    Console.WriteLine($"Playlist '{choicePlaylistName}' not found.");
                    return;
                    
                }
            }
        }       
    }
}
