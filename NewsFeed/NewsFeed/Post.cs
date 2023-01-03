using System;
using System.Collections.Generic;

namespace NewsFeed
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FeaturedImg { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime? PostDate { get; set; }
    }

    public class PostList
    {
        public List<Post> Posts { get; set; }
        public int NumPosts { get; set; }
    }
}

