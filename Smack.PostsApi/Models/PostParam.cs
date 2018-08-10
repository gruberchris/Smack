using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smack.PostsApi.Models
{
    public class PostParam
    {
        public string PostId { get; set; }

        public string PostText { get; set; }

        public string OwnerUserId { get; set; }
    }
}
