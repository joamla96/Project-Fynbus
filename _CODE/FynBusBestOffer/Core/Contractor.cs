using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public class Contractor
	{
		public int ContractorSeqNr;
		public string ContractorName;
		public string CompanyName;
		public string CompanyEmail;
		public int[] CarTypeArray;

		public int[] CarTypeWonArray;

		public Contractor(int contractorseqnr, string contractorname, string companyname, string companyemail, int[] cartypearray) {
			this.ContractorSeqNr = contractorseqnr;
			this.ContractorName = contractorname;
			this.CompanyName = companyname;
			this.CompanyEmail = companyemail;
			this.CarTypeArray = cartypearray;
			this.CarTypeWonArray = new int[] { 0, 0, 0, 0, 0 };
		}

		public Contractor() {
		}
		public override bool Equals(object obj) {
			bool result = false;
			Contractor contractor = (Contractor)obj;
			if (this.ContractorSeqNr == contractor.ContractorSeqNr) {
				result = true;
			}
			return result;
		}

		public int GetCarsWonOfType(int type) {
			int index = this.GetCarTypeForArray(type);
			int wonCars = this.CarTypeWonArray[index];

			return wonCars;
		}

		public int GetCarsMaxOfType(int type) {
			int index = this.GetCarTypeForArray(type);
			int maxCars = this.CarTypeArray[index];

			return maxCars;
		}

		public void WonCarOfType(int type) {
			int index = GetCarTypeForArray(type);
			this.CarTypeWonArray[index]++;
		}

		public int GetCarTypeForArray(int cartype) {
			int index;
			switch (cartype) {
				case 2: index = 0; break;
				case 3:	index = 1; break;
				case 5:	index = 2; break;
				case 6: index = 3; break;
				case 7:	index = 4; break;

				default: throw new IndexOutOfRangeException();
			}
			return index;
		}
	}
}
