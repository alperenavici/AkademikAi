using AkademikAi.Data.Context;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Data.IRepositories;

namespace AkademikAi.Data.Repositories
{
    public class TopicRepository:GenericRepository<Topics>, ITopicRepository
    {
        private readonly AppDbContext _context;
        public TopicRepository(AppDbContext context)
        {
        }

        public async Task<List<Topics>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();
        }
        public async Task<Topics> GetTopicByIdAsync(Guid topicId)
        {
            return await _context.Topics
                .FirstOrDefaultAsync(t => t.Id == topicId);
        }

        
    }
}
