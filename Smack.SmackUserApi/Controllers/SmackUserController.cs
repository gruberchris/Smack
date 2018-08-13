using Microsoft.AspNetCore.Mvc;
using Smack.Data.Models;
using Smack.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.SmackUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmackUserController : ControllerBase
    {
        private readonly ISmackUserRepository _smackUserRepository;

        public SmackUserController(ISmackUserRepository smackUserRepository)
        {
            _smackUserRepository = smackUserRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SmackUser>> Get()
        {
            return await _smackUserRepository.GetAllSmackUsers();
        }

        [HttpGet("{smackUserId}")]
        public async Task<SmackUser> Get(string smackUserId)
        {
            return await _smackUserRepository.GetSmackUser(smackUserId) ?? new SmackUser();
        }

        [HttpPost]
        public void Post([FromBody] SmackUser smackUser)
        {
            _smackUserRepository.AddSmackUser(new SmackUser
            {
                FirstName = smackUser.FirstName,
                LastName = smackUser.LastName,
                NickName = smackUser.NickName,
                Email = smackUser.Email
            });
        }

        [HttpPut("{smackUserId}")]
        public void Put(string smackUserId, [FromBody] SmackUser smackUser)
        {
            _smackUserRepository.UpdateSmackUser(smackUserId, smackUser.FirstName, smackUser.LastName, smackUser.NickName, smackUser.Email);
        }

        [HttpDelete("{smackUserId}")]
        public void Delete(string smackUserId)
        {
            _smackUserRepository.RemoveSmackUser(smackUserId);
        }
    }
}
