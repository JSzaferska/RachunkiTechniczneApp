using RachunkiTechniczneWebApi.Models;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, bool paid)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<User>.AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IRepository<User>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
