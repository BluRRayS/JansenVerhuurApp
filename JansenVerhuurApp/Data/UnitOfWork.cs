using System.Data;
using Data.Repositories.Core;
using Data.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DatabaseOptions databaseOptions)
        {
            Connection = new MySqlConnection(databaseOptions.GetConnectionString());
        }

        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; private set; }


        public void Begin()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();
            Transaction = null;
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }

        public IUserRepository UserRepository => new UserRepository(Connection, Transaction);
    }
}