using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NicksApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly INavigation _navigation;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private async Task Login()
        {
            if (Username == "admin" && Password == "admin")
            {
                await _navigation.PushAsync(new Views.MainPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
            }
        }
    }
}