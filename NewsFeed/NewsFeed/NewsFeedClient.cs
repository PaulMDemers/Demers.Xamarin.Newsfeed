using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using NewsFeed.Exceptions;
using Newtonsoft.Json;

namespace NewsFeed
{
    public class NewsFeedClient
    {
        string _serverAddress;
        HttpClient httpClient = new HttpClient();

        public NewsFeedClient(string serverAddress)
        {
            _serverAddress = serverAddress;
        }

        public string GenURL(string path)
        {
            bool needsSlash = !_serverAddress.EndsWith("/") && !path.StartsWith("/");

            return _serverAddress + (needsSlash ? "/" : "") + path;
        }

        public async Task<T> SendAsync<T>(HttpMethod method, string url, object body = null)
        {
            HttpRequestMessage req = new HttpRequestMessage(method, url);

            if (body != null)
            {
                req.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage res = await httpClient.SendAsync(req);
            string content = await res.Content.ReadAsStringAsync();

            if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new NoTokenException();
            }

            if (res.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new ServerSideException(content);
            }

            if (res.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new RestException()
                {
                    Code = (int)res.StatusCode
                };
            }

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<PostList> GetPosts(int page = 0)
        {
            return await SendAsync<PostList>(HttpMethod.Get, GenURL("/posts" + (page > 0 ? "?Page=" + page.ToString() : "")));
        }

        public async Task<Post> GetPost(int postId)
        {
            return await SendAsync<Post>(HttpMethod.Get, GenURL("/posts/" + postId));
        }
    }
}

