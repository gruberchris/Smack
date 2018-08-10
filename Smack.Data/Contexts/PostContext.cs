using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Smack.Data.Models;

namespace Smack.Data.Contexts
{
    public class PostContext
    {
        private readonly IMongoDatabase _database;

        public PostContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Post");
    }
}
