using System;
namespace NewsFeed.Exceptions
{
    public class ServerSideException : Exception
    {
        public String Content { get; set; }
        public ServerSideException(string content)
        {
            this.Content = content;
        }
    }
}

