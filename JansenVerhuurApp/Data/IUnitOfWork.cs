using Data.Repositories.Interfaces;
using System;
using System.Data;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();

        IUserRepository UserRepository { get; }
    }
}
