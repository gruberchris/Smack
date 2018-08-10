using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Smack.Data.Contexts;
using Smack.Data.Models;

namespace Smack.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostContext _postContext;

        public PostRepository(IOptions<Settings> settings)
        {
            _postContext = new PostContext(settings);
        }

        public async Task AddPost(Post post)
        {
            post.CreatedOn = DateTime.Now;

            await _postContext.Posts.InsertOneAsync(post);
        }

        public async Task<string> CreateIndex()
        {
            var keys = Builders<Post>.IndexKeys.Ascending(item => item.Id);

            return await _postContext.Posts.Indexes.CreateOneAsync(new CreateIndexModel<Post>(keys));
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postContext.Posts.Find(_ => true).ToListAsync();
        }

        public async Task<Post> GetPost(string postId)
        {
            var internalId = RepositoryUtils.GetInternalId(postId);

            return await _postContext.Posts.Find(post => post.PostId == postId || post.Id == internalId).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAllPosts()
        {
            var actionResult = await _postContext.Posts.DeleteManyAsync(new BsonDocument());

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> RemovePost(string postId)
        {
            var actionResult = await _postContext.Posts.DeleteOneAsync(Builders<Post>.Filter.Eq("PostId", postId));

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> UpdatePost(string postId, string postText, string ownerUserId)
        {
            var filter = Builders<Post>.Filter.Eq(s => s.PostId, postId);

            var update = Builders<Post>.Update.Set(s => s.PostText, postText)
                .Set(s => s.OwnerUserId, ownerUserId)
                .CurrentDate(s => s.LastModifiedOn);

            var actionResult = await _postContext.Posts.UpdateOneAsync(filter, update);

            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }
    }
}
