using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Offer
    {
        public int OfferSeqNr;
        public Route Route;
        public int PricePerHour;
        public int RoutePriority;
        public int ContractorPriority;
        public Contractor Contractor;
        public double TotalContractValue { get; set; }

        public Offer(int offerseqnr, Route route, int priceperhour, Contractor contractor, int routepriority, int contractorpriority)
        {
            this.OfferSeqNr = offerseqnr;
            this.Route = route;
            this.PricePerHour = priceperhour;
            this.Contractor = contractor;
            this.RoutePriority = routepriority;
            this.ContractorPriority = contractorpriority;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            Offer offer = (Offer)obj;
            if (this.OfferSeqNr == offer.OfferSeqNr)
            {
                result = true;  
            }
            return result;
        }
    }
}
