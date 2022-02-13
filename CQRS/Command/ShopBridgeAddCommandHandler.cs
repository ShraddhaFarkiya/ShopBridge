using MediatR;
using ShopBridge.DataContract;
using ShopBridge.Entities;
using ShopBridge.IRepositories;
using ShopBridge.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.CQRS.Command
{
    public class ShopBridgeAddCommandHandler : IRequestHandler<ShopBridgeAddCommand, SingleResponse<ShopBridgeDataContract>>
    {
        private readonly IShopBridgeRepository _shopBridgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopBridgeAddCommandHandler(IShopBridgeRepository shopBridgeRepository, IUnitOfWork unitOfWork)
        {
            _shopBridgeRepository = shopBridgeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SingleResponse<ShopBridgeDataContract>> Handle(ShopBridgeAddCommand request, CancellationToken cancellationToken)
        {
            var output = new SingleResponse<ShopBridgeDataContract>();
            Guid newId = Guid.NewGuid();

            var newRecord = new ShopBridgeEntity
            {
                ID  = newId,
                Name = request._inputData.Name,
                Description = request._inputData.Description,
                Price= request._inputData.Price
            };
            try
            {
                await _shopBridgeRepository.AddAsync(newRecord);
                await _unitOfWork.CompleteAsync();
                output.Succeeded = true;
                output.Model = await _shopBridgeRepository.GetShopBridgeDataByID(newId);
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
