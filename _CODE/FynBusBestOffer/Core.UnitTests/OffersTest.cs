using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Core.UnitTests {

	[TestClass]
	public class OffersTest
	{
		RepositoryOffers _repoOffers;
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

		// SeqNr, GarantiVognNr, Price/Hr, Contractor, RoutePrio, ContractorPrio
		static Offer _testOffer1 = new Offer(160867, _testRoute1, 284, _testContractor1, 0, 0);
		static Offer _testOffer2 = new Offer(163900, _testRoute1, 300, _testContractor1, 0, 0);
		static Offer _testOffer3 = new Offer(161170, _testRoute2, 123, _testContractor1, 0, 0);
		static Offer _testOffer4 = new Offer(163905, _testRoute2, 456, _testContractor2, 0, 0);
		static Offer _testOffer5 = new Offer(167514, _testRoute2, 789, _testContractor2, 0, 0);
		static Offer _testOffer6 = new Offer(169856, _testRoute3, 852, _testContractor2, 0, 0);
		static Offer _testOffer7 = new Offer(160456, _testRoute3, 479, _testContractor3, 1, 0);

		[TestInitialize]
		public void PrepareTests() {
			_repoOffers = new RepositoryOffers();
		}

		[TestMethod]
		public void AddOfferFromObject() {
			_repoOffers.AddOffer(_testOffer1);
			List<Offer> OffersList = _repoOffers.GetAllOffers();
			Assert.IsTrue(OffersList.Contains(_testOffer1));
		}

		[TestMethod]
		public void AddOfferFromText() {
			_repoOffers.AddOffer(160867, 1, 284, _testContractor1, 0, 0);
			Offer CompareOffer = _repoOffers.GetOfferByID(160867);
			Assert.AreEqual(_testOffer1, CompareOffer); // Override the Equals method on Offer Class
		}

		[TestMethod]
		public void DeleteOfferByID() {
			_repoOffers.AddOffer(_testOffer1);
			_repoOffers.DeleteOffer(160867);
			List<Offer> OffersList = _repoOffers.GetAllOffers();
			Assert.AreEqual(0, OffersList.Count);
		}

		[TestMethod]
		public void DeleteOffersByContractor() {
			_repoOffers.AddOffer(_testOffer1);
			_repoOffers.AddOffer(_testOffer2);
			_repoOffers.AddOffer(_testOffer3);
			_repoOffers.AddOffer(_testOffer4);
			_repoOffers.AddOffer(_testOffer5);
			_repoOffers.AddOffer(_testOffer6);
			_repoOffers.AddOffer(_testOffer7);

			_repoOffers.DeleteOffer(_testContractor1);
			List<Offer> OffersList = _repoOffers.GetAllOffers();
			Assert.AreEqual(4, OffersList.Count);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue1() {
			double TotalContractValue = _testOffer1.TotalContractValue; // Total Contract Value should be a property
			Assert.AreEqual(TotalContractValue, 284);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue2() {
			double TotalContractValue = _testOffer2.TotalContractValue;
			Assert.AreEqual(TotalContractValue, 300);
		}

		[TestMethod]
		public void GetRightOffersFromOfferRepo() {
			_repoOffers.Add(_testOffer1);
			_repoOffers.Add(_testOffer2);
			_repoOffers.Add(_testOffer3);
			_repoOffers.Add(_testOffer4);
			_repoOffers.Add(_testOffer5);
			_repoOffers.Add(_testOffer6);
			_repoOffers.Add(_testOffer7);

			List<Offer> Offers = _repoOffers.getOffersByCarNr(_testRoute1.CarNr);

			Assert.IsTrue(Offers.Contains(_testOffer1));
			Assert.IsTrue(Offers.Contains(_testOffer2));
			Assert.IsFalse(Offers.Contains(_testOffer3));
			Assert.IsFalse(Offers.Contains(_testOffer4));
			Assert.IsFalse(Offers.Contains(_testOffer5));
			Assert.IsFalse(Offers.Contains(_testOffer6));
			Assert.IsFalse(Offers.Contains(_testOffer7));
		}
	}
}
