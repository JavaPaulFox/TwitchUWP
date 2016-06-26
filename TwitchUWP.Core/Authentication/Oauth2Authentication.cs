using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Windows.Media.Capture.Core;
using Newtonsoft.Json;

namespace TwitchUWP.Core.Authentication
{
    public class Oauth2Authentication
    {
        public async Task<WebResponse> Authentication()
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(@"https://api.twitch.tv/kraken/oauth2/authorize?response_type=code"+
            "&client_id=1e14a4aow4glqc05s80kdf15r94g0x" +
            "&redirect_uri=http://localhost" +
            "&scope=user_follows_edit" +
            "&state=CheckThisOut");
            webRequest.Method = "GET";

            WebResponse webResponse = await webRequest.GetResponseAsync();
           
            return webResponse;
        }

        public async Task<WebResponse> GetToken(string code)
        {
            WebRequest webRequest = WebRequest.Create(@"https://api.twitch.tv/kraken/oauth2/token");
            string data = "client_id=1e14a4aow4glqc05s80kdf15r94g0x" +
            "&grant_type=authorization_code" +
            "&code=" +code+
            "&redirect_uri=http://localhost" +
            "&client_secret=ojvptfl1it0r6gyghmml13377bpei1j" +
            "&state=CheckThisOut";
            byte[] dataArray = Encoding.UTF8.GetBytes(data);
            webRequest.Method = "POST";
            Stream dataStream = await webRequest.GetRequestStreamAsync();
            dataStream.Write(dataArray,0,dataArray.Length);
            WebResponse webResponse = await webRequest.GetResponseAsync();
            var responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string response= "";
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                response += line;
            }

            JsonConvert.DeserializeObject<Token>(response);
            var i  = Token.access_token;
            return webResponse;
        }

    }
}
