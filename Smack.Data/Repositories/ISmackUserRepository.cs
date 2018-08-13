using Smack.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.Data.Repositories
{
    public interface ISmackUserRepository
    {
        Task<IEnumerable<SmackUser>> GetAllSmackUsers();

        Task<SmackUser> GetSmackUser(string id);

        Task AddSmackUser(SmackUser smackUser);

        Task<bool> RemoveSmackUser(string id);

        Task<bool> UpdateSmackUser(string id, string firstName, string lastName, string nickName, string email);

        Task<bool> RemoveAllSmackUsers();

        Task<string> CreateIndex();
    }
}
