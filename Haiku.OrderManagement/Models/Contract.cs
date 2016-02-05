namespace Models
{
    using System;
    // a comment

    public class Contract
    {
        private uint monthlyQuantity;

        public bool IsCreditChecked {
            get;
            set;
        }

        public Location Location {
            get;
            set;
        }

        public uint MonthlyQuantity
        {
            get
            {
                return this.monthlyQuantity;
            }

            set
            {
                if (value == 0)
                {
                    throw new InvalidOrderException();
                }

                this.monthlyQuantity = value;
            }
        }
    }
}