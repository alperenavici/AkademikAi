using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Task<List<Subject>> GetActiveSubjectsAsync();
        Task<Subject?> GetSubjectWithTopicsAsync(Guid subjectId);
        Task<bool> HasTopicsAsync(Guid subjectId);
    }
}
