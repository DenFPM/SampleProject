using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.ViewModel
{
    public class Deserialize1
    {
        [JsonProperty("id")]
        public string id { get; set; }


        [JsonProperty("permalink")]
        public string permalink { get; set; }


        [JsonProperty("username")]
        public string username { get; set; }


        [JsonProperty("caption")]
        public string caption { get; set; }


        [JsonProperty("uri")]
        public string uri { get; set; }


        [JsonProperty("permalink_url")]
        public string permalink_url { get; set; }


        [JsonProperty("thumb_url")]
        public string thumb_url { get; set; }


        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }


        [JsonProperty("p_url")]
        public string p_url { get; set; }


        [JsonProperty("background_url")]
        public string background_url { get; set; }


        [JsonProperty("description")]
        public string description { get; set; }


        [JsonProperty("geo")]
        public string geo { get; set; }


        [JsonProperty("track_count")]
        public string track_count { get; set; }


        [JsonProperty("playlist_count")]
        public string playlist_count { get; set; }


        [JsonProperty("likes_count")]
        public string likes_count { get; set; }


        [JsonProperty("followers_count")]
        public string followers_count { get; set; }


        [JsonProperty("following_count")]
        public string following_count { get; set; }


        [JsonProperty("following")]
        public string following { get; set; }


        [JsonProperty("premium")]
        public string premium { get; set; }


        [JsonProperty("allow_push")]
        public string allow_push { get; set; }


        [JsonProperty("email")]
        public string email { get; set; }


        [JsonProperty("locale")]
        public string locale { get; set; }


        [JsonProperty("secret")]
        public string secret { get; set; }


        [JsonProperty("key")]
        public string key { get; set; }


        [JsonProperty("success")]
        public bool success { get; set; }


        [JsonProperty("message")]
        public string message { get; set; }


        [JsonProperty("timestamp")]
        public string timestamp { get; set; }

    }
    public class DeserializeSong
    {
        [JsonProperty("id")]
        public string id { get; set; }


        [JsonProperty("private")]
        public string private1 { get; set; }


        [JsonProperty("created_at")]
        public string created_at { get; set; }


        [JsonProperty("release_date")]
        public string release_date { get; set; }


        [JsonProperty("release_timestamp")]
        public string release_timestamp { get; set; }


        [JsonProperty("user_id")]
        public string user_id { get; set; }


        [JsonProperty("duration")]
        public string duration { get; set; }


        [JsonProperty("permalink")]
        public string permalink { get; set; }


        [JsonProperty("description")]
        public string description { get; set; }


        [JsonProperty("geo")]
        public string geo { get; set; }


        [JsonProperty("tags")]
        public string tags { get; set; }


        [JsonProperty("taged_artists")]
        public user taged_artists { get; set; }


        [JsonProperty("bpm")]
        public string bpm { get; set; }


        [JsonProperty("key")]
        public string key { get; set; }


        [JsonProperty("license")]
        public string license { get; set; }


        [JsonProperty("version")]
        public string version { get; set; }


        [JsonProperty("type")]
        public string type { get; set; }


        [JsonProperty("downloadable")]
        public string downloadable { get; set; }


        [JsonProperty("genre")]
        public string genre { get; set; }


        [JsonProperty("genre_slush")]
        public string genre_slush { get; set; }


        [JsonProperty("title")]
        public string title { get; set; }


        [JsonProperty("uri")]
        public string uri { get; set; }


        [JsonProperty("permalink_url")]
        public string permalink_url { get; set; }


        [JsonProperty("thumb")]
        public string thumb { get; set; }


        [JsonProperty("artwork_url")]
        public string artwork_url { get; set; }


        [JsonProperty("artwork_url_retina")]
        public string artwork_url_retina { get; set; }


        [JsonProperty("background_url")]
        public string background_url { get; set; }


        [JsonProperty("waveform_data")]
        public string waveform_data { get; set; }


        [JsonProperty("waveform_url")]
        public string waveform_url { get; set; }


        [JsonProperty("user")]
        public user user { get; set; }


        [JsonProperty("stream_url")]
        public string stream_url { get; set; }


        [JsonProperty("preview_url")]
        public string preview_url { get; set; }


        [JsonProperty("download_url")]
        public string download_url { get; set; }


        [JsonProperty("download_filename")]
        public string download_filename { get; set; }


        [JsonProperty("playback_count")]
        public string playback_count { get; set; }


        [JsonProperty("download_count")]
        public string download_count { get; set; }


        [JsonProperty("favoritings_count")]
        public string favoritings_count { get; set; }


        [JsonProperty("reshares_count")]
        public string reshares_count { get; set; }


        [JsonProperty("comment_count")]
        public string comment_count { get; set; }


        [JsonProperty("played")]
        public string played { get; set; }


        [JsonProperty("favorited")]
        public string favorited { get; set; }


        [JsonProperty("liked")]
        public string liked { get; set; }


        [JsonProperty("reshared")]
        public string reshared { get; set; }
    }


    public class PlaylistDeserial
    {
        [JsonProperty("id")]
        public string id { get; set; }


        [JsonProperty("user_id")]
        public string user_id { get; set; }


        [JsonProperty("permalink")]
        public string permalink { get; set; }


        [JsonProperty("title")]
        public string title { get; set; }


        [JsonProperty("description")]
        public string description { get; set; }


        [JsonProperty("privat")]
        public string privat { get; set; }


        [JsonProperty("uri")]
        public string uri { get; set; }


        [JsonProperty("permalink_url")]
        public string permalink_url { get; set; }


        [JsonProperty("thumb")]
        public string thumb { get; set; }


        [JsonProperty("artwork_url")]
        public string artwork_url { get; set; }


        [JsonProperty("track_count")]
        public string track_count { get; set; }


        [JsonProperty("user")]
        public user user { get; set; }


        [JsonProperty("username")]
        public string username { get; set; }


        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }
    }
    public class user
    {
        [JsonProperty("id")]
        public string id { get; set; }


        [JsonProperty("permalink")]
        public string permalink { get; set; }


        [JsonProperty("username")]
        public string username { get; set; }


        [JsonProperty("caption")]
        public string caption { get; set; }


        [JsonProperty("uri")]
        public string uri { get; set; }


        [JsonProperty("permalink_url")]
        public string permalink_url { get; set; }


        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }
    }
}
