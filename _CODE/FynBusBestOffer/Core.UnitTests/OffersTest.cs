using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Core.UnitTests {

	[TestClass]
	public class OffersTest {
		RepositoryOffers RepoOffers;

		static Contractor _TestContractor1 = new Contractor();
		static Contractor _TestContractor2 = new Contractor();
		static Contractor _TestContractor3 = new Contractor();

		static Offer _TestOffer1 = new Offer(160867, 1, 284, _TestContractor1, 0, 0);
		static Offer _TestOffer2 = new Offer(163900, 1, 300, _TestContractor1, 0, 0);
		static Offer _TestOffer3 = new Offer(161170, 10, 123, _TestContractor1, 0, 0);
		static Offer _TestOffer4 = new Offer(163905, 2500, 456, _TestContractor2, 0, 0);
		static Offer _TestOffer5 = new Offer(167514, 42, 789, _TestContractor2, 0, 0);
		static Offer _TestOffer6 = new Offer(169856, 624, 852, _TestContractor2, 0, 0);
		static Offer _TestOffer7 = new Offer(160456, 777, 479, _TestContractor3, 1, 0);
		
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
	}
}
