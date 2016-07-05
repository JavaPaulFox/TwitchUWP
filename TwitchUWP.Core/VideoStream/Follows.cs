using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitchUWP.Core.Authentication;

namespace TwitchUWP.Core.VideoStream
{
    public class Follows
    {
        public async Task<List<string>> GetFollowsByUser(string user)
        {
            WebRequest webRequest = WebRequest.Create(@"https://api.twitch.tv/kraken/users/"+user+"/follows/channels?limit=100&offset=0");
            webRequest.Headers["Authorization"] = "OAuth " + Token.access_token;
            webRequest.Headers["Accept"] = "application/vnd.twitchtv.v3+json";

            WebResponse webResponse = await webRequest.GetResponseAsync();

            var responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            List<string> result = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                result.Add(line);
            }
            return result;
        }
    }
}
