using Microsoft.AspNetCore.Mvc;
using Smack.Data.Models;
using Smack.Data.Repositories;
using Smack.PostsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.PostsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _postRepository.GetAllPosts();
        }

        [HttpGet("{postId}")]
        public async Task<Post> Get(string postId)
        {
            return await _postRepository.GetPost(postId) ?? new Post();
        }

        [HttpPost]
        public void Post([FromBody] PostParam postParam)
        {
            _postRepository.AddPost(new Post
            {
                PostId = postParam.PostId,
                PostText = postParam.PostText,
                OwnerUserId = postParam.OwnerUserId
            });
        }

        [HttpPut("{postId}")]
        public void Put(string postId, [FromBody] PostParam postParam)
        {
            _postRepository.UpdatePost(postId, postParam.PostText, postParam.OwnerUserId);
        }

        [HttpDelete("{postId}")]
        public void Delete(string postId)
        {
            _postRepository.RemovePost(postId);
        }
    }
}
