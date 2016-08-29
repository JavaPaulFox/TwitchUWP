using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using TwitchUWP.Core.Authentication;
using TwitchUWP.Models.ModelsForView;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TwitchUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StreamPage : Page
    {
        private StreamViewModel parameters;
        private static string qualities = "";
        public StreamPage()
        {
            this.InitializeComponent();
            var rm = new Windows.Web.Http.HttpRequestMessage(HttpMethod.Get, new Uri("ms-appx-web:///HTML/stream.html"));
            rm.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
            
            WebViewPlayer.NavigateWithHttpRequestMessage(rm);

            //WebViewPlayer.Source = new Uri("ms-appx-web:///HTML/stream.html");
           
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            parameters = (StreamViewModel)e.Parameter;

            
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //await WebViewPlayer.InvokeScriptAsync("setChanneltoPlayer", new string[] { parameters.channel.display_name });
             await WebViewPlayer.InvokeScriptAsync("setQualityToPlayer", new string[] { });
        }

        private async void WebViewPlayer_LoadCompleted(object sender, NavigationEventArgs e)
        {
            
             //Items = await WebViewPlayer.InvokeScriptAsync("getQualitiesFromPlayer", new string[] { });
            //ComboBoxQuality.Items.Add(qualities);
        }
    }
}
