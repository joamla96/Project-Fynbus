using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class RepositoryContractors
    {
        List<Contractor> _contractor = new List<Contractor>();

        private static RepositoryContractors _instance = new RepositoryContractors();
        public static RepositoryContractors Instance { get {return _instance; } }

        public void AddContractor(Contractor contractor)
        {
            _contractor.Add(contractor);
        }

        public List<Contractor> GetAllContractors()
        {
            return _contractor;
        }

        public void AddContractor(int contractorseqnr, string contractorname, string companyname, string companyemail, int[] cartypearray)
        {
            Contractor contractor = new Contractor(contractorseqnr, contractorname, companyname, companyemail, cartypearray);
            _contractor.Add(contractor);
        }

        public Contractor GetContractorByID(int contractorseqnr)
        {
            Contractor result = null;
            foreach (Contractor element in _contractor)
            {
                if (element.ContractorSeqNr == contractorseqnr)
                {
                    result = element;
                }
            }
            return result;
        }

        public void DeleteContractor(int contractorseqnr)
        {
            Contractor toDelete = this.GetContractorByID(contractorseqnr);
            _contractor.Remove(toDelete);
        }

        public void Clear()
        {
            _contractor.Clear();
        }
    }
}
