using RachunkiTechniczneWebApi.Dal;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using Dapper;
using System.Diagnostics;
using static Dapper.SqlMapper;
using System.ComponentModel.DataAnnotations;
using RachunkiTechniczneWebApi.Interfaces.User;

namespace RachunkiTechniczneWebApi.Repositories
{
    public class ContractRepository : IContractRepository
    {

        private readonly DapperContext _context;
        private readonly ILogger<ContractRepository> _logger;

        public ContractRepository(DapperContext context, ILogger<ContractRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /*
        public List<Kontrakty> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Kontrakty>("SELECT * FROM KONTRAKTY").ToList();
            }
        }

        public List<Kontrakty> GetBySearchTerm(string term)
        {
            using (var connection = _context.CreateConnection())
            {
                var searchTerm = $"%{term}%";
                return connection.Query<Kontrakty>("SELECT * FROM KONTRAKTY WHERE Title LIKE @Term", new { Term = searchTerm }).ToList();
            }
        }
        */

        public async Task<IEnumerable<ContractModel>> GetForUserAsync(string user)
        {
            var sql = @"
                        SELECT
                        C.Product_code,
                        C.Contract,
                        C.Currency,
                        I.Date,
                        I.Balance
                        FROM CONTRACTS AS C
                        LEFT JOIN INVENTORY AS I ON C.Id_in = I.Id_in
             ";
            

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel, Inventory, ContractModel>(sql, 
                    (contract, inventory) =>
                    {
                        contract.Inventory = inventory;
                        return contract;
                    }, splitOn: "Date");
            }
        }

        public async Task<IEnumerable<ContractModel>> GetAllAsync()
        {
            var sql = "SELECT U.Owner, C.Contract, C.Product_code, C.Currency, C.Opening_date FROM Contracts AS C LEFT JOIN USER_CON AS UC ON C.Id_con = UC.Id_con LEFT JOIN USERS AS U ON UC.Id_user = U.Id_user";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel>(sql);
            }
        }

        public async Task<IEnumerable<ContractModel>> GetByIdAsync(int id)
        {
            var sql = "SELECT U.Owner, C.Contract, C.Product_code, C.Currency, C.Opening_date FROM Contracts AS C LEFT JOIN USER_CON AS UC ON C.Id_con = UC.Id_con LEFT JOIN USERS AS U ON UC.Id_user = U.Id_user WHERE Id_con = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel>(sql, new { Id = id });
            }
        }

        public Task<bool> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
        /*
        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Kontrakty WHERE Id_kon = @Id";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteAsync(string kontrakt)
        {
            var sql = "DELETE FROM Kontrakty WHERE Kontrakt = @Kontrakt";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Kontrakt = kontrakt });
                return affectedRows > 0;
            }
        }

        */
        public async Task<int> AddAsync(ContractModel entity)
        {
            var sql = "INSERT INTO Contracts (Id_con, Contract, Contract18, Product_code, Currency, Opening_date, Closing_date) VALUES (@Id_con, @Contract, @Contract18, @Product_code, @Currency, @Opening_date, @Closing_date); SELECT CAST(SCOPE_IDENTITY() AS int)";
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(sql, entity);
                return id;
            }
        }

        

        public Task<bool> UpdateAsync(int id, bool paid)
        {
            throw new NotImplementedException();
        }

        Task<ContractModel> IRepository<ContractModel>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

