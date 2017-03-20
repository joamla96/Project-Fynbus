using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Core.UnitTests {

	[TestClass]
	public class OffersTest {
		RepositoryOffers RepoOffers;

		static Contractor _TestContractor = new Contractor();
		static Offer _TestOffer = new Offer(160867, 1, 284, _TestContractor, 0, 0);

		[TestInitialize]
		public void PrepareTests() {
			RepoOffers = new RepositoryOffers();
		}

		[TestMethod]
		public void CreateOfferFromObject() {
			RepoOffers.AddOffer(_TestOffer);
			List<Offer> OffersList = RepoOffers.GetAllOffers();
			Assert.IsTrue(OffersList.Contains(_TestOffer));
		}

		[TestMethod]
		public void CreateOfferFromText() {
			RepoOffers.AddOffer(160867, 1, 284, _TestContractor, 0, 0);
			Offer CompareOffer = RepoOffers.GetOfferByID(160867);
			Assert.AreEqual(_TestOffer, CompareOffer); // Override the Equals method on Offer Class
		}
	}
}
