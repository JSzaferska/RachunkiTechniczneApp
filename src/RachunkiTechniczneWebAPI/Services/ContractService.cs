using UserContractDto = RachunkiTechniczneWebApi.DTOs.User.ContractDto;
using AdminContractDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractDto;
using AdminContractRegistryDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractRegistryDto;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Models;
using RachunkiTechniczneWebApi.Repositories;
using System.Buffers;
using System.Diagnostics.Contracts;
using RachunkiTechniczneWebApi.DTOs.User;

namespace RachunkiTechniczneWebApi.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUserRepository _userRepository;

        public ContractService(IContractRepository contractRepository, IUserRepository userRepository)
        {
            _contractRepository = contractRepository;
            _userRepository = userRepository;
        }

        public async Task<List<AdminContractDto>> GetAllContract()
        {
            var allContractModels = await _contractRepository.GetAllAsync();
            var contractList = new List<AdminContractDto>();
            foreach (var contract in allContractModels)
            {
                var mapper = new AdminContractDto()
                {
                    ContractId = contract.Id_con,
                    Owner = contract.User.Owner,
                    Date = contract.Inventory.Date,
                    ProductCode = contract.Product_code,
                    Contract = contract.Contract,
                    Currency = contract.Currency,
                    Account = contract.Inventory.Account,
                    SubAccount = contract.Inventory.SubAccount,
                    Balance = contract.Inventory.Balance,
                    IsCorrect = contract.Is_correct,
                    CorrectBalance = contract.Correct_balance,
                    Comment = contract.Comment
                };
                contractList.Add(mapper);
            }
            return contractList;
        }

        public async Task<List<UserContractDto>> GetUserContract(string login)
        {
            var userContractsModels = await _contractRepository.GetForUserAsync(login);
            var contractList = new List<UserContractDto>();
            foreach (var contract in userContractsModels)
            {
                var mapper = new UserContractDto()
                {
                    ContractId = contract.Id_con,
                    ProductCode = contract.Product_code,
                    Contract = contract.Contract,
                    Currency = contract.Currency,
                    Date = contract.Inventory.Date,
                    Balance = contract.Inventory.Balance,
                    IsCorrect= contract.Is_correct,
                    CorrectBalance= contract.Correct_balance,
                    Comment = contract.Comment

                };
                contractList.Add(mapper);
            }
            return contractList;
        }

        public async Task<List<AdminContractRegistryDto>> GetRegistryContract()
        {
            var allContractModels = await _contractRepository.GetAllAsync();
            var contractList = new List<AdminContractRegistryDto>();
            foreach (var contract in allContractModels)
            {
                var mapper = new AdminContractRegistryDto()
                {
                    ContractId = contract.Id_con,
                    Owner = contract.User.Owner,
                    OpeningDate = contract.Opening_date,
                    ProductCode = contract.Product_code,
                    Contract = contract.Contract,
                    Currency = contract.Currency,
                    Account = contract.Inventory.Account,
                    SubAccount = contract.Inventory.SubAccount
                };
                contractList.Add(mapper);
            }
            return contractList;
        }

        public async Task<int> AddRegistryContract(AddContractRegistryDto contract)
        {
            var contractModel = new ContractModel
            {
                Contract = contract.Contract,
                Product_code = contract.ProductCode,
                Currency = contract.Currency,
                Opening_date = contract.OpeningDate
            };

            var user = await _userRepository.GetByLoginAsync(contract.Owner);

            var userCon = new UserConModel
            {
                Id_user = user.Id_user
            };

            return await _contractRepository.AddContractAsync(contractModel, userCon);
        }

        public async Task<bool> UpdateContract(AdminContractDto contract)
        {
            var contractModel = new ContractModel
            {
                Id_con = contract.ContractId,
                Contract = contract.Contract,
                Product_code = contract.ProductCode,
                Currency = contract.Currency,
                Opening_date = contract.OpeningDate
            };
            return await _contractRepository.UpdateContractAsync(contractModel);
        }

        public async Task<bool> DeleteContract(int id)
        {
            return await _contractRepository.DeleteContractAsync(id);
        }
        
        public async Task<AdminContractRegistryDto> GetById(int id)
        {
            var contract = _contractRepository.GetById(id);
            var mapper = new AdminContractRegistryDto()
            {
                ContractId = contract.Id_con,
                Owner = contract.User.Owner,
                OpeningDate = contract.Opening_date,
                ProductCode = contract.Product_code,
                Contract = contract.Contract,
                Currency = contract.Currency,
                Account = contract.Inventory.Account,
                SubAccount = contract.Inventory.SubAccount
            };
            return mapper;
        }

        public async Task<bool> UpdateUserContract(UpdateUserContractDto contract)
        {
            var contractModel = new ContractModel
            {
                Id_con = contract.ContractId,
                Is_correct = contract.IsCorrect,
                Correct_balance = contract.CorrectBalance,
                Comment = contract.comment
            };
            return await _contractRepository.UpdateUserContractAsync(contractModel);
        }
    }
}
