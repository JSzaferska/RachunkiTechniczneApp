using RachunkiTechniczneWebApi.DTOs.User;
using RachunkiTechniczneWebApi.Interfaces.User;
using RachunkiTechniczneWebApi.Repositories;
using System.Diagnostics.Contracts;

namespace RachunkiTechniczneWebApi.Services.User
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<List<ContractDto>> GetUserContract(string login)
        {
            var userContractsModels = await _contractRepository.GetForUserAsync(login);
            var contractList = new List<ContractDto>();
            foreach (var contract in userContractsModels)
            {
                var mapper = new ContractDto()
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
        
    }
}
