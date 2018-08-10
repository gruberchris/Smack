using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Smack.Data.Models
{
    public class Topic
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("topicId")]
        public string TopicId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("lastModifiedOn")]
        public DateTime LastModifiedOn { get; set; }

        [BsonElement("ownerUserId")]
        public string OwnerUserId { get; set; }

        [BsonElement("posts")]
        public IEnumerable<Post> Posts { get; set; }
    }
}
