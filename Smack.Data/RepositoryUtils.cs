using MongoDB.Bson;

namespace Smack.Data
{
    internal static class RepositoryUtils
    {
        public static ObjectId GetObjectId(string id)
        {
            return ObjectId.TryParse(id, out var objectId) ? objectId : ObjectId.Empty;
        }
    }
}
