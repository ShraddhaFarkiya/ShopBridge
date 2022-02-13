using ShopBridge.Entities;
using ShopBridge.IRepositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopBridgeDbContext _context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(ShopBridgeDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            try
            {

                await _context.SaveChangesAsync();
            }
            catch(Exception c)
            {
                throw new Exception(c.Message);
            }
        }

        public async Task CompleteAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
