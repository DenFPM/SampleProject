using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Model.MusicService;
using SampleProject.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleProject.Backend
{
    /// <summary>
    /// Class what implements all functionality from IMusicService
    /// </summary>
    public class Client : IMusicService
    {
        private static readonly HttpClient client = new HttpClient();
        public Task AddTrackToFavorites(Track track)
        {
            throw new NotImplementedException();
        }

        public Task AddTrackToPlaylist(Playlist playList, Track track)
        {
            throw new NotImplementedException();
        }

        public Task Authorize()
        {
            throw new NotImplementedException();
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
