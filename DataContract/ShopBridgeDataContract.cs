using System;

namespace ShopBridge.DataContract
{
    public class ShopBridgeDataContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
