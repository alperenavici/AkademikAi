using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface ITopicRepository
    {
        Task<List<Topics>> GetAllTopicsAsync();
        Task<Topics> GetTopicByIdAsync(Guid topicId);
    }
}
