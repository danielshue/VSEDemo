namespace Contracts
{
    using Models;

    public interface IOrderManagement
    {
        uint ReOrder(
            bool IsExistingContract,
            Location location,
            uint TotalOrderValue,
            uint MonthlyOrders,
            uint CustomerDiscount);
    }
}
