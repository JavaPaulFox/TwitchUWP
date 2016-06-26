using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Core.Authentication;
using TwitchUWP.Core.VideoStream;
using TwitchUWP.View;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwitchUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Oauth2Authentication oauth2;
        public MainPage()
        {
            this.InitializeComponent();
            oauth2 = new Oauth2Authentication();
        }

        private async void LogInWebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            
            //if (LogInWebView.Source.AbsoluteUri.Contains("code=") && LogInWebView.Source.Host == "localhost")
            //{
            //    var postitionCode = LogInWebView.Source.AbsoluteUri.IndexOf("code=");
            //    var code = LogInWebView.Source.AbsoluteUri.Remove(0, postitionCode + 5);
            //    var postitionScope = code.IndexOf("&scope=");
            //    code = code.Remove(postitionScope);
            //    var token = await oauth2.GetToken(code);

            //}
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

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogInPage));
        }
    }
}
