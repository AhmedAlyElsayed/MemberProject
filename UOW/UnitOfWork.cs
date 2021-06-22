using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MemberProject.UOW
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _dbContext;
        private bool disposed = false;

        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async ValueTask<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
