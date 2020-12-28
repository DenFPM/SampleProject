using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using Microsoft.Win32;
using SampleProject.Backend.Model;
using SampleProject.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Collections.ObjectModel;
using PropertyChanged;
using SampleProject.Constants;

namespace SampleProject.ViewModel
{
    
    [AddINotifyPropertyChangedInterface]
    public class PlaylistHandler 
    {
        public PlaylistHandler()
        {
            playlists = new List<Playlist>();
        }

        public List<Playlist> playlists { get; set; }

        public void Add(Playlist playlist)
        {
            playlists.Add(playlist);
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : MainViewModelBase
    {
        public RelayCommand CSVOpenCommand { get; set; }
        public RelayCommand PlaylistOpenCommand { get; set; }
        public RelayCommand MoreCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        public ObservableCollection<Playlist> playlists { get; private set; } = new ObservableCollection<Playlist>();
        public ObservableCollection<Playlist> playlistsRemainder { get; private set; } = new ObservableCollection<Playlist>();
        
        public Visibility VisibilytiCommandButton { get; set; }

        public string PlaylistInfoJson { get; set; }
        public string ImageSourceBackground { get; set; }
        public MainViewModel(NavigationManager navigationManager) : base(navigationManager)
        {
            ImageSourceBackground = Directory.GetCurrentDirectory() + @"\BackgroundImage\BackGroundMain.png";

            CSVOpenCommand = new RelayCommand(obj => OpenCSV());

            PlaylistOpenCommand = new RelayCommand( obj => ParsePlaylistFromJson());

            MoreCommand = new RelayCommand(obj => AddMoreTracksToView());

            LogoutCommand = new RelayCommand(obj => Logout());
        }

        public async Task ParsePlaylistFromJson()
        {
            

            using (StreamReader sr = new StreamReader(@$"{Directory.GetCurrentDirectory()}\user.json"))
            {
                PlaylistInfoJson = await sr.ReadToEndAsync();
            }
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(PlaylistInfoJson)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Deserialize1));
                Deserialize1 dsObj2 = (Deserialize1)deserializer.ReadObject(ms);

                GetPlaylist(dsObj2.username);
            }
        }

        public async Task GetPlaylist(string username)
        {
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync($@"http://api-v2.hearthis.at/{username.ToLower()}/?type=playlists");

            string orderJson = await response.Content.ReadAsStringAsync();

            PlaylistDeserial ObjOrderList = new PlaylistDeserial();
            
            List<PlaylistDeserial> products = JsonConvert.DeserializeObject<List<PlaylistDeserial>>(orderJson);

            if (products.Count == 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("your playlist is empty, no music yet :(");
                return;
            }
            
            for (int i = 0; i < products.Count ; i++)
            {
                GetSongsFromCurentPlaylist(products[i].uri);
            }
        }
        public async Task GetSongsFromCurentPlaylist(string uri)
        {
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(uri);

            string orderJson = await response.Content.ReadAsStringAsync();
           
            List<DeserializeSong> productsOfPlaylist = JsonConvert.DeserializeObject<List<DeserializeSong>>(orderJson);

            int durationInt, second, minute;
            bool isContainsTrack;

            for (int i = 0; i < productsOfPlaylist.Count; i++)
            {
                isContainsTrack = false;

                durationInt = Convert.ToInt32(productsOfPlaylist[i].duration);
                minute = durationInt / 60;
                second = durationInt % 60;

                if (playlists.Count < 3)
                {
                    VisibilytiCommandButton = Visibility.Hidden;
                }
                if (playlists.Count == 3)
                {
                    VisibilytiCommandButton = Visibility.Visible;
                }

                if (playlists.Count >= 3)
                {
                    if (minute >= 60)
                    {
                        int hours = minute / 60;
                        minute = minute % 60;

                        playlistsRemainder.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{hours}:{minute}:{second}", productsOfPlaylist[i].thumb));
                        continue;
                    }

                    playlistsRemainder.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{minute}:{second}", productsOfPlaylist[i].thumb));
                    continue;
                }

                if (playlists.Count == 0)
                {
                    if (minute >= 60)
                    {
                        int hours = minute / 60;
                        minute = minute % 60;

                        playlists.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{hours}:{minute}:{second}", productsOfPlaylist[i].thumb));
                        continue;
                    }

                    playlists.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{minute}:{second}", productsOfPlaylist[i].thumb));
                    continue;
                }

                for(int j = 0; j < playlists.Count; j++)
                {
                    if (playlists[j].SongName == productsOfPlaylist[i].title)
                    {
                        isContainsTrack = true;
                        break;
                    }
                }

                if (!isContainsTrack)
                {
                    if (minute >= 60)
                    {
                        int hours = minute / 60;
                        minute = minute % 60;

                        playlists.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{hours}:{minute}:{second}", productsOfPlaylist[i].thumb));
                        continue;
                    }
                    playlists.Add(new Playlist(productsOfPlaylist[i].title, productsOfPlaylist[i].user.username, $"{minute}:{second}", productsOfPlaylist[i].thumb));
                    continue;
                }
                
            }
        }
        public void AddMoreTracksToView()
        {
            bool isContainsTrack;
            if (playlists.Count < 3)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("nothing to add :(");
                return;
            }
            for(int i = 0; i < playlistsRemainder.Count; i++)
            {
                isContainsTrack = false;
                for (int j = 0; j < playlists.Count; j++)
                {
                    if (playlists[j].SongName == playlistsRemainder[i].SongName)
                    {
                        isContainsTrack = true;
                        break;
                    }
                }

                if (!isContainsTrack)
                {
                    playlists.Add(playlistsRemainder[i]);
                }
                
            }
        }

        public async Task Logout()
        {
            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(@"https://api-v2.hearthis.at/logout/");

            string orderJson = await response.Content.ReadAsStringAsync();

            if (orderJson.Length != 0)
            {
                NavigationManager.Navigate(NavigationKeys.Login);
            }
        }
        public void OpenCSV()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Dialog.Multiselect = true;
            Dialog.Filter = @"(*.csv)|*.csv";
            BeginInvokeOnMainThread(() =>
            {
                try
                {
                    var result = Dialog.ShowDialog();

                    var names = Dialog.FileNames;
                    if (names != null)
                    {
                        foreach (var item in names)
                        {
                            OpenFile(item);
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            });

        }

        private void OpenFile(string path)
        {
            var _name = Path.GetFileName(path).Replace(Path.GetExtension(path), "");

            var dt = new DataTable();

            List<Track> values = new List<Track>();

            var file = File.ReadAllLines(path, Encoding.UTF8);

            var firstrow = file.FirstOrDefault().Contains("Track ID");
            var sep = firstrow ? file.FirstOrDefault()[8] : ',';
            dt.Columns.Add("Track ID", typeof(string));
            dt.Columns.Add("Track Name", typeof(string));
            dt.Columns.Add("Artist Name", typeof(string));
            dt.Columns.Add("Album Name", typeof(string));
            dt.Columns.Add("Duration", typeof(string));

            foreach (var var in file.Skip(firstrow ? 1 : 0)
                .ToList())
            {
                if (string.IsNullOrEmpty(var))
                {
                    continue;
                }

                dt.Rows.Add(var?.Split(sep).Take(5).ToArray());
            }
            if (dt.Rows.Count < 1)
                return;

            values = dt.DefaultView.ToTable().Rows.Cast<DataRow>()
                .Select(t => new Track(t)).ToList();
            BeginInvokeOnMainThread(() =>
            {
                foreach (var item in values)
                {
                    MediaItems.Add(item);
                }
            });
        }
    }
}
