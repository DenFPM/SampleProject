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
using System.Windows;
using System.Collections.ObjectModel;
using PropertyChanged;
using SampleProject.Constants;
using Model.MusicService;

namespace SampleProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : MainViewModelBase
    {
        private RelayCommand getPlaylistName;
        public RelayCommand CSVOpenCommand { get; set; }
        public RelayCommand PlaylistOpenCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand GetPlaylistName { get { return getPlaylistName ?? (getPlaylistName = new RelayCommand(x => DoStuff(x as Playlist))); } set { getPlaylistName = value; } }
        
        public ObservableCollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();
        public ObservableCollection<Playlist> Playlists { get; private set; } = new ObservableCollection<Playlist>();
        public ObservableCollection<Playlist> PlaylistsTemp { get; private set; } = new ObservableCollection<Playlist>();

        public Visibility VisibilytiCommandButton { get; set; }

        public string PlaylistInfoJson { get; set; }
        public string ImageSourceBackground { get; set; }

        public MainViewModel(NavigationManager navigationManager) : base(navigationManager)
        {
            ImageSourceBackground = Directory.GetCurrentDirectory() + @"\BackgroundImage\BackGroundMain.png";

            CSVOpenCommand = new RelayCommand(obj => OpenCSV());

            PlaylistOpenCommand = new RelayCommand( obj => StartConveirToGetPlaylist(Client));

            LogoutCommand = new RelayCommand(obj => Logout());
        }

        public async Task StartConveirToGetPlaylist(IMusicService musicService)
        {
            try
            {
                PlaylistsTemp = await musicService.ParsePlaylistFromJson();
                for (int i = 0; i < PlaylistsTemp.Count; i++)
                {
                    Playlists.Add(PlaylistsTemp[i]);
                }
            }
            catch(ArgumentNullException eNullExc)
            {
                MessageBox.Show(eNullExc.Message);
            }
        }
        private void DoStuff(Playlist item)
        {
            if (Tracks.Count != 0)
            {
                Tracks.Clear();
            }

            for (int i = 0; i < Playlists.Count; i++)
            {
                if (Playlists[i].PlaylistName == item.PlaylistName)
                {
                    for (int j = 0; j < Playlists[i].AllTracks.Count; j++)
                    {
                        Tracks.Add(Playlists[i].AllTracks[j]);
                    }
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

            
        }
    }
}
