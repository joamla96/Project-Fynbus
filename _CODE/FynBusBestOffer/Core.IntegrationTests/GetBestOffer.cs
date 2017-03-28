using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Core.IntegrationTests
{
	[TestClass]
	public class GetBestOffer
	{
		RepositoryOffers _repoOffers;
		RepositoryRoutes _repoRoutes;
		RepositoryContractors _repoContractors;

		// SeqNr, Name, Company, Email, CarType 2, 3, 5, 6, 7
		static Contractor _testContractor1 = new Contractor(163460, "Navn A", "Firma A", "Apple@Email.com", new int[] { 3, 0, 0, 0, 0 });
		static Contractor _testContractor2 = new Contractor(163478, "Navn B", "Firma B", "Banana@Email.com", new int[] { 2, 0, 0, 0, 0 });
		static Contractor _testContractor3 = new Contractor(164758, "Navn C", "Firma C", "Canada@Email.com", new int[] { 1, 0, 0, 0, 0 });

		// GarantiVognNr, Start, Type, Hours: Normal, Weekend, Holidays
		static Route _testRoute1 = new Route(2502, "OUH", 2, 9.5, 10.5, 9.5, 10.5, 9.5, 10.5);
		static Route _testRoute2 = new Route(2503, "OUH", 2, 9.5, 10.5, 0, 0, 0, 0);
		static Route _testRoute3 = new Route(2504, "OUH", 2, 9.5, 10.5, 0, 0, 9.5, 10.5);
		static Route _testRoute4 = new Route(2505, "OUH", 2, 9.5, 10.5, 0, 0, 0, 0);
		static Route _testRoute5 = new Route(2506, "Ørbækvej", 2, 9.5, 10.5, 0, 0, 0, 0);

		// SeqNr, Route, Price/Hr, Contractor, RoutePrio, ContractorPrio
		static Offer _testOffer1 = new Offer(160867, _testRoute1, 284, _testContractor3, 0, 0);
		static Offer _testOffer2 = new Offer(163900, _testRoute1, 300, _testContractor2, 0, 0);

		static Offer _testOffer3 = new Offer(161170, _testRoute2, 123, _testContractor3, 0, 0);
		static Offer _testOffer4 = new Offer(163905, _testRoute2, 456, _testContractor2, 0, 0);
		static Offer _testOffer5 = new Offer(167514, _testRoute2, 789, _testContractor1, 0, 0);

		static Offer _testOffer6 = new Offer(169856, _testRoute3, 852, _testContractor1, 0, 0);
		static Offer _testOffer7 = new Offer(160456, _testRoute3, 479, _testContractor2, 1, 0);

		[TestInitialize]
		public void PrepareTests() {
			_repoOffers = RepositoryOffers.Instance; // Singletons
			_repoOffers.Clear();

			_repoRoutes = RepositoryRoutes.Instance;
			_repoRoutes.Clear();

			_repoContractors = RepositoryContractors.Instance;
			_repoContractors.Clear();

			_repoOffers.AddOffer(_testOffer1);
			_repoOffers.AddOffer(_testOffer2);
			_repoOffers.AddOffer(_testOffer3);
			_repoOffers.AddOffer(_testOffer4);
			_repoOffers.AddOffer(_testOffer5);
			_repoOffers.AddOffer(_testOffer6);
			_repoOffers.AddOffer(_testOffer7);

			_repoRoutes.AddRoute(_testRoute1);
			_repoRoutes.AddRoute(_testRoute2);
			_repoRoutes.AddRoute(_testRoute3);
			_repoRoutes.AddRoute(_testRoute4);
			_repoRoutes.AddRoute(_testRoute5);

			_repoContractors.AddContractor(_testContractor1);
			_repoContractors.AddContractor(_testContractor2);
			_repoContractors.AddContractor(_testContractor3);
		}

		[TestMethod]
		public void GetBestOfferByRoutes1() {
			Offer bestOffer = _testRoute1.GetBestOffer();
			Assert.AreEqual(bestOffer, _testOffer1);
		}

		[TestMethod]
		public void GetBestOfferByRoutes2() {
			Offer bestOffer = _testRoute2.GetBestOffer();
			Assert.AreEqual(bestOffer, _testOffer3);
		}

		[TestMethod]
		public void WinningOfferIncreasesCarTypeWonAmount() {
			Offer bestOffer = _testRoute1.GetBestOffer();
			Assert.AreEqual(1, _testContractor3.CarTypeWonArray[0]);
		}

		[TestMethod]
		public void IfContractorOutOfCarsAwardToNext() {
			Offer bestOfferR1 = _testRoute1.GetBestOffer();
			Offer bestOfferR2 = _testRoute2.GetBestOffer();

			Assert.AreEqual(_testRoute1.Contractor, _testContractor3);
			Assert.AreEqual(_testRoute2.Contractor, _testContractor2);
		}
	}
}
