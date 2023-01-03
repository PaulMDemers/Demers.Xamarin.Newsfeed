using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NewsFeed
{
    public partial class NewsEntryControl : ContentView
    {
        public NewsEntryControl()
        {
            InitializeComponent();
        }

        async void tgr_Tapped(System.Object sender, System.EventArgs e)
        {
            Post post = (sender as BindableObject).BindingContext as Post;
            await Navigation.PushAsync(new PostPage(post.ID));
        }
    }
}

