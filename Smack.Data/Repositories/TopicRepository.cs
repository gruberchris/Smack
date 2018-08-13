using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Smack.Data.Contexts;
using Smack.Data.Models;

namespace Smack.Data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TopicContext _topicContext;

        public TopicRepository(IOptions<Settings> settings)
        {
            _topicContext = new TopicContext(settings);
        }

        public async Task AddTopic(Topic topic)
        {
            topic.CreatedOn = DateTime.Now;

            await _topicContext.Topics.InsertOneAsync(topic);
        }

        public async Task<string> CreateIndex()
        {
            var keys = Builders<Topic>.IndexKeys.Ascending(item => item.Id);

            return await _topicContext.Topics.Indexes.CreateOneAsync(new CreateIndexModel<Topic>(keys));
        }

        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            return await _topicContext.Topics.Find(_ => true).ToListAsync();
        }

        public async Task<Topic> GetTopic(string id)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            return await _topicContext.Topics.Find(topic => topic.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAllTopics()
        {
            var actionResult = await _topicContext.Topics.DeleteManyAsync(new BsonDocument());

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> RemoveTopic(string id)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            var actionResult = await _topicContext.Topics.DeleteOneAsync(Builders<Topic>.Filter.Eq("Id", objectId));

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateTopic(string id, string title)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            var filter = Builders<Topic>.Filter.Eq(s => s.Id, objectId);

            var update = Builders<Topic>.Update.Set(s => s.Title, title)
                .CurrentDate(s => s.LastModifiedOn);

            var actionResult = await _topicContext.Topics.UpdateOneAsync(filter, update);

            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }
    }
}
