using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Smack.Data.Models
{
    public class Post : SmackModelBase
    {
        [BsonElement("postText")]
        public string PostText { get; set; }

        [BsonElement]
        public MongoDBRef OwnerId { get; set; }
    }
}
