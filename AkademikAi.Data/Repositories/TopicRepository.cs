using AkademikAi.Data.Context;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using AkademikAi.Data.IRepositories;


namespace AkademikAi.Data.Repositories
{
    public class TopicRepository:GenericRepository<Topics>, ITopicRepository
    {
        private readonly AppDbContext _context;
        public TopicRepository(AppDbContext context):base(context) {
            _context = context;
        }

        public async Task<List<Topics>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();
        }
        public async Task<Topics?> GetTopicByIdAsync(Guid topicId)
        {
            return await _context.Topics
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.Id == topicId);
        }

        public async Task<List<Topics>> GetTopicsBySubjectIdAsync(Guid subjectId)
        {
            return await _context.Topics
                .Where(t => t.SubjectId == subjectId && t.IsActive)
                .OrderBy(t => t.TopicName)
                .ToListAsync();
        }

        public async Task<List<Topics>> GetMainTopicsAsync()
        {
            return await _context.Topics
                .Where(t => t.ParentTopicId == null && t.IsActive)
                .Include(t => t.Subject)
                .OrderBy(t => t.TopicName)
                .ToListAsync();
        }

        public async Task<List<Topics>> GetSubTopicsAsync(Guid parentTopicId)
        {
            return await _context.Topics
                .Where(t => t.ParentTopicId == parentTopicId && t.IsActive)
                .Include(t => t.Subject)
                .OrderBy(t => t.TopicName)
                .ToListAsync();
        }

        public async Task<List<Topics>> GetActiveTopicsAsync()
        {
            return await _context.Topics
                .Where(t => t.IsActive)
                .Include(t => t.Subject)
                .OrderBy(t => t.Subject.SubjectName)
                .ThenBy(t => t.TopicName)
                .ToListAsync();
        }

        public async Task<Topics?> GetTopicWithSubTopicsAsync(Guid topicId)
        {
            return await _context.Topics
                .Include(t => t.Subject)
                .Include(t => t.SubTopics.Where(st => st.IsActive))
                .FirstOrDefaultAsync(t => t.Id == topicId);
        }
    }
}
