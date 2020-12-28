using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using SampleProject.Constants;
using SampleProject.ViewModel.ViewModelBase;
using SampleProject.Views;
using System.Collections.Generic;
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

            Deserialize1 responseObj = await Authorization(LoginString, PasswordString);

            if (IsConnection)
            {
                if (responseObj.username != null)
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
        
        public async Task<Deserialize1> Authorization(string login, string password)
        {
            var values = new Dictionary<string, string>
            {
                  { "action", "login" },
                  { "email", login },
                  {"password", password }
            };
            try
            {
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api-v2.hearthis.at/login/", content);

                var responseString = response.Content.ReadAsStringAsync();

                using (FileStream fstream = new FileStream(@$"{Directory.GetCurrentDirectory()}\user.json", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(responseString.Result);
                    fstream.Write(array, 0, array.Length);
                }

                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(responseString.Result)))
                {
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Deserialize1));
                    Deserialize1 bsObj2 = (Deserialize1)deserializer.ReadObject(ms);

                    return bsObj2;
                }
            }
            catch(HttpRequestException ex)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Connection to enthernet fallen");
                IsConnection = false;

                return new Deserialize1();
            }
            
            
        }
        
    }
}
