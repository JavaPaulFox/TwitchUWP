using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Core.Authentication;
using TwitchUWP.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : Page
    {
        
        private HamburgerMenuViewModel _hamburgerMenuViewModel;
        private LogInModelView _logInModelView;
        public LogInPage()
        {
            
            this.InitializeComponent();
            
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            _logInModelView = new LogInModelView();
            
            _hamburgerMenuViewModel = new HamburgerMenuViewModel();
            //LogInWebView.Source = new Uri(@"https://api.twitch.tv/kraken/oauth2/authorize?response_type=code&client_id=1e14a4aow4glqc05s80kdf15r94g0x&redirect_uri=http://localhost&scope=user_follows_edit&state=CheckThisOut");
            LogInWebView.Source = new Uri(@"https://www.onliner.by/");

        }

        
    }
}
