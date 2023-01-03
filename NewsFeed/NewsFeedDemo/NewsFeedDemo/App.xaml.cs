using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeedDemo
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NewsFeed.NewsFeedPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

