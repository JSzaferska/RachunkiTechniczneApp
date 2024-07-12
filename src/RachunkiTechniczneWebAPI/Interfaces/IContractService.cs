using UserContractDto = RachunkiTechniczneWebApi.DTOs.User.ContractDto;
using AdminContractDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractDto;
using AdminContractRegistryDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractRegistryDto;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IContractService
    {
        Task<List<UserContractDto>> GetUserContract(string login);
        Task<List<AdminContractDto>> GetAllContract();
        Task<List<AdminContractRegistryDto>> GetRegistryContract();
    }
}
