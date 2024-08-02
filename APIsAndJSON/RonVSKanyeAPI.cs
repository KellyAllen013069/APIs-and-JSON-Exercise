using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        private readonly HttpClient _client;

        public RonVSKanyeAPI(HttpClient client)
        {
            _client = client;
        }

        public string Kanye()
        {
            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

            return JObject.Parse(kanyeResponse).GetValue("quote").ToString();
        }
        
        public string Ron()
        {
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = _client.GetStringAsync(ronURL).Result;

            return JArray.Parse(ronResponse)[0].ToString();
            // .Replace('[', ' ').Replace(']', ' ').Trim();
        }
        
    }
}
