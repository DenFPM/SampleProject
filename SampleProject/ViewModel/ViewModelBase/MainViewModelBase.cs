using System;
using System.Collections.ObjectModel;
using System.Windows;
using Egor92.MvvmNavigation;
using SampleProject.Backend;
using SampleProject.Backend.Model;

namespace SampleProject.ViewModel.ViewModelBase
{
    public class MainViewModelBase
    {
        public Client Client { get; set; } = new Client();
        public NavigationManager NavigationManager { get; set; }
        public MainViewModelBase(NavigationManager navigation)
        {
            NavigationManager = navigation;
        }
        public ObservableCollection<ModelBase> MediaItems { get; set; } = new ObservableCollection<ModelBase>();
        public static void BeginInvokeOnMainThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
        
    }
}
