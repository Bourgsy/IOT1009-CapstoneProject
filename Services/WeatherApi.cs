using System.Diagnostics;
using System.Text.Json;

namespace NicksApp.Services
{ 
    public class WeatherApi
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<WeatherItem> Items { get; private set; }  // Following their pattern

        public WeatherApi()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<WeatherItem>> RefreshDataAsync()
        {
            Items = new List<WeatherItem>();
            Uri uri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q=Sudbury&appid=removed&units=metric");

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                
                    var weatherData = JsonSerializer.Deserialize<WeatherItem>(content, _serializerOptions);


                    Items.Add(new WeatherItem
                    {
                        ID = Guid.NewGuid().ToString(),
                        Main = weatherData.Weather[0].Main,
                        Description = weatherData.Weather[0].Description,
                        Temperature = weatherData.Main.Temp
                    });
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