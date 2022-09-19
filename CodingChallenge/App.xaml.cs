using CodingChallenge.ConcreteServices;
using CodingChallenge.Services;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingChallenge
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<IPackageService>();
            DependencyService.Register<IUniversityService, UniversityService>();
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
