using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikAi.Service.Services
{
    public class SubjectService : GenericService<Subject>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(
            ISubjectRepository subjectRepository,
            IUnitOfWork unitOfWork) : base(subjectRepository)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Subject>> GetActiveSubjectsAsync()
        {
            return await _subjectRepository.GetActiveSubjectsAsync();
        }

        public async Task<Subject?> GetSubjectWithTopicsAsync(Guid subjectId)
        {
            return await _subjectRepository.GetSubjectWithTopicsAsync(subjectId);
        }

        public async Task<Subject> CreateSubjectAsync(string subjectName, string? description = null)
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                SubjectName = subjectName,
                Description = description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _subjectRepository.AddAsync(subject);
            await _unitOfWork.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> UpdateSubjectAsync(Guid subjectId, string subjectName, string? description = null)
        {
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            if (subject == null) return false;

            subject.SubjectName = subjectName;
            subject.Description = description;

            _subjectRepository.Update(subject);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            if (subject == null) return false;

            // Check if subject has topics
            var hasTopics = await _subjectRepository.HasTopicsAsync(subjectId);
            if (hasTopics) return false; // Cannot delete subject with topics

            _subjectRepository.Remove(subject);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasTopicsAsync(Guid subjectId)
        {
            return await _subjectRepository.HasTopicsAsync(subjectId);
        }
    }
}
