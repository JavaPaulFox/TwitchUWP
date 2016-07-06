using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Models;
using TwitchUWP.ViewModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HamburgerMenuViewModel HamburgerMenuViewModel;
        private MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            mainPageViewModel = new MainPageViewModel();
            HamburgerMenuViewModel = new HamburgerMenuViewModel();
            if (!TabletPCSupport.IsTabletMode())
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }

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
