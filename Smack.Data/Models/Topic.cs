using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smack.Data.Models
{
    public class Topic
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string TopicId { get; set; }

        [BsonElement]
        public string Title { get; set; }
    }
}
