using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;

namespace AkademikAi.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserByIdAsync(Guid UserId);
        Task<List<AppUser>> GetByUserRoleAsync(UserRole userRole);
        Task<AppUser> GetByEmailAsync(string email);
        Task<List<AppUser>> GetAllAppUserAsync();
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<List<AppUser>> GetAppUserByPhoneAsync(string phone);
        Task<List<AppUser>> GetAppUserByNameAndSurnameAsync(string name,string surname);
    }
}
