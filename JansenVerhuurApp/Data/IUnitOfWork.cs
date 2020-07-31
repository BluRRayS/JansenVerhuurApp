using System;
using System.Data;
using Data.Repositories.Interfaces;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        IUserRepository UserRepository { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}