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
        private void LoginButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
