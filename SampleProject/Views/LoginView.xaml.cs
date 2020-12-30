using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SampleProject.Views
{ 
    public partial class Login : UserControl
    {
        public Login()
        {
            File.WriteAllText(@$"{Directory.GetCurrentDirectory()}\user.json", string.Empty);
            InitializeComponent(); 
        }
        
        public static readonly DependencyProperty LoginPropertyProperty =
        DependencyProperty.Register("Brivka2017@gmail.com", typeof(string), typeof(Login), new UIPropertyMetadata(String.Empty));
        
        public string LoginProperty
        {
            get { return (string)GetValue(LoginPropertyProperty); }
            set { SetValue(LoginPropertyProperty, value); }
        }
    }
}
