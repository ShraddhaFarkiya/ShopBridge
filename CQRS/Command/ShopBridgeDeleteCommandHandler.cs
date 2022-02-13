using MediatR;
using ShopBridge.DataContract;
using ShopBridge.IRepositories;
using ShopBridge.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeDeleteCommandHandler : IRequestHandler<ShopBridgeDeleteCommand, SingleResponse<ShopBridgeDataContract>>
    {
        private readonly IShopBridgeRepository _shopBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopBridgeDeleteCommandHandler(IShopBridgeRepository shopBridgeRepository, IUnitOfWork unitOfWork)
        {
            _shopBridgeRepository = shopBridgeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SingleResponse<ShopBridgeDataContract>> Handle(ShopBridgeDeleteCommand request, CancellationToken cancellationToken)
        {
            var output = new SingleResponse<ShopBridgeDataContract>();
            try
            {
                var entityData = await _shopBridgeRepository.GetByIdAsync(request.rowID);
                await _shopBridgeRepository.DeleteAsync(entityData);
                output.Succeeded = true;
            }
            catch (Exception ex)
            {
                output.DidError = true;
                output.error = ex.Message;
                output.ErrorMessage = "Something went Wrong!! Please Try again after Sometime!!";
            }
            return output;
        }
    }
}
