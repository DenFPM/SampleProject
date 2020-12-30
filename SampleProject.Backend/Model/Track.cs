using PropertyChanged;
using System.Data;

namespace SampleProject.Backend.Model
{
    /// <summary>
    /// You dont need to fill all field.Only if you have same on api\info ypu get from site
    /// </summary>
    [AddINotifyPropertyChangedInterface]//attribute what dedicated to fix all the problems with INotifyPropertyChanged interface(you dont need to call RaisePropertyChanged() on every property)
    public class Track : ModelBase
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public string ImageLink { get; set; }
        public string Artist { get; set; }
        public Track()
        {

        }
        public Track(string artist, string title, string duration, string imageLink)
        {
            Artist = artist;
            Title = title;
            Duration = duration;
            ImageLink = imageLink;
        }

    }
}

