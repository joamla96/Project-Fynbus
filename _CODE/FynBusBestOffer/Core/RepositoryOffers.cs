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
            //Offer offer = new Offer( offerseqnr, carnr, priceperhour, contractor, routepriority, contractorpriority);
            //_offer.AddRange();
            
            _offer.Add(new Offer(offerseqnr, route, priceperhour, contractor, routepriority, contractorpriority) { });
        }

        public Offer GetOfferByID(int v)
        {
            throw new NotImplementedException();
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
