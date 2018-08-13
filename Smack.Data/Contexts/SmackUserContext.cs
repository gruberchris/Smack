using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Smack.Data.Models;

namespace Smack.Data.Contexts
{
    public class SmackUserContext
    {
        private readonly IMongoDatabase _database;

        public SmackUserContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<SmackUser> SmackUsers => _database.GetCollection<SmackUser>("SmackUsers");
    }
}
