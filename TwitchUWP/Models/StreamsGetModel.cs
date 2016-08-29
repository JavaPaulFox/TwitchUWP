using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TwitchUWP.Models.ModelsForView;

namespace TwitchUWP.Models
{
    public class StreamsGetModel
    {
        public string Category { get; set; }

        public ObservableCollection<StreamViewModel> Streams { get; set; }

    }

    public class StreamsGetManager
    {
        public static async Task<ObservableCollection<StreamViewModel>> GetStreams()
        {
            ObservableCollection<StreamViewModel> observableCollection = new ObservableCollection<StreamViewModel>();
            
            observableCollection = await StreamManager.GetPopularStreams();
            return observableCollection;
        }
    }

}
