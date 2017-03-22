using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Offer
    {
        private int OfferSeqNr;
        private int CarNr;
        private int PricePerHour;
        private int RoutePriority;
        private int ContractorPriority;
        private Contractor Contractor;

        public Offer(int offerseqnr, int carnr, int priceperhour, Contractor contractor, int routepriority, int contractorpriority)
        {
            this.OfferSeqNr = offerseqnr;
            this.CarNr = carnr;
            this.PricePerHour = priceperhour;
            this.Contractor = contractor;
            this.RoutePriority = routepriority;
            this.ContractorPriority = contractorpriority;
        }
    }
}
