using Blagajna.DataAccess;
using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Models;
using Blagajna.Services.Interfaces;
using System;
using System.Collections.Generic;
using Blagajna.Mappers;
using System.Text;
using System.Linq;
using Blagajna.Services.Exceptions;

namespace Blagajna.Services.Implementation
{
    public class DenIzvodService : IDenIzvodService
    {
        private IRepository<DenIzvod> _denIzvodRepository;
        private IRepository<DenDocument> _denDocumentRepository;

        public DenIzvodService(IRepository<DenIzvod> denIzvodRepository, IRepository<DenDocument> denDocumentRepository)
        {
            _denIzvodRepository = denIzvodRepository;
            _denDocumentRepository = denDocumentRepository;
        }

        public List<DenIzvodModel> GetAllDenIzvods()
        {
            List<DenIzvod> denIzvodsDb = _denIzvodRepository.GetAll();
            List<DenIzvodModel> denIzvodModels = new List<DenIzvodModel>();

            foreach (DenIzvod denIzvod in denIzvodsDb)
            {
                denIzvodModels.Add(denIzvod.ToDenIzvodModel());
            }
            return denIzvodModels; 
        }

        public DenIzvodModel GetDenIzvodById(int id)
        {
            DenIzvod denIzvodDb = _denIzvodRepository.GetById(id);
            if (denIzvodDb == null)
            {
                throw new NotFoundException($"Izvod with id {id} was not found");
            }
            return denIzvodDb.ToDenIzvodModel();
        }
        
        public DenIzvodModel GetLastDenIzvod()
        {
            DenIzvod denIzvodsDb = _denIzvodRepository.GetAll().Where(x => x.FinalIzvod == false).FirstOrDefault();
           return  denIzvodsDb.ToDenIzvodModel();
        }

        public void AddDenIzvod(DenIzvodModel denIzvodModel)
        {
            DenIzvod denIzvodDb = denIzvodModel.ToDenizvod();
            _denIzvodRepository.Add(denIzvodDb);
        }

        public void UpdateDenIzvod(DenIzvodModel denIzvodModel)
        {
            DenIzvod denIzvodDb = _denIzvodRepository.GetById(denIzvodModel.Id);
            List<DenDocument> denDocuments = denIzvodModel.DenDocuments.Select(x => x.ToDenDocument()).ToList();

            denIzvodDb.DenBlSostojba = denIzvodModel.DenBlSostojba;
            denIzvodDb.IzvodDate = denIzvodModel.IzvodDate;
            denIzvodDb.FinalIzvod = true;
            denIzvodDb.Saldo = denIzvodModel.Saldo;
            denIzvodDb.VkupenPriem = denIzvodModel.VkupenPriem;
            denIzvodDb.VkupnaIsplata = denIzvodModel.VkupnaIsplata;
            denIzvodDb.DenDocuments = denDocuments;

            _denIzvodRepository.Update(denIzvodDb);
            
                
                

        }
    }
}
