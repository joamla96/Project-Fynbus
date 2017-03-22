using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class Offer
    {
        private int OfferSeqNr;
        private Route Route;
        private int PricePerHour;
        private int RoutePriority;
        private int ContractorPriority;
        private Contractor Contractor;
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
    }
}
