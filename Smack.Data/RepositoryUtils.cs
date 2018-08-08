using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smack.Data
{
    internal static class RepositoryUtils
    {
        public static ObjectId GetInternalId(string topicId)
        {
            return ObjectId.TryParse(topicId, out var internalId) ? internalId : ObjectId.Empty;
        }
    }
}
