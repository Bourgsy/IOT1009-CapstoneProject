using NicksApp.Services;

namespace NicksApp.Views
{   
    public partial class MainPage : ContentPage
    {
        private WeatherApi _weatherApi;
        private Random _random = new Random();

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
            }
        }

        private async void OnThumbsUpClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MoodEntry.Text))
            {
                await DisplayAlert("Error", "Please enter how you feel", "OK");
                return;
            }

            int percentage = _random.Next(50, 100);
            ResultLabel.Text = $"{percentage}% of users felt good today";
            MoodEntry.Text = string.Empty;
        }

        private async void OnThumbsDownClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MoodEntry.Text))
            {
                await DisplayAlert("Error", "Please enter how you feel", "OK");
                return;
            }

            int percentage = _random.Next(10, 50);
            ResultLabel.Text = $"{percentage}% of users felt down today";
            MoodEntry.Text = string.Empty;
        }
    }
}