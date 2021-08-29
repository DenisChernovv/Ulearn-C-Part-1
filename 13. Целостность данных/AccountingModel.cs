using System;

namespace HotelAccounting
{
    class AccountingModel : ModelBase
    {
        private double price = 0;
        public double Price {
            get { return price; } 
            set { 
                if (value < 0) throw new ArgumentException();
                price = value;
                Notify(nameof(Price));
                CalculationTotal();
            } 
        }

        private int nightsCount = 1;
        public int NightsCount {
            get { return nightsCount; }
            set { 
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
                Notify(nameof(NightsCount));
                CalculationTotal();
            } 
        }

        private double discount = 0;
        public double Discount {
            get { return discount; }
            set {
                if (value > 100) throw new ArgumentException();
                discount = value;
				Notify(nameof(Discount));
                if (discount != ((-1) * Total / (Price * NightsCount) + 1) * 100)
                    CalculationTotal();
            } 
        }

        private double total = 0;
        public double Total {
            get { return total; }
            set {
                if (value < 0) throw new ArgumentException();
                total = value;
				Notify(nameof(Total));
                if (total != Price * NightsCount * (1 - Discount / 100))
                {
                    Discount = ((-1) * Total / (Price * NightsCount) + 1) * 100;
                }
            } 
        }

        private void CalculationTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }
    }
}
