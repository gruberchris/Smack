using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Smack.Data.Models
{
    public class Topic : SmackModelBase
    {
        [BsonElement("topicId")]
        public string TopicId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("posts")]
        public IEnumerable<Post> Posts { get; set; }

        [BsonElement]
        public SmackUser Owner { get; set; }
    }
}
