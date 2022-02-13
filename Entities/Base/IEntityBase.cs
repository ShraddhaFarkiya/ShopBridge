namespace ShopBridge.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId ID { get; }
    }
}
