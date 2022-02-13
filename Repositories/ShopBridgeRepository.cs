using ShopBridge.DataContract;
using ShopBridge.Entities;
using ShopBridge.IRepositories;
using ShopBridge.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ShopBridge.Repositories
{
    public class ShopBridgeRepository : Repository<ShopBridgeEntity>, IShopBridgeRepository
    {
        private readonly ShopBridgeDbContext _DbContext;
        public ShopBridgeRepository(ShopBridgeDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<IEnumerable<ShopBridgeDataContract>> GetAll()
        {
            try
            {
                var result = await (from shopBridge in _DbContext.ShopBridge
                                    select new ShopBridgeDataContract
                                    {
                                        Id = shopBridge.ID,
                                        Name = shopBridge.Name,
                                        Description = shopBridge.Description,
                                        Price = shopBridge.Price
                                    }).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShopBridgeDataContract> GetShopBridgeDataByID(Guid id)
        {
            try
            {
                var result = await(from shopBridge in _DbContext.ShopBridge
                                   where shopBridge.ID == id
                                   select new ShopBridgeDataContract
                                   {
                                       Id = shopBridge.ID,
                                       Name = shopBridge.Name,
                                       Description = shopBridge.Description,
                                       Price = shopBridge.Price
                                   }).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
