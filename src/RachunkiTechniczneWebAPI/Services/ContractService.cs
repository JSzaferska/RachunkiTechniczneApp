using UserContractDto = RachunkiTechniczneWebApi.DTOs.User.ContractDto;
using AdminContractDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractDto;
using AdminContractRegistryDto = RachunkiTechniczneWebApi.DTOs.Admin.ContractRegistryDto;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
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
                    ProductCode = contract.Product_code,
                    Contract = contract.Contract,
                    Currency = contract.Currency,
                    Date = contract.Inventory.Date,
                    Balance = contract.Inventory.Balance,

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

    }
}
