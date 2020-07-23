using Dapper;
using Data.Dto;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateAsync (UserDto entity)
        {
            var sql = "insert into user (Firstname,Lastname,Role,Email,Password,Salt) VALUES(@First,@Last,@Role,@Email,@Password,@Salt)";
            await connection.ExecuteAsync(sql, new { First = entity.Firstname, Last = entity.Lastname, Role = (int)entity.Role, entity.Email, entity.Password,  entity.Salt },transaction);
        }

        public async Task DeleteAsync (int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            return await connection.QueryFirstOrDefaultAsync<UserDto>("SELECT * FROM user WHERE Id =@Id", new { Id = id }, transaction);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await connection.QueryAsync<UserDto>("SELECT * FROM user", transaction);
        }

        public async Task UpdateAsync (UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
