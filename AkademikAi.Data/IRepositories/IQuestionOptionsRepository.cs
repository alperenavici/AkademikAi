using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.IRepositories
{
    public interface IQuestionOptionsRepository
    {
        Task<List<QuestionsOptions>> GetQuestionsOptionsbyQuestionIdAsync(Guid questionId);
        Task<QuestionsOptions> GetQuestionOptionByIdAsync(Guid optionId);
        Task<List<QuestionsOptions>> GetQuestionsOptionsByLabelAsync(char label);
    }
}
