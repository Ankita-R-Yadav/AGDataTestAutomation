using ApiTestingSuite.Models;
using System.Xml.Linq;

namespace ApiTestingSuite.APITests
{
    [TestClass]
    public class PostsTests
    {
        private APIClient apiClient;

        [TestInitialize]
        public void SetUp()
        {
            apiClient = new APIClient();
        }

        [TestMethod]
        public void TestGetPosts()
        {
            List<Post> posts = apiClient.GetPosts();
            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Count > 0, "Posts list should not be empty.");
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var newPost = new Post
            {
                UserId = 1,
                Title = "New Post Title",
                Body = "This is a new post body."
            };

            var createdPost = apiClient.CreatePost(newPost);
            Assert.IsNotNull(createdPost);
            Assert.AreEqual(newPost.Title, createdPost.Title);
            Assert.AreEqual(newPost.Body, createdPost.Body);
        }

        [TestMethod]
        public void TestUpdatePost()
        {
            var updatedPost = new Post
            {
                Title = "Updated Post Title",
                Body = "This is the updated post body."
            };

            var postId = 1; // Assume we're updating post with ID 1
            var result = apiClient.UpdatePost(postId, updatedPost);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedPost.Title, result.Title);
            Assert.AreEqual(updatedPost.Body, result.Body);
        }

        [TestMethod]
        public void TestDeletePost()
        {
            var postId = 1; // Assume we're deleting post with ID 1
            bool isDeleted = apiClient.DeletePost(postId);
            Assert.IsTrue(isDeleted, "Post should be deleted successfully.");
        }

        [TestMethod]
        public void TestCreateComment()
        {
            var newComment = new Comment
            {
                PostId = 1,
                Name = "Commenter",
                Email = "commenter@example.com",
                Body = "This is a comment."
            };

            var createdComment = apiClient.CreateComment(newComment.PostId, newComment);
            Assert.IsNotNull(createdComment);
            Assert.AreEqual(newComment.Body, createdComment.Body);
        }

        [TestMethod]
        public void TestGetCommentsForPost()
        {
            int postId = 1; // Get comments for post with ID 1
            List<Comment> comments = apiClient.GetCommentsForPost(postId);
            Assert.IsNotNull(comments);
            Assert.IsTrue(comments.Count > 0, "Comments list should not be empty.");
        }
    }
}
