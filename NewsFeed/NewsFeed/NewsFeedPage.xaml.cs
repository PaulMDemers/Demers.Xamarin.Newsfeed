using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsFeed
{
    public partial class NewsFeedPage : ContentPage
    {
        public ObservableRangeCollection<Post> Posts { get; set; } = new ObservableRangeCollection<Post>();

        public NewsFeedPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            NewsFeedClient nfc = new NewsFeedClient("http://localhost:3000");

            PostList posts = await nfc.GetPosts();

            Posts.ReplaceRange(posts.Posts);
        }

        async void scllView_Refreshing(System.Object sender, System.EventArgs e)
        {
            NewsFeedClient nfc = new NewsFeedClient("http://localhost:3000");

            PostList posts = await nfc.GetPosts();

            Posts.ReplaceRange(posts.Posts);

            scllView.IsRefreshing = false;
        }
    }
}

