using MediatR;
using ShopBridge.DataContract;
using ShopBridge.IRepositories;
using ShopBridge.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.CQRS.Query
{
    public class GetShopBridgeQueryHandler : IRequestHandler<GetShopBridgeQuery, ListResponse<ShopBridgeDataContract>>
    {
        private readonly IShopBridgeRepository _shopBridgeRepository;
        public GetShopBridgeQueryHandler(IShopBridgeRepository lockRepository)
        {
            _shopBridgeRepository = lockRepository;
        }

        public async Task<ListResponse<ShopBridgeDataContract>> Handle(GetShopBridgeQuery request, CancellationToken cancellationToken)
        {
            var response = new ListResponse<ShopBridgeDataContract>();
            try
            {
                var result = await _shopBridgeRepository.GetAll();
                response.Succeeded = true;
                response.Model = result;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
