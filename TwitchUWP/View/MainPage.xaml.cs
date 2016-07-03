using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Core.VideoStream;
using TwitchUWP.View;
using TwitchUWP.ViewModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HamburgerMenuViewModel HamburgerMenuViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            HamburgerMenuViewModel = new HamburgerMenuViewModel();
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GetVideoInfo getVideoInfo = new GetVideoInfo();
            getVideoInfo.GetStream();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogInPage));
        }

        
    }
}
