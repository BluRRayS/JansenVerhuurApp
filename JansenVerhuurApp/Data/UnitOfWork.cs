using Data.Repositories.Core;
using Data.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DatabaseOptions databaseOptions)
        {
            _connection = new MySqlConnection(databaseOptions.GetConnectionString());
        }

        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public IDbConnection Connection { get { return _connection; } }

        public IDbTransaction Transaction { get { return _transaction; } }


        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public IUserRepository UserRepository
        {
            get => new UserRepository(_connection, _transaction);
        }
    }
}
