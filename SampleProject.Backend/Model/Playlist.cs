using PropertyChanged;
using System.Collections.Generic;

namespace SampleProject.Backend.Model
{
    /// <summary>
    /// You dont need to fill all field.Only if you have same on api\info ypu get from site
    /// </summary>
    [AddINotifyPropertyChangedInterface]//attribute what dedicated to fix all the problems with INotifyPropertyChanged interface(you dont need to call RaisePropertyChanged() on every property)
    public class Playlist : ModelBase
    {
        public Playlist(string playlistName, List<Track> tracks)
        {
            PlaylistName = playlistName;
            AllTracks = tracks;
        }
        public string PlaylistName { get; set; }
        public string Id { get; set; }
        public List<Track> AllTracks { get; set; }
    }
}

