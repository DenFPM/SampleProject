using SampleProject.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SampleProject
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void TabItem_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((DataContext as MainViewModel).playlists.Count == 0)
            {
                (DataContext as MainViewModel).PlaylistOpenCommand.Execute(sender);
            }
        }
    }
}
