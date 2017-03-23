using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.UnitTests
{
    [TestClass]
    public class ContractorTests
    {
        RepositoryContractors _repoContractors;
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
            _repoContractors = new RepositoryContractors();
        }

        [TestMethod]
        public void AddContractorFromObject()
        {
            _repoContractors.AddContractor(_testContractor1);
            List<Contractor> contractorsList = _repoContractors.GetAllContractors();
            Assert.IsTrue(contractorsList.Contains(_testContractor1));
        }

        [TestMethod]
        public void AddContractorFromText()
        {
            _repoContractors.AddContractor(163460, "Navn A", "Firma A", "Apple@Email.com", new int[] { 0, 0, 2, 0, 0 });
            List<Contractor> contractorsList = _repoContractors.GetAllContractors();
            Assert.IsTrue(contractorsList.Contains(new Contractor(163460, "Navn A", "Firma A", "Apple@Email.com", new int[] { 0, 0, 2, 0, 0 })));
        }

        [TestMethod]
        public void GetContractorByID()
        {
            _repoContractors.AddContractor(_testContractor1);
            _repoContractors.AddContractor(_testContractor2);
            _repoContractors.AddContractor(_testContractor3);

            Contractor compareContractor = _repoContractors.GetContractorByID(_testContractor1.ContractorSeqNr);
            Assert.AreEqual(_testContractor1, compareContractor);
        }

        [TestMethod]
        public void DeleteContractorByID()
        {
            _repoContractors.AddContractor(_testContractor1);
        }
    }
}
