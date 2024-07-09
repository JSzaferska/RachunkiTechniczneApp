using RachunkiTechniczneWebApi.DTOs.User;

namespace RachunkiTechniczneWebApi.Interfaces.User
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetUserContract(string login);
    }
}
