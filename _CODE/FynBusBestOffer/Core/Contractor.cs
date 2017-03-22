using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Contractor
    {
        private int ContractorSeqNr;
        private string ContractorName;
        private string CompanyName;
        private string CompanyEmail;
        private int[] CarTypeArray;

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
    }
}
