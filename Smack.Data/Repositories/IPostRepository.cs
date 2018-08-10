using Smack.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<Post> GetPost(string postId);

        Task AddPost(Post post);

        Task<bool> RemovePost(string postId);

        Task<bool> UpdatePost(string postId, string postText, string ownerUserId);

        Task<bool> RemoveAllPosts();

        Task<string> CreateIndex();
    }
}
