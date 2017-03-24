using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Contractor
    {
        public int ContractorSeqNr;
        public string ContractorName;
        public string CompanyName;
        public string CompanyEmail;
        public int[] CarTypeArray;

        public Contractor(int contractorseqnr, string contractorname, string companyname, string companyemail, int[] cartypearray)
        {
            this.ContractorSeqNr = contractorseqnr;
            this.ContractorName = contractorname;
            this.CompanyName = companyname;
            this.CompanyEmail = companyemail;
            this.CarTypeArray = cartypearray;
        }

        public Contractor()
        {
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            Contractor contractor = (Contractor)obj;
            if (this.ContractorSeqNr == contractor.ContractorSeqNr)
            {
                result = true;
            }
            return result;
        }
    }
}
