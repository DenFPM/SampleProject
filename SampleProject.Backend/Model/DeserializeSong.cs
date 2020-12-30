using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Backend.Model
{
    public class DeserializeSong
    {
        public string Id { get; set; }

        public string Private { get; set; }

        public string CreatedAt { get; set; }

        public string ReleaseDate { get; set; }

        public string ReleaseTimestamp { get; set; }

        public string UserId { get; set; }

        public string Duration { get; set; }

        public string PermaLink { get; set; }

        public string Description { get; set; }


        public string Geo { get; set; }

        public string ags { get; set; }

        public User TagedArtists { get; set; }

        public string Bpm { get; set; }

        public string Key { get; set; }

        public string License { get; set; }

        public string Version { get; set; }

        public string Type { get; set; }

        public string Downloadable { get; set; }

        public string Genre { get; set; }

        public string GenreSlush { get; set; }

        public string Title { get; set; }

        public string Uri { get; set; }

        public string PermaLinkUrl { get; set; }

        public string Thumb { get; set; }

        public string ArtworkUrl { get; set; }

        public string ArtworkUrlRetina { get; set; }

        public string BackgroundUrl { get; set; }

        public string WaveformData { get; set; }

        public string WaveformUrl { get; set; }

        public User User { get; set; }

        public string StreamUrl { get; set; }

        public string PreviewUrl { get; set; }

        public string DownloadUrl { get; set; }

        public string DownloadFilename { get; set; }

        public string PlaybackCount { get; set; }

        public string DownloadCount { get; set; }

        public string FavoritingsCount { get; set; }

        public string ResharesCount { get; set; }

        public string CommentCount { get; set; }

        public string Played { get; set; }

        public string Favorited { get; set; }

        public string Liked { get; set; }

        public string Reshared { get; set; }
    }
}
