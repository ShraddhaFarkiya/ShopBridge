using MediatR;
using ShopBridge.DataContract;
using ShopBridge.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.CQRS.Query
{
    public class GetShopBridgeQuery : IRequest<ListResponse<ShopBridgeDataContract>>
    {
    }
}
