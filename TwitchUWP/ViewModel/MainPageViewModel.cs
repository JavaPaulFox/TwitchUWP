using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using TwitchUWP.Core.VideoStream;
using TwitchUWP.View;

namespace TwitchUWP.ViewModel
{
    public class MainPageViewModel
    {
        public async void MainContentGrid_Loaded(object sender, object args)
        {
            Streams streams = new Streams();
            Grid mainContentGrid = sender as Grid;
            var streamsList = await streams.GetStreams();
            int counterColumn = 0;
            int counterRow = 1;
            for (int i = 0; i < streamsList.streams.Count; i++)
            {
                if (i%5 == 0)
                {
                    counterColumn = 0;
                    counterRow++;
                    mainContentGrid?.RowDefinitions.Add(new RowDefinition() {Height = GridLength.Auto});
                }
                Image image = new Image();
                BitmapImage bmi = new BitmapImage();
                bmi.UriSource = new Uri(streamsList.streams[i].preview["medium"]);
                image.Source = bmi;
                Grid.SetColumn(image, counterColumn);
                Grid.SetRow(image, counterRow);
                counterColumn++;
                mainContentGrid?.Children.Add(image);
            }
            
        }

    }
}
