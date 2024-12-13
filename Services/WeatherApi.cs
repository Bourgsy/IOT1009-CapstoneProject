using NicksApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace NicksApp.Services
{ 
    public class WeatherApi
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<WeatherItem>? Items { get; private set; }

        public WeatherApi()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            Items = new List<WeatherItem>();
        }

        public async Task<List<WeatherItem>> RefreshDataAsync()
        {
            Items = new List<WeatherItem>();
            Uri uri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q=Sudbury&appid=b2de745f1814473af9ed2c6ac0c854ad&units=metric");

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                Debug.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    var weatherData = JsonSerializer.Deserialize<WeatherData>(content, _serializerOptions);

                    if (weatherData != null && weatherData.Weather != null && weatherData.Weather.Any())
                    {
                        Items.Add(new WeatherItem
                        {
                            ID = Guid.NewGuid().ToString(),
                            Condition = weatherData.Weather[0].Main,         
                            Description = weatherData.Weather[0].Description,
                            Temperature = weatherData.Main.Temp              
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}