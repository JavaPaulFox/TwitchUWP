using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using TwitchUWP.Core.Utils;
using TwitchUWP.Core.VideoStream;
using TwitchUWP.Models;
using TwitchUWP.Models.ModelsForView;
using TwitchUWP.View;

namespace TwitchUWP.ViewModel
{
    public sealed class MainPageViewModel 
    {

        public void StreamSource_Clicked(object sender, ItemClickEventArgs eventArgs)
        {
            var stream = (StreamViewModel) eventArgs.ClickedItem;
            Frame rootFrame = (Frame)Window.Current.Content;
            rootFrame.Navigate(typeof(MasterPage),stream);
        }
       

    }
}
