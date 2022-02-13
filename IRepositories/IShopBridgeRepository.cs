using ShopBridge.RepositoryInterface.Base;
using ShopBridge.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.DataContract;
using System;

namespace ShopBridge.IRepositories
{
    public interface IShopBridgeRepository : IRepository<ShopBridgeEntity>
    {
        public Task<IEnumerable<ShopBridgeDataContract>> GetAll();
        public Task<ShopBridgeDataContract> GetShopBridgeDataByID(Guid id);
    }
}
