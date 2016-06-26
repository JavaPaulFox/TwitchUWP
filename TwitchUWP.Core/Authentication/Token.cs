using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchUWP.Core.Authentication
{
    public class Token
    {
        [JsonProperty]
        public static string access_token { get; set; }
        [JsonProperty]
        public static string refresh_token { get; set; }
        [JsonProperty]
        public static string[] scope { get; set; }
    }
}
