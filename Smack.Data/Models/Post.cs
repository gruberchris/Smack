using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Smack.Data.Models
{
    public class Post : SmackModelBase
    {
        [BsonElement("postId")]
        public string PostId { get; set; }

        [BsonElement("postText")]
        public string PostText { get; set; }

        [BsonElement]
        public SmackUser Owner { get; set; }
    }
}
