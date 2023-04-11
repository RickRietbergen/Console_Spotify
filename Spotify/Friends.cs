using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Friends
    {
        //properties.
        public static List<Friends> friends { get; set; } = new List<Friends>();
        public List<Playlist> myPlaylist { get; private set; }
        public string friendName {  get; set; }

        public Friends(string friendName, List<Playlist> FriendsPlaylists = null)
        {
            //constructor for Friends().
            this.friendName = friendName;
            myPlaylist = FriendsPlaylists ?? new List<Playlist>();
        }

        public static List<Friends> AllFriends { get; set; } = new List<Friends>
        {
            //init 3 friends and set a playlist for each friend.
            new Friends("Justin", new List<Playlist>(Playlist.FriendsPlaylists)),
            new Friends("Tijn", new List<Playlist>(Playlist.FriendsPlaylists)),
            new Friends("Stijn", new List<Playlist>(Playlist.FriendsPlaylists))
        };

        public static void ViewFriends()
        {
            //show all friends names.
            Console.WriteLine("All Friends:");
            foreach (Friends friend in AllFriends)
            {
                Console.WriteLine(friend.friendName);
                ViewPlaylistOfFriends(friend);
            }
        }

        public static void ViewPlaylistOfFriends(Friends friend)
        {
            //show playlistname and song for each friend.
            foreach (Playlist playlist in friend.myPlaylist)
            {
                Console.WriteLine($"- playlist.playlistName");
                foreach (Song song in Song.FriendsSongs)
                {
                    Console.WriteLine(song.songName);
                }
            }
        }

        public static void ComparePlaylist()
        {
            //show all playlists and ask user which playlist to compare.
            Console.WriteLine("Enter the name of your playlist:");
            foreach (Playlist ownplaylist in Playlist.AllPlaylists)
            {
                Console.WriteLine(ownplaylist.playlistName);
            }

            string myOwnPlaylist = Console.ReadLine();
            //loop through each playlist and find playlist where Playlistname == playlistname.
            Playlist OwnPlaylist = Playlist.AllPlaylists.Find(p => p.playlistName == myOwnPlaylist);

            //check if OwnPlaylist == null, if true then exit.
            if (OwnPlaylist == null)
            {
                Console.WriteLine($"Playlist {OwnPlaylist} not found.");
                Thread.Sleep(2000);
                return;
            }
            //clear console and show all playlists of friend
            Console.Clear();
            Console.WriteLine("Enter the name of your friends playlist:");
            foreach (Playlist friendplaylist in Playlist.FriendsPlaylists)
            {
                Console.WriteLine(friendplaylist.playlistName);
            }

            string myfriendsPlaylist = Console.ReadLine();
            //loop through each playlist and find playlist where Playlistname == playlistname for friend.
            Playlist FriendsPlaylist = Playlist.FriendsPlaylists.Find(p => p.playlistName == myfriendsPlaylist);

            //check if FriendsPlaylist == null, if true then exit.
            if (FriendsPlaylist == null)
            {
                Console.WriteLine($"Playlist {FriendsPlaylist} not found.");
                Thread.Sleep(2000);
                return;
            }

            // Compare the songs between the two playlists.
            List<Song> commonSongs = new List<Song>();
            foreach (Song ownSong in OwnPlaylist.Songs)
            {
                foreach (Song friendSong in FriendsPlaylist.Songs)
                {
                    if (ownSong.songName == friendSong.songName)
                    {
                        commonSongs.Add(ownSong);
                        break; // Exit the inner loop once a common song is found.
                    }
                }
            }

            //show how many songs are in common.
            Console.WriteLine($"Your playlist '{myOwnPlaylist}' and your friend's playlist '{FriendsPlaylist.playlistName}' have {commonSongs.Count} songs in common:");
            foreach (Song song in commonSongs)
            {
                Console.WriteLine($"- {song.songName}");
            }
            //after 2 sec, clear console.
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
