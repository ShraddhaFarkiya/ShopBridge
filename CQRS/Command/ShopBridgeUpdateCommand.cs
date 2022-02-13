using MediatR;
using ShopBridge.DataContract;
using ShopBridge.Responses;
using System;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeUpdateCommand :IRequest<SingleResponse<ShopBridgeDataContract>>
    {
        public ShopBridgeDataContract _inputData;
        public Guid _rowID;
    }
}
