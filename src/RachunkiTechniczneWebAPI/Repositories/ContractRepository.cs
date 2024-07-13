using RachunkiTechniczneWebApi.Dal;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using Dapper;


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
            var sql = @"SELECT
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
                        WHERE U.Login = @User;";
            
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel, Inventory, User, ContractModel>(sql,
                    (contract, inventory, user) =>
                    {
                        contract.Inventory = inventory != null ? inventory : new Inventory();
                        contract.User = user != null ? user : new User();
                        return contract;
                    }, splitOn: "Date, Owner",
                    param: new { User = user });
            }
        }

        public async Task<IEnumerable<ContractModel>> GetAllAsync()
        {
            var sql = @"SELECT
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
                        LEFT JOIN USERS AS U ON UC.Id_user = U.Id_user";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractModel, Inventory, User, ContractModel>(sql,
                    (contract, inventory, user) =>
                    {
                        contract.Inventory = inventory != null ? inventory : new Inventory();
                        contract.User = user != null ? user : new User();
                        return contract;
                    }, splitOn: "Date, Owner");
            }
        }

        public ContractModel GetById(int id)
        {
            var sql = @"SELECT
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
                        WHERE C.Id_con = @Id";
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<ContractModel, Inventory, User, ContractModel>(sql,
                    (contract, inventory, user) =>
                    {
                        contract.Inventory = inventory != null ? inventory : new Inventory();
                        contract.User = user != null ? user : new User();
                        return contract;
                    }, splitOn: "Date, Owner",
                    param: new { Id = id }).FirstOrDefault();
            }
        }

        public async Task<int> AddContractAsync(ContractModel entity, UserConModel userCon)
        {
            var sql = @"INSERT INTO Contracts
                        (Contract, Product_code, Currency, Opening_date)
                        VALUES (@Contract, @Product_code, @Currency, @Opening_date);
                        SELECT CAST(SCOPE_IDENTITY() AS int)";

            var id = -1;
            using (var connection = _context.CreateConnection())
            {
                id = await connection.QuerySingleAsync<int>(sql, entity);
            }

            var sql2 = @"INSERT INTO User_Con
                         (id_con, id_user)
                         VALUES (@contract, @user)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql2, new { contract = id, user = userCon.Id_user});
            }

            return id;
        }

        public async Task<bool> UpdateContractAsync(ContractModel entity)
        {
            var sql = @"UPDATE Contracts SET
                        Contract = @Contract,
                        Product_code = @Product_code,
                        Currency = @Currency,
                        Opening_date = @Opening_date
                        WHERE Id_con = @Id_con;";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows > 0;
            }        
        }

        public async Task<bool> DeleteContractAsync(int id)
        {
            var sql = @"DELETE
                        FROM User_con
                        WHERE Id_con = @Id;
                        DELETE
                        FROM Contracts
                        WHERE Id_con = @Id;
                        ";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows > 0;
            }
        }

        public async Task<bool> UpdateUserContractAsync(ContractModel entity)
        {
            var sql = @"UPDATE Contracts SET
                        Is_correct = @Is_Correct,
                        Correct_balance = @Correct_Balance,
                        Comment = @Comment
                        WHERE Id_con = @Id_con;";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows > 0;
            }
        }
    }
}

