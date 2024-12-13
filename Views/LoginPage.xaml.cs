using System.Diagnostics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace NicksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
	{

		public LoginPage()
		{
			InitializeComponent();
		}
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text == "admin"  && PasswordEntry.Text == "admin")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else 
            {
                await DisplayAlert("Error", "Invalid", "ok");
            }
     
        }
    }
}
