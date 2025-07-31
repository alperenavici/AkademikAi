using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {  
        public IUserRepository AppUser { get; }
        public IQuestionRepository questions { get; }
        public ITopicRepository topics { get; }
        public IQuestionOptionsRepository questionsOptions { get; }
        public IQuestionTopicRepository questionsTopic { get; }
        public IUserRecommendationRepository userRecommendations { get; }
        public IUserPerformanceSummariesRepository userPerformanceSummaries { get; }
        public IUserNotificationsRepository userNotifications { get; }
        public IUserAnswersRepository userAnswers { get; }





        Task<int> SaveChangesAsync();
        void SaveChanges();
        Task BeginTransactionAsync();
        void Commit();
        void Rollback();
    }
    
   
}
