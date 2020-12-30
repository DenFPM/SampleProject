using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using Model.MusicService;
using SampleProject.Backend.Model;
using SampleProject.Constants;
using SampleProject.ViewModel.ViewModelBase;
using SampleProject.Views;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SampleProject.ViewModel
{
    public class LoginViewModel : MainViewModelBase
    {
        
        public string PasswordString { get; set; }
        public string LoginString { get; set; }
        public string ImageSource { get; set; }
        public bool IsConnection { get; set; }

        public LoginViewModel(NavigationManager navigationManager) : base(navigationManager)
        {
            ImageSource = Directory.GetCurrentDirectory() + @"\BackgroundImage\BackGroundLogin.png";

            LoginCommand = new RelayCommand(async obj => await LoginAuthorization());

            LoginString = Login.LoginPropertyProperty.ToString();

            IsConnection = true;
        }

        public RelayCommand LoginCommand { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public async Task LoginAuthorization()
        {
            if (LoginString == null || PasswordString == null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Field must be fulled");
                return;
            }

            Deserialize responseObj = await Auth(Client);

            if (IsConnection)
            {
                if (responseObj.UserName != null)
                {
                    NavigationManager.Navigate(NavigationKeys.Main);
                }
                else
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Wrong password or e-mail");
                    return;
                }
            }
        }
        public Task<Deserialize> Auth(IMusicService musicService)
        {
            return musicService.Authorize(LoginString, PasswordString);
        }
    }
}
