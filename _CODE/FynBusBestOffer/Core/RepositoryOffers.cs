using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    public class RepositoryOffers
    {
        List<Offer> _offer = new List<Offer>();

        public static RepositoryOffers Instance { get; set; }

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


        public List<Offer> GetOffers(Contractor contractor)
        {
            List<Offer> contractorOffers = new List<Offer>();
            foreach (Offer element in _offer)
            {
                if (element.Contractor == contractor)
                {
                    contractorOffers.Add(element);

                }
            }
            return contractorOffers;

        }

        public List<Offer> GetOffers(Route route)
        {
            List<Offer> routeOffers = new List<Offer>();
            foreach (Offer element in _offer)
            {
                if (element.Route == route)
                {
                    routeOffers.Add(element);

                }
            }
            return routeOffers;

        }


        public void DeleteOffer(int offerseqnr)
        {
            Offer toDelete = this.GetOfferByID(offerseqnr);
            _offer.Remove(toDelete);
        }

        public void DeleteOffer(Contractor contractor)
        {
            List<Offer> contractorOffers = this.GetOffers(contractor);
            foreach(Offer element in contractorOffers)
            {
                _offer.Remove(element);
            }
        }


        public void Clear()
        {
            _offer.Clear();
        }

    }
}
