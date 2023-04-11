using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Friends
    {
        public static List<Friends> friends { get; set; } = new List<Friends>();
        public List<Playlist> myPlaylist { get; private set; }
        public string friendName {  get; set; }

        public Friends(string friendName, List<Playlist> FriendsPlaylists = null)
        {
            this.friendName = friendName;
            myPlaylist = FriendsPlaylists ?? new List<Playlist>();
        }

        public static List<Friends> AllFriends { get; set; } = new List<Friends>
        {
            new Friends("Justin", new List<Playlist>(Playlist.FriendsPlaylists)),
            new Friends("Tijn", new List<Playlist>(Playlist.FriendsPlaylists)),
            new Friends("Stijn", new List<Playlist>(Playlist.FriendsPlaylists))
        };

        public static void ViewFriends()
        {
            Console.WriteLine("All Friends:");
            foreach (Friends friend in AllFriends)
            {
                Console.WriteLine(friend.friendName);
                ViewPlaylistOfFriends(friend);
            }
        }

        public static void ViewPlaylistOfFriends(Friends friend)
        {
            foreach (Playlist playlist in friend.myPlaylist)
            {
                Console.WriteLine($"- playlist.playlistName");
                foreach (Song song in Song.FriendsSongs)
                {
                    Console.WriteLine(song.songName);
                }
            }
        }
    }
}
