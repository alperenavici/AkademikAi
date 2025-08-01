using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IQuestionTopicRepository : IGenericRepository<QuestionsTopic>
    {
        Task<List<QuestionsTopic>> GetTopicsByQuestionIdAsync(Guid questionId);
        Task<List<QuestionsTopic>> GetQuestionsByTopicIdAsync(Guid topicId);
        Task<QuestionsTopic?> GetQuestionTopicByIdAsync(Guid questionId);
        Task<List<QuestionsTopic>> GetQuestionsTopicsByQuestionTextAsync(string questionText);
    }
}
