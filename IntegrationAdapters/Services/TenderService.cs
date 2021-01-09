﻿using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class TenderService
    {
        private ITenderRepository tenderRepository;

        public TenderService()
        {
            this.tenderRepository = new TenderRepository();
        }

        public TenderService(TenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }

        public bool AddTender(Tender tender)
        {
            return tenderRepository.AddTender(tender);
        }

        public List<Tender> GetAllTenders()
        {
            return tenderRepository.GetAllTenders();
        }
        public Tender GetTenderByName(string name) {
            foreach(Tender t in GetAllTenders()){
                if (t.TenderName.Equals(name))
                    return t;
            }
            return null;
        }
        public bool AddOffer(Offer offer)
        {
            return tenderRepository.AddOffer(offer);
        }

        public List<Offer> GetAllOffers()
        {
            return tenderRepository.GetAllOffers();
        }
    }
}
