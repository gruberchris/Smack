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

        public async Task AddTopic(Topic item)
        {
            await _topicContext.Topics.InsertOneAsync(item);
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
            var internalId = GetInternalId(id);

            return await _topicContext.Topics.Find(topic => topic.TopicId == id || topic.Id == internalId).FirstOrDefaultAsync();
        }

        private ObjectId GetInternalId(string id)
        {
            return ObjectId.TryParse(id, out var internalId) ? internalId : ObjectId.Empty;
        }

        public Task<IEnumerable<Topic>> GetTopic(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllTopics()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTopic(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTopic(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}
