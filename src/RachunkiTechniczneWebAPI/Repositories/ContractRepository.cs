using RachunkiTechniczneWebApi.Dal;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using Dapper;
using static Dapper.SqlMapper;

namespace RachunkiTechniczneWebApi.Repositories
{
    public class ContractRepository : IContractRepository
    {

        private readonly DapperContext _context;
        private readonly ILogger<UserRepository> _logger;

        public ContractRepository(DapperContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

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
                        LEFT JOIN USER_CON AS UC ON C.Id_con = UC.Id_con
                        LEFT JOIN USERS AS U ON UC.Id_user = U.Id_user
                        WHERE U.Login = @User;";
            
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel, Inventory, ContractModel>(sql,
                    (contract, inventory) =>
                    {
                        contract.Inventory = inventory;
                        return contract;
                    }, splitOn: "Date",
                    param: new { User = user });
            }
        }

        public async Task<IEnumerable<ContractModel>> GetAllAsync()
        {
            var sql = @"
                        SELECT
                        C.Id_con,
                        C.Contract,
                        C.Product_code,
                        C.Currency,
                        C.Opening_date,
                        C.Is_correct,
                        C.Correct_balance,
                        C.Comment,
                        I.Date,
                        I.Currency,
                        I.Account,
                        I.Subaccount,
                        I.Balance,
                        U.Owner,
                        U.Login,
                        U.Password,
                        U.Is_admin 
                        FROM CONTRACTS AS C
                        LEFT JOIN INVENTORY AS I ON C.Id_in = I.Id_in
                        LEFT JOIN USER_CON AS UC ON C.Id_con = UC.Id_con
                        LEFT JOIN USERS AS U ON UC.Id_user = U.Id_user
             ";


            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel, Inventory, User, ContractModel>(sql,
                    (contract, inventory, user) =>
                    {
                        contract.Inventory = inventory;
                        contract.User = user;
                        return contract;
                    }, splitOn: "Date, Owner");
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

