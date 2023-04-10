﻿using System;
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
                        //view playlist function, get all playlists.
                        Playlist.ViewPlaylists();
                        break;
                    case "2" or "manage-playlists":
                        //ask user which option you want to execute.
                        Console.WriteLine("1. create-playlist");
                        Console.WriteLine("2. delete-playlist");
                        Console.WriteLine("Choose an option:");
                        //create var with awnser and go to selected function
                        string choiceManagePlaylists = Console.ReadLine();

                        switch (choiceManagePlaylists)
                        {
                            case "1" or "create-playlist":
                                Playlist.CreatePlaylist();
                                break; 
                            case "2" or "delete-playlist":
                                Playlist.DeletePlaylist();
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                        break;
                    case "3" or "manage-song":
                        Console.WriteLine("1. add-song");
                        Console.WriteLine("2. delete-song");
                        string choiceManagesongs = Console.ReadLine();

                        switch (choiceManagesongs)
                        {
                            case "1" or "add-song":
                                Song.AddSong();
                                break;
                            case "2" or "delete-song":
                                Song.RemoveSong();
                                break;
                        }
                        break;
                    case "4" or "view-albums":
                        Album.ViewAlbums();
                        break;
                    case "5" or "add-album-to-playlist":
                        Album.AddAlbumToPlaylist();
                        break;
                    case "6" or "view-friends":
                        Console.WriteLine("view-friends");
                        break;
                    case "7":
                        Song.ViewSongs();
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
            Console.WriteLine("<--- Commands --->");
            Console.WriteLine("====================");
            //1. view all the playlists, choose one to view the songs inside the chosen playlist. choose shuffle or select a song, then see whats playing, when playing give options to pause/continue, skip, repeat or quit.
            Console.WriteLine("1. view-playlists");
            //2. goes to another readline where u can create, delete playlists.
            Console.WriteLine("2. manage-playlists");
            // 3. select the playlist where u want to add a songs, or delete songs.
            Console.WriteLine("3. manage-song");
            //4. view all the albums, choose albums or exit the option, suffle album or choose song from album then see whats playing, when playing give options to pause/continue, repeat or quit.
            Console.WriteLine("4. view-albums");
            // 5. add album to a playlist, choose which playlist u want to add the album to. 
            Console.WriteLine("5. add-album-to-playlist");
            // 6. see ur friends, friends also have playlists(hardcoded). see which songs in playlists are the same.
            Console.WriteLine("6. view-friends");
            Console.WriteLine("====================");
        }
    }
}