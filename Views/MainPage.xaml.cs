using Microsoft.Maui.Controls.Xaml;

namespace NicksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MainViewModel(
                new Services.DatabaseService(),
                new Services.WeatherApi()
            );
        }
    }
}