using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Smack.Data.Models;

namespace Smack.Data.Contexts
{
    public class TopicContext
    {
        private readonly IMongoDatabase _database;

        public TopicContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Topic> Topics => _database.GetCollection<Topic>("Topics");
    }
}
