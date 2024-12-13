using Microsoft.Maui.Controls.Xaml;


namespace NicksApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Views.MainPage();
        }
    }
}