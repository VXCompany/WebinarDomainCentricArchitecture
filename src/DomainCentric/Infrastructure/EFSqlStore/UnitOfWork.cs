using System;
using Domain.Repositories;

namespace Infrastructure.EFSqlStore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WinkelDbContext _winkelDbContext;

        public UnitOfWork(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new ArgumentNullException(nameof(winkelDbContext));
        }

        public void Commit()
        {
            _winkelDbContext.SaveChanges();
        }
    }
}
