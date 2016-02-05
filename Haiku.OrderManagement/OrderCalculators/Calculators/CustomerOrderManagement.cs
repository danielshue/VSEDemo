#region Namespaces
using System;
using Models;
#endregion

namespace Contracts
{

    public class CustomerOrderManagement : IOrderManagement
    {

        public uint ReOrder(
            bool        IsExistingContract,
            Location    location,
            uint        TotalOrderValue,
            uint        MonthlyOrders,
            uint        CustomerDiscount)
        {
            var orderExemption = default(uint);

            if (IsExistingContract == false)
            {
                return orderExemption;
            }

            // Calculate location based delivery costs
            var locationAllowance = default(uint);

            switch (location)
            {
                case Location.Metro:
                    locationAllowance = Convert.ToUInt32(Math.Ceiling(0.1 * TotalOrderValue));
                    break;
                case Location.NonMetro:
                    locationAllowance = Convert.ToUInt32(Math.Ceiling(0.2 * TotalOrderValue));
                    break;
                default:
                    throw new InvalidLocationException();
            }

            // Calculate discounts based on orders per month
            var discount = 12 * MonthlyOrders - Convert.ToUInt32(Math.Ceiling(0.1 * TotalOrderValue));

            // Calculate the minimum
            orderExemption = discount;
            if (locationAllowance < discount)
            {
                orderExemption = locationAllowance;
            }

            if (CustomerDiscount < orderExemption)
            {
                orderExemption = CustomerDiscount;
            }

            return orderExemption;
        }

    }

}
