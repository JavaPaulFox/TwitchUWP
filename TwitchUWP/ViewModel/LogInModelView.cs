using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TwitchUWP.Annotations;
using TwitchUWP.Core.Authentication;
using TwitchUWP.View;

namespace TwitchUWP.ViewModel
{
    public class LogInModelView : INotifyPropertyChanged
    {
        private Oauth2Authentication _oauth2;
        
        private bool _isActiveRing = false;
        public bool IsActiveRing
        {
            get { return _isActiveRing; }
            set
            {
                _isActiveRing = value;
                OnPropertyChanged("IsActiveRing");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void LogInWebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            
            _oauth2 = new Oauth2Authentication();
            if (!sender.Source.AbsoluteUri.Contains("code=") || sender.Source.Host != "localhost") return;
            sender.Visibility = Visibility.Collapsed;
            var postitionCode = sender.Source.AbsoluteUri.IndexOf("code=", StringComparison.Ordinal);
            var code = sender.Source.AbsoluteUri.Remove(0, postitionCode + 5);
            var postitionScope = code.IndexOf("&scope=", StringComparison.Ordinal);
            code = code.Remove(postitionScope);
            await _oauth2.GetToken(code);
            var rootFrame = Window.Current.Content as Frame;
            rootFrame?.Navigate(typeof(MasterPage));
        }

        public void LogInWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            IsActiveRing = !IsActiveRing;
        }

        public void LogInWebView_NavigationStart(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            IsActiveRing = true;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
