using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> GetUserByIdAsync(Guid UserId);
        Task<List<Users>> GetByUserRoleAsync(UserRole userRole);
        Task<Users> GetByEmailAsync(string email);
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByEmailAsync(string email);
        Task<List<Users>> GetUsersByPhoneAsync(string phone);
        Task<List<Users>> GetUsersByNameAndSurnameAsync(string name,string surname);
    }
}
