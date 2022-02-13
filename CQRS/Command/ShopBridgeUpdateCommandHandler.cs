using MediatR;
using ShopBridge.DataContract;
using ShopBridge.IRepositories;
using ShopBridge.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeUpdateCommandHandler : IRequestHandler<ShopBridgeUpdateCommand, SingleResponse<ShopBridgeDataContract>>
    {
        private readonly IShopBridgeRepository _shopBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopBridgeUpdateCommandHandler(IShopBridgeRepository shopBridgeRepository, IUnitOfWork unitOfWork)
        {
            _shopBridgeRepository = shopBridgeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SingleResponse<ShopBridgeDataContract>> Handle(ShopBridgeUpdateCommand request, CancellationToken cancellationToken)
        {
            var output = new SingleResponse<ShopBridgeDataContract>();

            var entityData = await _shopBridgeRepository.GetByIdAsync(request._rowID);
            entityData.Name = request._inputData.Name;
            entityData.Description = request._inputData.Description;
            entityData.Price = request._inputData.Price;
            try
            {
                await _shopBridgeRepository.Update(entityData);
                await _unitOfWork.CompleteAsync();
                output.Succeeded = true;
                output.Model = await _shopBridgeRepository.GetShopBridgeDataByID(entityData.ID);
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
