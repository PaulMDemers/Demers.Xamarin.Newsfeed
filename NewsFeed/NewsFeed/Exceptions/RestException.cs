using System;
namespace NewsFeed.Exceptions
{
    public class RestException : Exception
    {
        public int Code { get; set; }
    }
}

