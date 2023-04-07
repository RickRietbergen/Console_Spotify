using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Timers;
using System.Media;
using Spotify;

namespace Spotiy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the spotify app!");
            Console.WriteLine("Make by: Rick");
            Console.WriteLine("===========================");

            while (true)
            {
                //show commands
                commands();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1" or "view-playlists":
                        Playlist.ViewPlaylists();
                        break;
                    case "2" or "manage-playlists":
                        Console.WriteLine("1. create-playlist");
                        Console.WriteLine("2. delete-playlist");
                        Console.WriteLine("Choose an option:");
                        string choiceManagePlaylists = Console.ReadLine();

                        switch (choiceManagePlaylists)
                        {
                            case "1" or "play":
                                Playlist.PlayPlaylist();
                                break;
                            case "2" or "create-playlist":
                                Playlist.CreatePlaylist();
                                break; 
                            case "3" or "delete-playlist":
                                Playlist.DeletePlaylist();
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                        break;
                    case "3" or "manage-song":
                        Console.WriteLine("manage-song");
                        break;
                    case "4" or "view-albums":
                        Console.WriteLine("view-albums");
                        break;
                    case "5" or "manage-albums":
                        Console.WriteLine("manage-albums");
                        break;
                    case "6" or "view-friends":
                        Console.WriteLine("view-friends");
                        break;
                    case "7":
                        Song.ViewSongs();
                        break;
                    case "8":
                        Song.AddSong();
                        break;
                    case "9":
                        Song.RemoveSong();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            Console.Read();
        }

        public static void commands()
        {
            Console.WriteLine("-- Commands --");
            Console.WriteLine("====================");
            //1. view all the playlists, choose one to view the songs inside the chosen playlist. choose shuffle or select a song, then see whats playing, when playing give options to pause/continue, repeat or quit.
            Console.WriteLine("1. view-playlists");
            //2. goes to another readline where u can create, delete playlists or delete songs
            Console.WriteLine("2. manage-playlists");
            // 3. select the playlist u want to add a songs, see the hardcoded songs. then give mssg that the song has been added.
            Console.WriteLine("3. manage-song");
            //4. view all the albums, choose albums or exit the option, suffle album or choose song from album then see whats playing, when playing give options to pause/continue, repeat or quit.
            Console.WriteLine("4. view-albums");
            // 5. set readline, choose to add a album to playlist, 
            Console.WriteLine("5. manage-albums");
            // 6. see ur friends, friends also have playlists(hardcoded). see which songs in playlists are the same.
            Console.WriteLine("6. view-friends");
            Console.WriteLine("====================");
        }
    }
}