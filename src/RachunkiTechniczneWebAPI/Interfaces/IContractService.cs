using UserContractDto = RachunkiTechniczneWebApi.DTOs.User.ContractDto;
using AdminContractDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractDto;
using AdminContractRegistryDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractRegistryDto;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Models;
using RachunkiTechniczneWebApi.DTOs.User;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IContractService
    {
        Task<List<UserContractDto>> GetUserContract(string login);
        Task<List<AdminContractDto>> GetAllContract();
        Task<List<AdminContractRegistryDto>> GetRegistryContract();
        Task<int> AddRegistryContract(AddContractRegistryDto contract);
        Task<bool> UpdateContract(AdminContractDto contractDto);
        Task<bool> DeleteContract(int id);
        Task<AdminContractRegistryDto> GetById(int id);
        Task<bool> UpdateUserContract(UpdateUserContractDto contract);
    }
}
