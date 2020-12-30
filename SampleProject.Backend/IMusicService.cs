using SampleProject.Backend.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Model.MusicService
{
    /// <summary>
    /// Interface what "Client" class must implement.Every method could accept paramethers what you want but would be nice to keep code clean and self-describing.If your service what you implement 
    /// doesent contain implementation of tracks\playlists\artists\albums just delete related methods from interface
    /// </summary>
    public interface IMusicService
    {
        Task<List<Track>> GetPlaylists();
        Task<List<Track>> GetFavorites();
        Task<List<Artist>> GetArtists();
        Task<List<Album>> GetAlbums();
        Task<List<Artist>> SearchArtist(Artist Artist);
        Task<List<Track>> SearchTrack(string SimpleTrack);
        Task SendArtist(params object[] parameters);
        Task SendPlaylist(params object[] parameters);
        Task<object> CreatePlaylist(params object[] parameters);//you can return string\object or you custom class.try to do separate methods of creating playlist and adding tracks to playlist

        Task ShufflePlaylistTracks(Playlist playList);//not a must but would be nice to have
        Task EditPlaylistInfo(Playlist playList, object info);//not a must but would be nice to have
        Task RemoveTrackFromFavorites(Track track);
        Task DeletePlaylist(Playlist playList);//you could accept here as parameter object\class\playlist id or even array of paramethers(i dont recommend)
        Task DeleteTrack(Playlist playList, Track track);//method to delete track from playlist
        Task DeleteAlbum(params object[] parameters);//you could accept here as parameter object\class\album id or even array of paramethers(i dont recommend)

        Task DeleteArtist(params object[] parameters);//you could accept here as parameter object\class\artist id or even array of paramethers(i dont recommend)

        Task AddTrackToPlaylist(Playlist playList, Track track);

        Task AddTrackToFavorites(Track track);

        Task<Deserialize> Authorize(string login, string password);
        Task<ObservableCollection<Playlist>> ParsePlaylistFromJson();
        Task Logout();
        bool IsAuthenticated();
    }
}