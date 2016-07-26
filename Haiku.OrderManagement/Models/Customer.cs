namespace Models
{
    using System;

    public class Customer
    {
        private const uint      MINIMUM_MONTHLY_QUANTITY = 3000;

        private readonly double contractAllowancePercent;
        private readonly uint   monthlyBasicQuantity;
        private readonly Contract  currentProperty;

        public Customer(
            uint    monthlyOrder,
            double  hraPercent,
            Contract   currentProperty)
        {
            if (currentProperty == null)
            {
                throw new ArgumentNullException("currentProperty");
            }

            if (hraPercent <= 0 || 100 <= hraPercent)
            {
                throw new ArgumentException("hraPercent", "hraPercent should between between 0 and 100.");
            }

            if (monthlyOrder <= MINIMUM_MONTHLY_QUANTITY)
            {
                throw new ArgumentException("monthlyQuantity", "monthlyQuantity is below minimum.");
            }

            this.monthlyBasicQuantity        = monthlyOrder;
            this.contractAllowancePercent = hraPercent;
            this.currentProperty           = currentProperty;
        }

        public void Initialize()
        {
            this.AnnualBasicOrder        = 12 * this.monthlyBasicQuantity;
            this.AnnualOrderDiscountAllowance = (uint)(this.contractAllowancePercent * this.AnnualBasicOrder / 100);
        }

        public uint AnnualOrderDiscountAllowance
        {
            get;
            private set;
        }

        public uint AnnualBasicOrder {
            get;
            private set;
        }

        public Contract Property {
            get
            {
                return this.currentProperty;
            }
        }
    }
}
