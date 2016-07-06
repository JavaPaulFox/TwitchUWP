using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using TwitchUWP.Core.Utils;
using TwitchUWP.Core.VideoStream;
using TwitchUWP.View;

namespace TwitchUWP.ViewModel
{
    public class MainPageViewModel
    {
        public async void Panel_Loaded(object sender, object args)
        {
            int columnSpan = 25;
            Streams streams = new Streams();
            VariableSizedWrapGrid variableGrid = sender as VariableSizedWrapGrid;

            if (DeviceTypeHelper.GetDeviceFormFactorType() == DeviceFormFactorType.Phone)
                variableGrid.MaximumRowsOrColumns = 25;

            var streamsList = await streams.GetStreams();
            foreach (Core.Models.Streams t in streamsList.streams)
            {
                Image image = new Image();
                //image.SetValue(VariableSizedWrapGrid.ColumnSpanProperty,columnSpan);
                BitmapImage bmi = new BitmapImage();
                bmi.UriSource = new Uri(t.preview["large"]);
                image.Source = bmi;
                variableGrid.Children.Add(image);
            }
            
        }

    }
}
