using Smack.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopics();

        Task<Topic> GetTopic(string topicId);

        Task AddTopic(Topic topic);

        Task<bool> RemoveTopic(string topicId);

        Task<bool> UpdateTopic(string topicId, string title);

        Task<bool> RemoveAllTopics();

        Task<string> CreateIndex();
    }
}
