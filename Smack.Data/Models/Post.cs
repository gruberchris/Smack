using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Smack.Data.Models
{
    public class Post : SmackModelBase
    {
        [BsonElement("postText")]
        public string PostText { get; set; }

        [BsonElement]
        public SmackUser Owner { get; set; }
    }
}
