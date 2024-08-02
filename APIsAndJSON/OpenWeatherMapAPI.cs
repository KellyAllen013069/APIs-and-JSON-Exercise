using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        private readonly HttpClient _client;

        public OpenWeatherMapAPI(HttpClient client)
        {
            _client = client;
        }
        
        public JObject GetWeather()
        {
            var geoURL =
                $"http://api.openweathermap.org/geo/1.0/direct?q=birmingham,AL,USA&limit=1&appid=683f50b48f5d7dc54f9b0b80e70e7fb8";
            
            var result = _client.GetStringAsync(geoURL).Result;

            var parsedJson = JArray.Parse(result);
            var firstResult = parsedJson[0];

            double lat = firstResult["lat"].ToObject<double>();
            double lon = firstResult["lon"].ToObject<double>();

            var weatherURL =
                $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=imperial&appid=683f50b48f5d7dc54f9b0b80e70e7fb8";

            var weatherResult = _client.GetStringAsync(weatherURL).Result;

            return JObject.Parse(weatherResult);


        }
        
    }
}
