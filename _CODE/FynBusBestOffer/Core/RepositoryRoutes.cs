using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class RepositoryRoutes
    {
        List<Route> _route = new List<Route>();

        private static RepositoryRoutes _instance = new RepositoryRoutes();
        public static RepositoryRoutes Instance { get { return _instance; } }

        public void AddRoute(Route route)
        {
            _route.Add(route);
        }

        public List<Route> GetAllRoutes()
        {
            return _route;
        }

        public void AddRoute(int carnr, string homebase, int cartype, double warrantyweekdayshours, double availabilityweekdayshours, double warrantyweekendhours, double availabilityweekendhours, double warrantyholidayhours, double availabilityholidayhours)
        {
            Route route = new Route(carnr, homebase, cartype, warrantyweekdayshours, availabilityweekdayshours, warrantyweekendhours, availabilityweekendhours, warrantyholidayhours, availabilityholidayhours);
            _route.Add(route);
        }

        public Route GetRouteByID(int carnr)
        {
            Route result = null;
            foreach (Route element in _route)
            {
                if (element.CarNr == carnr)
                {
                    result = element;
                }
            }
            return result;
        }

        public void DeleteRoute(int carnr)
        {
            Route toDelete = this.GetRouteByID(carnr);
            _route.Remove(toDelete);
        }

        public void Clear()
        {
            _route.Clear();
        }

       
    }
}
