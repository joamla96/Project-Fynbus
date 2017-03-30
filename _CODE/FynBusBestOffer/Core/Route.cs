using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Route
    {
        public int CarNr;
        public string HomeBase;
        public int CarType;
        public double WarrantyWeekdaysHours;
        public double AvailabilityWeekdaysHours;
        public double WarrantyWeekendHours;
        public double AvailabilityWeekendHours;
        public double WarrantyHolidayHours;
        public double AvailabilityHolidayHours;

        public Contractor Contractor { get; set; }

        public Route(int carnr, string homebase, int cartype, double warrantyweekdayshours, double availabilityweekdayshours, double warrantyweekendhours, double availabilityweekendhours, double warrantyholidayhours, double availabilityholidayhours)
        {
            this.CarNr = carnr;
            this.HomeBase = homebase;
            this.CarType = cartype;
            this.WarrantyWeekdaysHours = warrantyweekdayshours;
            this.AvailabilityWeekdaysHours = availabilityweekdayshours;
            this.WarrantyWeekendHours = warrantyweekendhours;
            this.AvailabilityWeekendHours = availabilityweekendhours;
            this.WarrantyHolidayHours = warrantyholidayhours;
            this.AvailabilityHolidayHours = availabilityholidayhours;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            Route route = (Route)obj;
            if (this.CarNr == route.CarNr)
            {
                result = true;
            }
            return result;
        }

        public Offer GetBestOffer()
        {
            RepositoryOffers offers = RepositoryOffers.Instance;
            List<Offer> listOfOffersForRoute = offers.GetOffers(this);
            int index = 0;
            listOfOffersForRoute.Sort();
            Offer bestOffer = listOfOffersForRoute[index];
            

            bool foundBestOffer = false;
            do
            {
                int arrIndex = GetCarTypeForArray(this.CarType);
                int startCarAmount = bestOffer.Contractor.CarTypeArray[arrIndex];
                int wonCarAmount = bestOffer.Contractor.CarTypeWonArray[arrIndex];

                if (startCarAmount < wonCarAmount)
                {
                    throw new Exception("Code is BROKEEEEEEEEEEEEEEEEEN!!!! Help! HELP! HEEELP!!!!!");
                }
                else if (wonCarAmount < startCarAmount)
                {
                    foundBestOffer = true;
                    wonCarAmount = wonCarAmount + 1;
                }
                else if (startCarAmount == wonCarAmount)
                {
                    bestOffer = listOfOffersForRoute[index + 1];
                }
            }
            while (foundBestOffer == false);

            return bestOffer;
               

        }

        public int GetCarTypeForArray(int cartype)
        {
            int index;
            switch (cartype)
            {
                case 2:
                    index = 0;
                    break;
                case 3:
                    index = 1;
                    break;
                case 5:
                    index = 2;
                    break;
                case 6:
                    index = 3;
                    break;
                case 7:
                    index = 4;
                    break;
                default:
                    throw new IndexOutOfRangeException();
                        
            }
            return index;
        }
    }
}
