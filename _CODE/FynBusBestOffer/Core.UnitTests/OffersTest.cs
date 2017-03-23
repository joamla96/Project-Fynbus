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
			List<Offer> offersList = _repoOffers.GetAllOffers();
			Assert.IsTrue(offersList.Contains(_testOffer1));
		}

		[TestMethod]
		public void AddOfferFromText() {
			_repoOffers.AddOffer(160867, _testRoute1, 284, _testContractor1, 0, 0);
			List<Offer> offersList = _repoOffers.GetAllOffers();
			Assert.IsTrue(offersList.Contains(new Offer(160867, _testRoute1, 284, _testContractor1, 0, 0)));
		}

		[TestMethod]
		public void GetOfferByID() {
			_repoOffers.AddOffer(_testOffer1);
			_repoOffers.AddOffer(_testOffer2);
			_repoOffers.AddOffer(_testOffer3);

			Offer compareOffer = _repoOffers.GetOfferByID(_testOffer1.OfferSeqNr);
			Assert.AreEqual(_testOffer1, compareOffer); // Override the Equals method on Offer Class
		}


		[TestMethod]
		public void DeleteOfferByID() {
			_repoOffers.AddOffer(_testOffer1);
			_repoOffers.DeleteOffer(_testOffer1.OfferSeqNr);
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
			List<Offer> offersList = _repoOffers.GetAllOffers();
			Assert.AreEqual(4, offersList.Count);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue1() {
			double totalContractValue = _testOffer1.TotalContractValue; // Total Contract Value should be a property
			Assert.AreEqual(totalContractValue, 284);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue2() {
			double totalContractValue = _testOffer2.TotalContractValue;
			Assert.AreEqual(totalContractValue, 300);
		}

        //[TestMethod]
        //public void GetRightOffersFromOfferRepo()
        //{
        //    _repoOffers.AddOffer(_testOffer1);
        //    _repoOffers.AddOffer(_testOffer2);
        //    _repoOffers.AddOffer(_testOffer3);
        //    _repoOffers.AddOffer(_testOffer4);
        //    _repoOffers.AddOffer(_testOffer5);
        //    _repoOffers.AddOffer(_testOffer6);
        //    _repoOffers.AddOffer(_testOffer7);

        //    List<Offer> offers = _repoOffers.getOffersByCarNr(_testRoute1.CarNr);

        //    Assert.IsTrue(offers.Contains(_testOffer1));
        //    Assert.IsTrue(offers.Contains(_testOffer2));
        //    Assert.IsFalse(offers.Contains(_testOffer3));
        //    Assert.IsFalse(offers.Contains(_testOffer4));
        //    Assert.IsFalse(offers.Contains(_testOffer5));
        //    Assert.IsFalse(offers.Contains(_testOffer6));
        //    Assert.IsFalse(offers.Contains(_testOffer7));
        //}
    }
}
