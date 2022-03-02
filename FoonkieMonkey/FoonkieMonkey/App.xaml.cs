using FoonkieMonkey.Helpers.LocalStorange;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("DMSerifDisplay-Regular.ttf", Alias = "DMSerifDisplay")]
[assembly: ExportFont("Rubik-VariableFont.ttf", Alias = "Rubik")]

namespace FoonkieMonkey
{

    public partial class App : Application
    {
        public static int TotalUsers { get; set; }
        private static Foonkie _localStorange { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
