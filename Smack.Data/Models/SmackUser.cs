using MongoDB.Bson.Serialization.Attributes;

namespace Smack.Data.Models
{
    public class SmackUser : SmackModelBase
    {
        [BsonElement("smackUserId")]
        public string SmackUserId { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("nickName")]
        public string NickName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
