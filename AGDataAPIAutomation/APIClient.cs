using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApiTestingSuite.Models;
using System.Xml.Linq;

namespace ApiTestingSuite
{
    public class APIClient
    {
        private readonly RestClient client;

        public APIClient()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");
        }

        public List<Post> GetPosts()
        {
            var request = new RestRequest("posts", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Post>>(response.Content);
        }

        public Post CreatePost(Post newPost)
        {
            var request = new RestRequest("posts", Method.Post);
            request.AddJsonBody(newPost);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Post>(response.Content);
        }

        public Post UpdatePost(int postId, Post updatedPost)
        {
            var request = new RestRequest($"posts/{postId}", Method.Put);
            request.AddJsonBody(updatedPost);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Post>(response.Content);
        }

        public bool DeletePost(int postId)
        {
            var request = new RestRequest($"posts/{postId}", Method.Delete);
            var response = client.Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public Comment CreateComment(int postId, Comment newComment)
        {
            var request = new RestRequest($"posts/{postId}/comments", Method.Post);
            request.AddJsonBody(newComment);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Comment>(response.Content);
        }

        public List<Comment> GetCommentsForPost(int postId)
        {
            var request = new RestRequest("comments", Method.Get);
            request.AddParameter("postId", postId);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Comment>>(response.Content);
        }
    }
}
