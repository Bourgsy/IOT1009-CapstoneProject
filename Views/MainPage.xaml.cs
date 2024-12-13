using NicksApp.Services;

namespace NicksApp.Views
{
    public partial class MainPage : ContentPage
    {
        private WeatherApi _weatherApi;

        public MainPage()
        {
            InitializeComponent();
            _weatherApi = new WeatherApi();
            LoadWeather();
        }

        private async void LoadWeather()
        {
            var weatherItems = await _weatherApi.RefreshDataAsync();
            if (weatherItems?.Any() == true)
            {
                var weather = weatherItems[0];
                WeatherConditionLabel.Text = weather.Condition;
                TemperatureLabel.Text = $"{weather.Temperature:F1}°C";
                DescriptionLabel.Text = weather.Description;
            }
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            LoadWeather();
        }
    }
}