using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.UnitTests
{
    [TestClass]
	public class RouteTests
	{
        RepositoryRoutes _repoRoutes;
        // SeqNr, Name, Company, Email, CarType 2, 3, 5, 6, 7
        static Contractor _testContractor1 = new Contractor(163460, "Navn A", "Firma A", "Apple@Email.com", new int[] { 0, 0, 2, 0, 0 });
        static Contractor _testContractor2 = new Contractor(163478, "Navn B", "Firma B", "Banana@Email.com", new int[] { 0, 0, 2, 0, 0 });
        static Contractor _testContractor3 = new Contractor();

        // GarantiVognNr, Start, Type, Hours: Normal, Weekend, Holidays
        static Route _testRoute1 = new Route(2502, "OUH", 2, 9.5, 10.5, 9.5, 10.5, 9.5, 10.5);
        static Route _testRoute2 = new Route(2503, "OUH", 2, 9.5, 10.5, 0, 0, 0, 0);
        static Route _testRoute3 = new Route(2504, "OUH", 2, 9.5, 10.5, 0, 0, 9.5, 10.5);
        static Route _testRoute4 = new Route(2505, "OUH", 2, 9.5, 10.5, 0, 0, 0, 0);
        static Route _testRoute5 = new Route(2506, "Ørbækvej", 2, 9.5, 10.5, 0, 0, 0, 0);
        static Route _testRoute6 = new Route(2507, "Ørbækvej", 3, 9.5, 10.5, 0, 0, 0, 0);

        // SeqNr, GarantiVognNr, Price/Hr, Contractor, RoutePrio, ContractorPrio
        static Offer _testOffer1 = new Offer(160867, _testRoute1, 284, _testContractor1, 0, 0);
        static Offer _testOffer2 = new Offer(163900, _testRoute1, 300, _testContractor1, 0, 0);
        static Offer _testOffer3 = new Offer(161170, _testRoute2, 123, _testContractor1, 0, 0);
        static Offer _testOffer4 = new Offer(163905, _testRoute2, 456, _testContractor2, 0, 0);
        static Offer _testOffer5 = new Offer(167514, _testRoute2, 789, _testContractor2, 0, 0);
        static Offer _testOffer6 = new Offer(169856, _testRoute3, 852, _testContractor2, 0, 0);
        static Offer _testOffer7 = new Offer(160456, _testRoute3, 479, _testContractor3, 1, 0);

        [TestInitialize]
        public void PrepareTests()
        {
            _repoRoutes = new RepositoryRoutes();
        }

        [TestMethod]
        public void AddRouteFromObject()
        {
            _repoRoutes.AddRoute(_testRoute1);
            List<Route> routesList = _repoRoutes.GetAllRoutes();
            Assert.IsTrue(routesList.Contains(_testRoute1));
        }

        [TestMethod]
        public void AddRouteFromText()
        {
            _repoRoutes.AddRoute(2502, "OUH", 2, 9.5, 10.5, 9.5, 10.5, 9.5, 10.5);
            List<Route> routesList = _repoRoutes.GetAllRoutes();
            Assert.IsTrue(routesList.Contains(new Route(2502, "OUH", 2, 9.5, 10.5, 9.5, 10.5, 9.5, 10.5)));
        }

        [TestMethod]
        public void GetRouteByID()
        {
            _repoRoutes.AddRoute(_testRoute1);
            _repoRoutes.AddRoute(_testRoute2);
            _repoRoutes.AddRoute(_testRoute3);

            Route compareRoute = _repoRoutes.GetRouteByID(_testRoute1.CarNr);
            Assert.AreEqual(_testRoute1, compareRoute); // Override the Equals method on Offer Class
        }

        [TestMethod]
        public void DeleteRouteByID()
        {
            _repoRoutes.AddRoute(_testRoute1);
            _repoRoutes.DeleteRoute(_testRoute1.CarNr);
            List<Route> routesList = _repoRoutes.GetAllRoutes();
            Assert.AreEqual(0, routesList.Count);
        }

        //[TestMethod]
        //public void GetRoutesFromRouteRepoByCarType()
        //{
        //    _repoRoutes.AddRoute(_testRoute1);
        //    _repoRoutes.AddRoute(_testRoute2);
        //    _repoRoutes.AddRoute(_testRoute3);
        //    _repoRoutes.AddRoute(_testRoute4);
        //    _repoRoutes.AddRoute(_testRoute5);
        //    _repoRoutes.AddRoute(_testRoute6);

        //    List<Route> routes = _repoRoutes.GetRoutesByCarType(_testRoute1.CarType);

        //    Assert.IsTrue(routes.Contains(_testRoute1));
        //    Assert.IsTrue(routes.Contains(_testRoute2));
        //    Assert.IsTrue(routes.Contains(_testRoute3));
        //    Assert.IsTrue(routes.Contains(_testRoute4));
        //    Assert.IsTrue(routes.Contains(_testRoute5));
        //    Assert.IsFalse(routes.Contains(_testRoute6));
        //}
    }
}
