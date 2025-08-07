using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Service.IServices
{
    public interface ISubjectService : IGenericService<Subject>
    {
        Task<List<Subject>> GetActiveSubjectsAsync();
        Task<Subject?> GetSubjectWithTopicsAsync(Guid subjectId);
        Task<Subject> CreateSubjectAsync(string subjectName, string? description = null);
        Task<bool> UpdateSubjectAsync(Guid subjectId, string subjectName, string? description = null);
        Task<bool> DeleteSubjectAsync(Guid subjectId);
        Task<bool> HasTopicsAsync(Guid subjectId);
    }
}
