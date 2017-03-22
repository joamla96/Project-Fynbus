using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Core.UnitTests {

	[TestClass]
	public class OffersTest {
		RepositoryOffers RepoOffers;
										// SeqNr, Name, Company, Email, CarType 2, 3, 5, 6, 7
		static Contractor _TestContractor1 = new Contractor(163460, "Navn A", "Firma A", "Apple@Email.com", new int[] {0,0,2,0,0});
		static Contractor _TestContractor2 = new Contractor();
		static Contractor _TestContractor3 = new Contractor();

										// GarantiVognNr, Start, Type, Hours: Normal, Weekend, Holidays
		static Route _TestRoute1 = new Route(2502, "OUH", 2, 9.5, 10.5, 9.5, 10.5, 9.5, 10.5);
		static Route _TestRoute2 = new Route(2503, "OUH", 2, 9.5, 10.5, 0, 0, 0 , 0);
		static Route _TestRoute3 = new Route(2504, "OUH", 2, 9.5, 10.5, 0, 0, 9.5, 10.5);
		static Route _TestRoute4 = new Route(2505, "OUH", 2, 9.5, 10.5, 0,0,0,0);
		static Route _TestRoute5 = new Route(2506, "Ørbækvej", 2, 9.5, 10.5, 0, 0, 0, 0);

										// SeqNr, GarantiVognNr, Price/Hr, Contractor, RoutePrio, ContractorPrio
		static Offer _TestOffer1 = new Offer(160867, 2502, 284, _TestContractor1, 0, 0);
		static Offer _TestOffer2 = new Offer(163900, 2502, 300, _TestContractor1, 0, 0);
		static Offer _TestOffer3 = new Offer(161170, 2503, 123, _TestContractor1, 0, 0);
		static Offer _TestOffer4 = new Offer(163905, 2503, 456, _TestContractor2, 0, 0);
		static Offer _TestOffer5 = new Offer(167514, 2503, 789, _TestContractor2, 0, 0);
		static Offer _TestOffer6 = new Offer(169856, 2504, 852, _TestContractor2, 0, 0);
		static Offer _TestOffer7 = new Offer(160456, 2504, 479, _TestContractor3, 1, 0);
		
		[TestInitialize]
		public void PrepareTests() {
			RepoOffers = new RepositoryOffers();
		}

		[TestMethod]
		public void AddOfferFromObject() {
			RepoOffers.AddOffer(_TestOffer1);
			List<Offer> OffersList = RepoOffers.GetAllOffers();
			Assert.IsTrue(OffersList.Contains(_TestOffer1));
		}

		[TestMethod]
		public void AddOfferFromText() {
			RepoOffers.AddOffer(160867, 1, 284, _TestContractor1, 0, 0);
			Offer CompareOffer = RepoOffers.GetOfferByID(160867);
			Assert.AreEqual(_TestOffer1, CompareOffer); // Override the Equals method on Offer Class
		}

		[TestMethod]
		public void DeleteOfferByID() {
			RepoOffers.AddOffer(_TestOffer1);
			RepoOffers.DeleteOffer(160867);
			List<Offer> OffersList = RepoOffers.GetAllOffers();
			Assert.AreEqual(0, OffersList.Count);
		}

		[TestMethod]
		public void DeleteOffersByContractor() {
			RepoOffers.AddOffer(_TestOffer1);
			RepoOffers.AddOffer(_TestOffer2);
			RepoOffers.AddOffer(_TestOffer3);
			RepoOffers.AddOffer(_TestOffer4);
			RepoOffers.AddOffer(_TestOffer5);
			RepoOffers.AddOffer(_TestOffer6);
			RepoOffers.AddOffer(_TestOffer7);

			RepoOffers.DeleteOffer(_TestContractor1);
			List<Offer> OffersList = RepoOffers.GetAllOffers();
			Assert.AreEqual(4, OffersList.Count);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue1() {
			double TotalContractValue = _TestOffer1.GetTotalContractValue(_TestRoute1);
			Assert.AreEqual(TotalContractValue, 284);
		}

		[TestMethod]
		public void OrderOffersGetTotalContractValue2() {
			double TotalContractValue = _TestOffer2.GetTotalContractValue(_TestRoute1);

			Assert.AreEqual(TotalContractValue, 300);
		}

        [TestMethod]
        public void OrderOffersByTotalContractValue()
        {

        }
	}
}
