using Smack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopics();

        Task<Topic> GetTopic(string id);

        Task<IEnumerable<Topic>> GetTopic(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        Task AddTopic(Topic item);

        Task<bool> RemoveTopic(string id);

        Task<bool> UpdateTopic(string id, string body);

        Task<bool> RemoveAllTopics();

        Task<string> CreateIndex();
    }
}
