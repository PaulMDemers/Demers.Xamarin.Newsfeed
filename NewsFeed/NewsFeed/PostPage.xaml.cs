using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsFeed
{
    public partial class PostPage : ContentPage
    {
        public int PostId { get; set; } = -1;

        public PostPage(int postId)
        {
            InitializeComponent();
            PostId = postId;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            NewsFeedClient nfc = new NewsFeedClient("http://localhost:3000");
            Post post = await nfc.GetPost(PostId);
            BindingContext = post;
        }
    }
}

