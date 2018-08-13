using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Smack.Data.Contexts;
using Smack.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public class SmackUserRepository : ISmackUserRepository
    {
        private readonly SmackUserContext _smackUserContext;

        public SmackUserRepository(IOptions<Settings> settings)
        {
            _smackUserContext = new SmackUserContext(settings);
        }

        public async Task AddSmackUser(SmackUser smackUser)
        {
            smackUser.CreatedOn = DateTime.Now;

            await _smackUserContext.SmackUsers.InsertOneAsync(smackUser);
        }

        public async Task<string> CreateIndex()
        {
            var keys = Builders<SmackUser>.IndexKeys.Ascending(item => item.Id);

            return await _smackUserContext.SmackUsers.Indexes.CreateOneAsync(new CreateIndexModel<SmackUser>(keys));
        }

        public async Task<IEnumerable<SmackUser>> GetAllSmackUsers()
        {
            return await _smackUserContext.SmackUsers.Find(_ => true).ToListAsync();
        }

        public async Task<SmackUser> GetSmackUser(string id)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            return await _smackUserContext.SmackUsers.Find(smackUser => smackUser.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAllSmackUsers()
        {
            var actionResult = await _smackUserContext.SmackUsers.DeleteManyAsync(new BsonDocument());

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> RemoveSmackUser(string id)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            var actionResult = await _smackUserContext.SmackUsers.DeleteOneAsync(Builders<SmackUser>.Filter.Eq("Id", objectId));

            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateSmackUser(string id, string firstName, string lastName, string nickName, string email)
        {
            var objectId = RepositoryUtils.GetObjectId(id);

            var filter = Builders<SmackUser>.Filter.Eq(s => s.Id, objectId);

            var update = Builders<SmackUser>.Update.Set(s => s.FirstName, firstName)
                .Set(s => s.LastName, lastName)
                .Set(s => s.NickName, nickName)
                .Set(s => s.Email, email)
                .CurrentDate(s => s.LastModifiedOn);

            var actionResult = await _smackUserContext.SmackUsers.UpdateOneAsync(filter, update);

            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }
    }
}
