using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetActiveSubjectsAsync()
        {
            return await _context.Subjects
                .Where(s => s.IsActive)
                .OrderBy(s => s.SubjectName)
                .ToListAsync();
        }

        public async Task<Subject?> GetSubjectWithTopicsAsync(Guid subjectId)
        {
            return await _context.Subjects
                .Include(s => s.Topics.Where(t => t.IsActive))
                .FirstOrDefaultAsync(s => s.Id == subjectId);
        }

        public async Task<bool> HasTopicsAsync(Guid subjectId)
        {
            return await _context.Topics
                .AnyAsync(t => t.SubjectId == subjectId && t.IsActive);
        }
    }
}
