using System.IO;
using System.Net;
using Newtonsoft.Json;
using TwitchUWP.Core.Authentication;

namespace TwitchUWP.Core.VideoStream
{
    public class GetVideoInfo
    {
        public async void GetFollowedChannels()
        {
            WebRequest webRequest = WebRequest.Create(@"https://api.twitch.tv/kraken/users/javapaul/follows/channels?limit=10&offset=15");
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
            VideoInfo video = JsonConvert.DeserializeObject<VideoInfo>(response);

        }


        public async void GetStream()
        {
            WebRequest webRequest = WebRequest.Create(@"http://api.twitch.tv/api/channels/Dota2ruhub/access_token");
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
        }
    }
}
