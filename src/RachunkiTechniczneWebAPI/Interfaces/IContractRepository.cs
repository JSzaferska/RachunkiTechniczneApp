using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IContractRepository : IRepository<ContractModel>
    {
        Task<IEnumerable<ContractModel>> GetByUserAsync(string user);
        Task<IEnumerable<ContractModel>> GetAllAsync();

        Task<IEnumerable<ContractModel>> GetByIdAsync(int id);

    }
}
