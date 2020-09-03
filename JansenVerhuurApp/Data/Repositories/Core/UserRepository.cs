using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Data.Dto;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public UserRepository(IDbConnection connection, IDbTransaction transaction)
        {
            this._connection = connection;
            this._transaction = transaction;
        }

        public async Task<UserDto> CreateAsync(UserDto entity)
        {
            const string sql = @"
                insert into user (Firstname,Lastname,Role,Email,Password,Salt) VALUES(@First,@Last,@Role,@Email,@Password,@Salt);
                SELECT LAST_INSERT_ID();";
            entity.Id = await _connection.QueryFirstOrDefaultAsync<int>(sql,
                new
                {
                    First = entity.Firstname, Last = entity.Lastname, Role = entity.Role, entity.Email, entity.Password,
                    entity.Salt
                }, _transaction);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM user WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new {Id = id}, _transaction);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<UserDto>("SELECT * FROM user WHERE Id =@Id", new {Id = id},
                _transaction);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _connection.QueryAsync<UserDto>("SELECT * FROM user", _transaction);
        }

        public async Task<UserDto> UpdateAsync(UserDto entity)
        {
            const string sql = "UPDATE user SET Firstname = @Firstname,Lastname = @Lastname, Role= @Role, Email = @Email WHERE Id = @Id";
            await _connection.ExecuteAsync(sql,
                new {entity.Firstname, entity.Lastname, entity.Role, entity.Email, entity.Id}, _transaction);
            return entity;
        }

        public async Task<UserDto> CredentialsMatchAsync(string email, string password)
        {
            const string sql = "SELECT * FROM user WHERE Email=@Email AND Password=@Password";
            return await _connection.QueryFirstOrDefaultAsync<UserDto>(sql,new {Email = email, Password = password}, _transaction);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            const string sql = "SELECT * FROM user WHERE Email = @Email";
            return await _connection.QueryFirstOrDefaultAsync<UserDto>(sql,new {Email = email}, _transaction);
        }
    }
}