using Smack.Data.Models;

namespace Smack.PostsApi.Models
{
    public class PostParam
    {
        public string PostId { get; set; }

        public string PostText { get; set; }

        public string OwnerUserId { get; set; }

        public Topic Topic { get; set; }
    }
}
