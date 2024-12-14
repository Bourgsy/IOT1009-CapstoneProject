using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NicksApp.Services;
using NicksApp.Models;

namespace NicksApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly DatabaseService _database;
        private readonly WeatherApi _weatherApi;

        [ObservableProperty]
        private string moodText;

        [ObservableProperty]
        private string resultText;

        [ObservableProperty]
        private string weatherCondition;

        [ObservableProperty]
        private string temperature;

        public MainViewModel(DatabaseService database, WeatherApi weatherApi)
        {
            _database = database;
            _weatherApi = weatherApi;
            LoadWeather();
        }

        private async void LoadWeather()
        {
            var weatherItems = await _weatherApi.RefreshDataAsync();
            if (weatherItems?.Any() == true)
            {
                var weather = weatherItems[0];
                WeatherCondition = weather.Condition;
                Temperature = $"{weather.Temperature:F1}°C";
            }
        }

        [RelayCommand]
        private async Task SaveMood(bool isGood)
        {
            if (string.IsNullOrWhiteSpace(MoodText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter how you feel", "OK");
                return;
            }

            var mood = new MoodEntry
            {
                Mood = MoodText,
                IsGood = isGood,
                Timestamp = DateTime.Now
            };

            await _database.SaveMoodAsync(mood);

            var percentage = await _database.GetGoodMoodPercentageAsync();
            ResultText = isGood
                ? $"{percentage:F0}% of users felt good today"
                : $"{percentage:F0}% of users felt down today";

            MoodText = string.Empty;
        }
    }
}
