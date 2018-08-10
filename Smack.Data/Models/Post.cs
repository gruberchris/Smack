using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Smack.Data.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("postId")]
        public string PostId { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("lastModifiedOn")]
        public DateTime LastModifiedOn { get; set; }

        [BsonElement("ownerUserId")]
        public string OwnerUserId { get; set; }
    }
}
