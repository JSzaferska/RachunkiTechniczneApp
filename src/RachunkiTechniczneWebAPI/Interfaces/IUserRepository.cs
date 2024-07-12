using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> AddUserAsync(User entity);
        Task<User> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteUserAsync(int id);
    }
}
