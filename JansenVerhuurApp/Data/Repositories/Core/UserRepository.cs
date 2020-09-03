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
        private readonly IDbConnection connection;
        private readonly IDbTransaction transaction;

        public UserRepository(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public async Task<UserDto> CreateAsync(UserDto entity)
        {
            var sql = @"
                insert into user (Firstname,Lastname,Role,Email,Password,Salt) VALUES(@First,@Last,@Role,@Email,@Password,@Salt);
                SELECT LAST_INSERT_ID();";
            entity.Id = await connection.QueryFirstOrDefaultAsync<int>(sql,
                new
                {
                    First = entity.Firstname, Last = entity.Lastname, Role = entity.Role, entity.Email, entity.Password,
                    entity.Salt
                }, transaction);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM user WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new {Id = id}, transaction);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            return await connection.QueryFirstOrDefaultAsync<UserDto>("SELECT * FROM user WHERE Id =@Id", new {Id = id},
                transaction);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await connection.QueryAsync<UserDto>("SELECT * FROM user", transaction);
        }

        public async Task<UserDto> UpdateAsync(UserDto entity)
        {
            var sql =
                "UPDATE user SET Firstname = @Firstname,Lastname = @Lastname, Role= @Role, Email = @Email WHERE Id = @Id";
            await connection.ExecuteAsync(sql,
                new {entity.Firstname, entity.Lastname, entity.Role, entity.Email, entity.Id}, transaction);
            return entity;
        }
    }
}