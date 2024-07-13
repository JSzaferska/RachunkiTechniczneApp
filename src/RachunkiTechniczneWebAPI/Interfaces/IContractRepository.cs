using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<ContractModel>> GetForUserAsync(string user);
        Task<IEnumerable<ContractModel>> GetAllAsync();
        ContractModel GetById(int id);
        Task<int> AddContractAsync(ContractModel entity, UserConModel userCon);
        Task<bool> UpdateContractAsync(ContractModel entity);
        Task<bool> DeleteContractAsync(int id);

        Task<bool> UpdateUserContractAsync(ContractModel entity);
    }
}
