﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Smack.Data.Models
{
    public class Topic : SmackModelBase
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("posts")]
        public IEnumerable<Post> Posts { get; set; }

        [BsonElement]
        public MongoDBRef OwnerId { get; set; }
    }
}
