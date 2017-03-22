using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Route
    {
        private int CarNr;
        private string HomeBase;
        private int CarType;
        private double WarrantyWeekdaysHours;
        private double AvailabilityWeekdaysHours;
        private double WarrantyWeekendHours;
        private double AvailabilityWeekendHours;
        private double WarrantyHolidayHours;
        private double AvailabilityHolidayHours;

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
    }
}
