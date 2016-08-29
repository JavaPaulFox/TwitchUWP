using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using TwitchUWP.Core.Models;
using TwitchUWP.Core.Utils;

namespace TwitchUWP.Models.ModelsForView
{
    public class StreamViewModel
    {
        
            public string game { get; set; }
            public int viewers { get; set; }
            public double average_fps { get; set; }
            public int delay { get; set; }
            public int video_height { get; set; }
            public bool is_playlist { get; set; }
            public DateTime created_at { get; set; }
            public ulong _id { get; set; }
            public Channel channel { get; set; }
            public ImageSource preview { get; set; }
            public Dictionary<string, string> _links { get; set; }
            public string title { get; set; }
        
    }

    public class StreamManager
    {
        public static async Task<ObservableCollection<StreamViewModel>> GetPopularStreams()
        {
            StreamViewModel stream;
            LoadingStreams loadingStreams = new LoadingStreams();
            var popularStreams = await loadingStreams.LoadMostPopularStreams();
            ObservableCollection<StreamViewModel> listOfStreams = new ObservableCollection<StreamViewModel>();
            foreach (var item in popularStreams.streams)
            {
                stream = new StreamViewModel();
                stream.game = "Plays "+ item.game;
                stream.viewers = item.viewers;
                stream.average_fps = item.average_fps;
                stream.delay = item.delay;
                stream.video_height = item.video_height;
                stream.is_playlist = item.is_playlist;
                stream.created_at = item.created_at;
                stream.channel = item.channel;
                stream.preview = new BitmapImage(new Uri(item.preview["large"]));
                stream._links = item._links;
                stream.title = item.channel.status;
                listOfStreams.Add(stream);
            }
            return listOfStreams;
        } 
    }
}
