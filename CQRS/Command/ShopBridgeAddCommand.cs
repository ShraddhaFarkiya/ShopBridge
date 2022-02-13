using MediatR;
using ShopBridge.DataContract;
using ShopBridge.Responses;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeAddCommand : IRequest<SingleResponse<ShopBridgeDataContract>>
    {
        public ShopBridgeDataContract _inputData;
        public ShopBridgeAddCommand(ShopBridgeDataContract inputData)
        {
            _inputData = inputData;
        }
    }
}
