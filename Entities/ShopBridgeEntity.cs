using ShopBridge.Entities.Base;
using System;

namespace ShopBridge.Entities
{
    public class ShopBridgeEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
