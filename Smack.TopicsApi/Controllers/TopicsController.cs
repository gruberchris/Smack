using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Smack.Data.Models;
using Smack.Data.Repositories;
using Smack.TopicsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smack.TopicsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicsController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Topic>> Get()
        {
            return await _topicRepository.GetAllTopics();
        }

        [HttpGet("{topicId}")]
        public async Task<Topic> Get(string topicId)
        {
            return await _topicRepository.GetTopic(topicId) ?? new Topic();
        }

        [HttpPost]
        public void Post([FromBody] TopicParam topicParam)
        {
            _topicRepository.AddTopic(new Topic
            {
                TopicId = topicParam.TopicId,
                Title = topicParam.TopicId,
                OwnerUserId = topicParam.OwnerUserId
            });
        }

        [HttpPut("{topicId}")]
        public void Put(string topicId, [FromBody] TopicParam topicParam)
        {
            _topicRepository.UpdateTopic(topicId, topicParam.Title, topicParam.OwnerUserId);
        }

        [HttpDelete("{topicId}")]
        public void Delete(string topicId)
        {
            _topicRepository.RemoveTopic(topicId);
        }
    }
}
