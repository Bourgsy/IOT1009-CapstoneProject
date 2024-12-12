using System.Diagnostics;

namespace NicksApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void LoginButton_Clicked(object sender, EventArgs e)
	{
		Debug.WriteLine("Clicked");
		// Logic placeholder
	}
}