using MediatR;
using ShopBridge.DataContract;
using ShopBridge.Responses;
using System;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeDeleteCommand : IRequest<SingleResponse<ShopBridgeDataContract>>
    {
        public Guid rowID;
    }
}
