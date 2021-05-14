using Blagajna.Domain;
using Blagajna.Domain.Den.Bl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blagajna.DataAccess.Implementations
{
    public class DenDocumentRepo : IRepository<DenDocument>
    {
        private DenBlDbContext _denBlDbContext;

        public DenDocumentRepo(DenBlDbContext denBlDbContext)
        {
            _denBlDbContext = denBlDbContext;
        }

        public List<DenDocument> GetAll()
        {
            return _denBlDbContext
                .DenDocumenti
                .Include(x => x.PresmetkovnaEd)
                .Include(x => x.Vraboten)
                .Include(x => x.DenSmetki)
                .ToList();          
        }
        public DenDocument GetById(int id)
        {
            return _denBlDbContext
                .DenDocumenti
                .Include(x => x.PresmetkovnaEd)
                .Include(x => x.Vraboten)
                .Include(x => x.DenSmetki)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(DenDocument entity)
        {
            _denBlDbContext.DenDocumenti.Add(entity);
            _denBlDbContext.SaveChanges();
        }

        public void Delete(DenDocument entity)
        {
            _denBlDbContext.DenDocumenti.Remove(entity);
            _denBlDbContext.SaveChanges();
        }


        public void Update(DenDocument entity)
        {
            _denBlDbContext.DenDocumenti.Update(entity);
            _denBlDbContext.SaveChanges();
        }
    }
    
}
