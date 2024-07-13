using RachunkiTechniczneWebApi.Dal;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using Dapper;
using static Dapper.SqlMapper;
using RachunkiTechniczneWebApi.DTOs.Admin;

namespace RachunkiTechniczneWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DapperContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DapperContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = @"SELECT *
                        FROM Users";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<User>(sql);
            }
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var sql = @"SELECT * 
                        FROM Users
                        WHERE Id_user = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
            }
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            var sql = @"SELECT * 
                        FROM Users
                        WHERE Login = @Login";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Login = login });
            }
        }

        public async Task<int> AddUserAsync(User entity)
		{
			var sql = @"INSERT INTO Users
                        (Owner, Login, Password, Is_admin)
                        VALUES (@Owner, @Login, @Password, @Is_admin);
                        SELECT CAST(SCOPE_IDENTITY() AS int)";
            using (var connection = _context.CreateConnection())
            {
                var x = await connection.QuerySingleAsync<int>(sql, entity);
                return x;
            }
		}

        public async Task<bool> UpdateAsync(User entity)
        {
            var sql = @"UPDATE Users SET
                        Owner = @Owner, Password = @Password, Is_admin = @Is_admin
                        WHERE Id_user = @Id_user";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var sql = @"DELETE FROM Users WHERE Id_user = @Id";
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows > 0;
            }
        }
    }
}

