using System;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Core.Authentication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : Page
    {

        private Oauth2Authentication oauth2;
        public LogInPage()
        {
            this.InitializeComponent();
            oauth2 = new Oauth2Authentication();
            LogInWebView.Navigate(new Uri(@"https://api.twitch.tv/kraken/oauth2/authorize?response_type=code&client_id=1e14a4aow4glqc05s80kdf15r94g0x&redirect_uri=http://localhost&scope=user_follows_edit&state=CheckThisOut"));
        }

        private async void LogInWebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {

            if (LogInWebView.Source.AbsoluteUri.Contains("code=") && LogInWebView.Source.Host == "localhost")
            {
                var postitionCode = LogInWebView.Source.AbsoluteUri.IndexOf("code=");
                var code = LogInWebView.Source.AbsoluteUri.Remove(0, postitionCode + 5);
                var postitionScope = code.IndexOf("&scope=");
                code = code.Remove(postitionScope);
                oauth2.GetToken(code);
                this.Frame.Navigate(typeof (MainPage));
                
            }
        }

        
    }
}
