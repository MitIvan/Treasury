using Blagajna.DataAccess;
using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Domain.Shared.Models;
using Blagajna.Mappers;
using Blagajna.Models;
using Blagajna.Services.Exceptions;
using Blagajna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blagajna.Services.Implementation
{
    public class DenDocumentService : IDenDocumentService
    {
        private IRepository<DenDocument> _denDocumentRepository;
        private IRepository<Vraboten> _vrabotenRepository;
        private IRepository<PresmetkovnaEd> _presmetkovnaEdRepository;
        private IRepository<DenIzvod> _denIzvodRepository;

        public DenDocumentService(IRepository<DenDocument> denDocumentRepository, 
            IRepository<Vraboten> vrabotenRepository, 
            IRepository<PresmetkovnaEd> presmetkovnaEdRepository, 
            IRepository<DenIzvod> denIzvodRepository)
        {
            _denDocumentRepository = denDocumentRepository;
            _vrabotenRepository = vrabotenRepository;
            _presmetkovnaEdRepository = presmetkovnaEdRepository;
            _denIzvodRepository = denIzvodRepository;
        }


        public List<DenDocumentModel> GetAllDenDocuments()
        {
            List<DenDocument> denDocumentsDb = _denDocumentRepository.GetAll();
            List<DenDocumentModel> denDocumentModels = new List<DenDocumentModel>();
            
            foreach (DenDocument denDocument in denDocumentsDb)
            {
                denDocumentModels.Add(denDocument.ToDenDocumentModel()); 
            }
            return denDocumentModels;
        }

        public List<DenDocumentModel> GetAllDenDocumentsFinalIzvodFalse()
        {
            List<DenDocumentModel> denDocumentModels = new List<DenDocumentModel>();
            
            DenIzvod denIzvodsDb = _denIzvodRepository.GetAll().Where(x => x.FinalIzvod == false).FirstOrDefault();
            if(denIzvodsDb == null) 
            {
                return denDocumentModels;
            }
            
            List<DenDocument> denDocumentsDb = _denDocumentRepository.GetAll().Where(x => x.DenIzvodId == denIzvodsDb.Id).ToList();
            foreach (DenDocument denDocument in denDocumentsDb)
            {
                denDocumentModels.Add(denDocument.ToDenDocumentModel());
            }
            return denDocumentModels;
        }

        public DenDocumentModel GetDenDocumentById(int id)
        {
            DenDocument denDocumentDb = _denDocumentRepository.GetById(id);
            if (denDocumentDb == null)
            {
                throw new NotFoundException($"Document with id {id} was not found");
            }
            return denDocumentDb.ToDenDocumentModel();
        }

        public void AddDenDocument(DenDocumentModel denDocumentModel)
        {
            ValidateDenDocumentModel(denDocumentModel);
            DenDocument denDocumentDb = denDocumentModel.ToDenDocument();
            _denDocumentRepository.Add(denDocumentDb);
        }

        public void UpdateDenDocument(DenDocumentModel denDocumentModel)
        {
            ValidateDenDocumentModel(denDocumentModel);
           
            DenDocument denDocumentDb = _denDocumentRepository.GetById(denDocumentModel.Id);
            List<DenSmetka> denSmetki = denDocumentModel.DenSmetki.Select(x => x.ToDenSmetka()).ToList();
            denDocumentDb.DenSmetki = denSmetki;
            denDocumentDb.DocDate = denDocumentModel.DocDate;
            denDocumentDb.PresmetkovnaEdId = denDocumentModel.PresmetkovnaEdId;
            denDocumentDb.VidDocument = denDocumentModel.VidDocument;
            denDocumentDb.VrabotenId = denDocumentModel.VrabotenId;
            denDocumentDb.Zabeleska = denDocumentModel.Zabeleska;
            denDocumentDb.DenIzvodId = denDocumentModel.DenIzvodId;

            _denDocumentRepository.Update(denDocumentDb);

        }
        public void DeleteDenDocument(int id)
        {
            DenDocument denDocument = _denDocumentRepository.GetById(id);
            if( denDocument == null)
            {
                throw new NotFoundException(id.ToString());
            }
            _denDocumentRepository.Delete(denDocument);
        }

        private void ValidateDenDocumentModel(DenDocumentModel denDocumentModel)
        {
            Vraboten vrabotenDb = _vrabotenRepository.GetById(denDocumentModel.VrabotenId);
            PresmetkovnaEd presmetkovnaEdDb = _presmetkovnaEdRepository.GetById(denDocumentModel.PresmetkovnaEdId);

            if (vrabotenDb == null)
            {
                throw new DenDocumentExeption($"Vraboteniot so {denDocumentModel.VrabotenId} ne e najden ");
            }
            if (presmetkovnaEdDb == null)
            {
                throw new DenDocumentExeption($"Presmetkovnata so {denDocumentModel.PresmetkovnaEdId} ne e najdena ");
            }
            if (denDocumentModel.Zabeleska.ToCharArray().Count()> 200)
            {
                throw new DenDocumentExeption("Zabeleskata ne moze da sodrzi poveke od 200 karakteri");
            }
            if (denDocumentModel.DocDate == null)
            {
                throw new DenDocumentExeption("Dokumentot nema datum");
            }
            if (denDocumentModel.DenSmetki.Count < 1)
            {
                throw new DenDocumentExeption("Dokumentot nema Smetki");
            }
            if (denDocumentModel.DenSmetki.FindAll(x => x.SmetkaInfo == null || x.SmetkaDate == null || x.SmetkaTotal == 0).Count() > 0 )

            {
                throw new DenDocumentExeption("Fali podatok do smetka");
            }
        }

    }
}
