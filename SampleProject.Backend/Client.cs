using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Model.MusicService;
using Newtonsoft.Json;
using SampleProject.Backend.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleProject.Backend
{
    /// <summary>
    /// Class what implements all functionality from IMusicService
    /// 
    /// </summary>
    public class Client : IMusicService
    {

        private static readonly HttpClient client = new HttpClient();
        public ObservableCollection<Playlist> Playlists { get; private set; } = new ObservableCollection<Playlist>();
        
        public async Task<ObservableCollection<Playlist>> ParsePlaylistFromJson()
        {
            string playlistInfoJson = "";
            using (StreamReader sr = new StreamReader(@$"{Directory.GetCurrentDirectory()}\user.json"))
            {
                playlistInfoJson = await sr.ReadToEndAsync();
            }
            Deserialize dsObj = JsonConvert.DeserializeObject<Deserialize>(playlistInfoJson);

            await GetPlaylist(dsObj.UserName);
            
            return Playlists;
        }
        public async Task GetPlaylist(string username)
        {
            var response = await client.GetAsync($@"http://api-v2.hearthis.at/{username.ToLower()}/?type=playlists");

            string orderJson = await response.Content.ReadAsStringAsync();

            PlaylistDeserial ObjOrderList = new PlaylistDeserial();

            List<PlaylistDeserial> products = JsonConvert.DeserializeObject<List<PlaylistDeserial>>(orderJson);

            if (products.Count == 0)
            {
                throw new ArgumentNullException("playlist is empty");
            }

            foreach(PlaylistDeserial playlist in products)
            {
                Playlists.Add(new Playlist(playlist.Title, await GetSongsFromCurentPlaylist(playlist.Uri)));
            }
        }
        public async Task<List<Track>> GetSongsFromCurentPlaylist(string uri)
        {
            var response = await client.GetAsync(uri);

            string orderJson = await response.Content.ReadAsStringAsync();

            List<DeserializeSong> productsOfPlaylist = JsonConvert.DeserializeObject<List<DeserializeSong>>(orderJson);
            List<Track> tracks = new List<Track>();

            int durationInt;

            foreach(DeserializeSong song in productsOfPlaylist)
            {
                durationInt = Convert.ToInt32(song.Duration);

                TimeSpan timeSpan = TimeSpan.FromSeconds(durationInt);
                DateTime dateTime = DateTime.Today.Add(timeSpan);
                string displayTime = dateTime.ToString("mm:ss");

                if (durationInt > 3600)
                {
                    displayTime = dateTime.ToString("hh:mm:ss");

                    tracks.Add(new Track(song.User.UserName, song.Title, displayTime , song.Thumb));

                    continue;
                }
                tracks.Add(new Track(song.User.UserName, song.Title, displayTime, song.Thumb));
            }
            return tracks;
        }
    
       
        public Task AddTrackToFavorites(Track track)
        {
            throw new NotImplementedException();
        }

        public Task AddTrackToPlaylist(Playlist playList, Track track)
        {
            throw new NotImplementedException();
        }

        public async Task<Deserialize> Authorize(string login, string password)
        {
            var values = new Dictionary<string, string>
            {
                  { "action", "login" },
                  { "email", login },
                  {"password", password }
            };
            try
            {
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api-v2.hearthis.at/login/", content);

                var responseString = response.Content.ReadAsStringAsync();

                using (FileStream fstream = new FileStream(@$"{Directory.GetCurrentDirectory()}\user.json", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(responseString.Result);
                    fstream.Write(array, 0, array.Length);
                }

                Deserialize bsObj2 = JsonConvert.DeserializeObject<Deserialize>(responseString.Result);
                return bsObj2;
                
            }
            catch (HttpRequestException ex)
            {
                return new Deserialize();
            }

        }

        public Task<object> CreatePlaylist(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAlbum(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArtist(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlaylist(Playlist playList)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrack(Playlist playList, Track track)
        {
            throw new NotImplementedException();
        }

        public Task EditPlaylistInfo(Playlist playList, object info)
        {
            throw new NotImplementedException();
        }

        public Task<List<Album>> GetAlbums()
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> GetArtists()
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> GetFavorites()
        {
            throw new NotImplementedException();
        }
       
        public async Task<List<Track>> GetPlaylists()
        {
            throw new NotImplementedException();
        }
       
        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTrackFromFavorites(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> SearchArtist(Artist Artist)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> SearchTrack(string SimpleTrack)
        {
            throw new NotImplementedException();
        }

        public Task SendArtist(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task SendPlaylist(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task ShufflePlaylistTracks(Playlist playList)
        {
            throw new NotImplementedException();
        }
    }
}
