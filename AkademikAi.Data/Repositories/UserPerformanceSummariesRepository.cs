using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademikAi.Data.Repositories
{
    public class UserPerformanceSummariesRepository : GenericRepository<UserPerformanceSummaries>, IUserPerformanceSummariesRepository
    {
        private readonly AppDbContext _context;

        public UserPerformanceSummariesRepository(AppDbContext context) : base(context)
        {

        }
    }
}
