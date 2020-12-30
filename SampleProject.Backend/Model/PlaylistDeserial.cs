using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Backend.Model
{
    public class PlaylistDeserial
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string PermaLink { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Privat { get; set; }

        public string Uri { get; set; }

        public string PermalinkUrl { get; set; }

        public string Thumb { get; set; }

        public string ArtworkUrl { get; set; }

        public string TrackCount { get; set; }

        public User User { get; set; }

        public string Username { get; set; }

        public string AvatarUrl { get; set; }
    }

}
