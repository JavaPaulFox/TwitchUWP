using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitchUWP.Core.Authentication;
using TwitchUWP.Core.Models;

namespace TwitchUWP.Core.Utils
{
    public class LoadingStreams
    {
        public async Task<StreamsModel> LoadMostPopularStreams()
        {
            
            WebRequest webRequest = WebRequest.Create(@"https://api.twitch.tv/kraken/streams?game=Evolve");
            webRequest.Headers["Authorization"] = "OAuth " + Token.access_token;
            webRequest.Headers["Accept"] = "application/vnd.twitchtv.v3+json";
            

            WebResponse webResponse = await webRequest.GetResponseAsync();

            var responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string response = "";
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                response += line;
            }
            var streams = JsonConvert.DeserializeObject<StreamsModel>(response);
            return streams;
        }
    }
}
