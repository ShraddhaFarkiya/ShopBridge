using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        Task CompleteAsync(CancellationToken token);
    }
}
