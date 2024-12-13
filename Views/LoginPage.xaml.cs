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
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (UsernameEntry.string == "admin"  && PasswordEntry.string == "admin")
            {
                await Naviation.PushAsync(new MainPage());
            }
            else 
            {
                await DisplayAlert("Error", "Invalid", "ok");
            }
     
        }
    }
}
