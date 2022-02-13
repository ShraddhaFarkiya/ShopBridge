using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Entities
{

    public class ShopBridgeDbContext : DbContext 
    {
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options) : base(options)
        {
        }
        public DbSet<ShopBridgeEntity> ShopBridge { get; set; }
    }
}
