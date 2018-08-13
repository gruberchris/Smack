using Smack.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopics();

        Task<Topic> GetTopic(string id);

        Task AddTopic(Topic topic);

        Task<bool> RemoveTopic(string id);

        Task<bool> UpdateTopic(string id, string title);

        Task<bool> RemoveAllTopics();

        Task<string> CreateIndex();
    }
}
