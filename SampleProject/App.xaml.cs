using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using SampleProject.Constants;
using SampleProject.ViewModel;
using SampleProject.ViewModel.ViewModelBase;
using SampleProject.Views;
using System.Windows;

namespace SampleProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            var mainWindow = new MainWindow();
            var navigationManager = new NavigationManager(mainWindow);
            navigationManager.Register<Login>(NavigationKeys.Login, () => new LoginViewModel(navigationManager));
            navigationManager.Register<Main>(NavigationKeys.Main, () => new MainViewModel(navigationManager));
            mainWindow.Show();
            navigationManager.Navigate(NavigationKeys.Login);
        }
    }
}
