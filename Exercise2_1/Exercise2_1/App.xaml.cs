using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise2_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Principal p = new Principal();
            p.Title = "EJERCICIO 2.1";
            MainPage = new NavigationPage(p);
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
