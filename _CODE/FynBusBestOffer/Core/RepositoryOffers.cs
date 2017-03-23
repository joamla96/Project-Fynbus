using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class RepositoryOffers
    {
        List<Offer> _offer = new List<Offer>();
        public void AddOffer(Offer offer)
        {
            _offer.Add(offer);
        }

        public List<Offer> GetAllOffers()
        {
            return _offer;
        }

        public void AddOffer(int offerseqnr, Route route, int priceperhour, Contractor contractor, int routepriority, int contractorpriority)
        {
            Offer offer = new Offer( offerseqnr, route, priceperhour, contractor, routepriority, contractorpriority);
            _offer.Add(offer);
        }

        public Offer GetOfferByID(int offerseqnr)
        {
            Offer result = null;
            foreach (Offer element in _offer)
            {
                if(element.OfferSeqNr == offerseqnr)
                {
                    result = element;
                }
            }
             return result;
             
        }

        public void DeleteOffer(int v)
        {
            throw new NotImplementedException();
        }

        public void DeleteOffer(Contractor contractor)
        {
            throw new NotImplementedException();
        }


        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
