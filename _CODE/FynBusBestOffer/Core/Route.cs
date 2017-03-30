using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
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

		public Offer OfferWon { get; set; }

		public Route(int carnr, string homebase, int cartype, double warrantyweekdayshours, double availabilityweekdayshours, double warrantyweekendhours, double availabilityweekendhours, double warrantyholidayhours, double availabilityholidayhours) {
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

		public override bool Equals(object obj) {
			bool result = false;
			Route route = (Route)obj;
			if (this.CarNr == route.CarNr) {
				result = true;
			}
			return result;
		}

		public Offer GetBestOffer() {
			RepositoryOffers offers = RepositoryOffers.Instance;
			List<Offer> listOfOffersForRoute = offers.GetOffers(this);
			int index = 0;
			listOfOffersForRoute.Sort();
			Offer bestOffer = listOfOffersForRoute[index];


			bool foundBestOffer = false;
			do {
				int startCarAmount = bestOffer.Contractor.GetCarsMaxOfType(this.CarType);
				int wonCarAmount = bestOffer.Contractor.GetCarsWonOfType(this.CarType);

				if (startCarAmount < wonCarAmount) {
					// This... should NEVER EVER EVER happen... j.i.c.
					throw new Exception("Exception: A contractor has won more cars than they can offer.");
				} else if (wonCarAmount < startCarAmount) {
					foundBestOffer = true;
					bestOffer.Contractor.WonCarOfType(this.CarType);
				} else if (startCarAmount == wonCarAmount) {
					bestOffer = listOfOffersForRoute[index + 1];
				}
			} while (foundBestOffer == false);

			this.OfferWon = bestOffer;

			return bestOffer;
		}
	}
}
