using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces.User
{
    public interface IContractRepository : IRepository<ContractModel>
    {
        Task<IEnumerable<ContractModel>> GetForUserAsync(string user);
        Task<IEnumerable<ContractModel>> GetAllAsync();

        Task<IEnumerable<ContractModel>> GetByIdAsync(int id);

    }
}
