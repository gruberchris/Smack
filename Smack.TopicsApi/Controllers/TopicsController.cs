using Microsoft.AspNetCore.Mvc;
using Smack.Data.Models;
using Smack.Data.Repositories;
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
        public void Post([FromBody] Topic topic)
        {
            _topicRepository.AddTopic(new Topic
            {
                Title = topic.Title
            });
        }

        [HttpPut("{topicId}")]
        public void Put(string topicId, [FromBody] Topic topic)
        {
            _topicRepository.UpdateTopic(topicId, topic.Title);
        }

        [HttpDelete("{topicId}")]
        public void Delete(string topicId)
        {
            _topicRepository.RemoveTopic(topicId);
        }
    }
}
