using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        
        private IAppUserRepository? _appUserRepository;
        private IAppRoleRepository? _appRoleRepository;
        private IQuestionRepository? _questionRepository;
        private ITopicRepository? _topicRepository;
        private IQuestionOptionsRepository? _questionOptionRepository;
        private IQuestionTopicRepository? _questionTopicRepository;
        private IUserRecommendationRepository? _userRecommendationRepository;
        private IUserPerformanceSummariesRepository? _performanceSummaryRepository; 
        private IUserNotificationsRepository? _notificationRepository;         
        private IUserAnswersRepository? _userAnswerRepository;            
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

      

        public IAppUserRepository AppUser => _appUserRepository ??= new AppUserRepository(_context);
        public IAppRoleRepository AppRole => _appRoleRepository ??= new AppRoleRepository(_context);
        public IQuestionRepository questions => _questionRepository ??= new QuestionRepository(_context);
        public ITopicRepository topics => _topicRepository ??= new TopicRepository(_context);
        public IQuestionOptionsRepository questionsOptions => _questionOptionRepository ??= new QuestionOptionsRepository(_context);
        public IQuestionTopicRepository questionsTopic => _questionTopicRepository ??= new QuestionTopicRepository(_context);
        public IUserRecommendationRepository userRecommendations => _userRecommendationRepository ??= new UserRecommendationRepository(_context);
        public IUserPerformanceSummariesRepository userPerformanceSummaries => _performanceSummaryRepository ??= new UserPerformanceSummariesRepository(_context);
        public IUserNotificationsRepository userNotifications => _notificationRepository ??= new UserNotificationsRepository(_context);
        public IUserAnswersRepository userAnswers => _userAnswerRepository ??= new UserAnswerRepository(_context);


        // --- DEĞİŞİKLİK KAYDETME METOTLARI ---

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        // --- TRANSACTION YÖNETİMİ METOTLARI ---

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }


        // --- IDisposable IMPLEMENTASYONU ---

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
