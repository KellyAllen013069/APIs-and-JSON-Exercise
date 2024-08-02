using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quote = new RonVSKanyeAPI(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye: {quote.Kanye()}");
                Console.WriteLine($"Ron Swanson: {quote.Ron()}");
            }
            
            Console.WriteLine("====================================");

            var weather = new OpenWeatherMapAPI(client);
            var weatherJson = weather.GetWeather();
            
            string formattedWeatherJson = weatherJson.ToString(Newtonsoft.Json.Formatting.Indented);

            var weatherData = JObject.Parse(formattedWeatherJson);
            string description = weatherData["weather"][0]["description"].ToString();
            double temperature = weatherData["main"]["temp"].ToObject<double>();
            double feelsLike = weatherData["main"]["feels_like"].ToObject<double>();
            double tempMin = weatherData["main"]["temp_min"].ToObject<double>();
            double tempMax = weatherData["main"]["temp_max"].ToObject<double>();
            int humidity = weatherData["main"]["humidity"].ToObject<int>();
            double windSpeed = weatherData["wind"]["speed"].ToObject<double>();
            string cityName = weatherData["name"].ToString();

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine($"*     Weather in {cityName}     *");
            Console.WriteLine("**********************************");
            Console.WriteLine($"Description : {description}");
            Console.WriteLine($"Temperature : {temperature} °F");
            Console.WriteLine($"Feels Like  : {feelsLike} °F");
            Console.WriteLine($"Min Temp    : {tempMin} °F");
            Console.WriteLine($"Max Temp    : {tempMax} °F");
            Console.WriteLine($"Humidity    : {humidity}%");
            Console.WriteLine($"Wind Speed  : {windSpeed} mph");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            
        }
    }
}
