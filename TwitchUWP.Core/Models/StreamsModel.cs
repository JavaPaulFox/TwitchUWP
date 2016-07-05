using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchUWP.Core.Models
{
    public class StreamsModel
    {
        public int _total { get; set; }
        public List<Streams> streams { get; set; }
        public Dictionary<string, string> _links { get; set; }

    }

    public class Streams
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
        public Dictionary<string,string> preview { get; set; }
        public Dictionary<string, string> _links { get; set; }



    }

    public class Channel
    {
        public string mature { get; set; }
        public string status { get; set; }
        public string broadcaster_language { get; set; }
        public string display_name { get; set; }
        public string game { get; set; }
        public string delay { get; set; }
        public string language { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string logo { get; set; }
        public string banner { get; set; }
        public string video_banner { get; set; }
        public string background { get; set; }
        public string profile_banner { get; set; }
        public string profile_banner_background_color { get; set; }
        public string partner { get; set; }
        public string url { get; set; }
        public string views { get; set; }
        public string followers { get; set; }
        public Dictionary<string, string> _linkst { get; set; }

    }



}
