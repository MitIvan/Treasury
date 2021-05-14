using Blagajna.Domain;
using Blagajna.Domain.Den.Bl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blagajna.DataAccess.Implementations
{
    public class DenIzvodRepo : IRepository<DenIzvod>
    {

        private DenBlDbContext _denBlDbContext;

        public DenIzvodRepo(DenBlDbContext denBlDbContext)
        {
            _denBlDbContext = denBlDbContext;
        }
        public List<DenIzvod> GetAll()
        {
            return _denBlDbContext
                .DenIzvodi
                .Include(x => x.DenDocuments)
                .ThenInclude(x => x.DenSmetki)
                .ToList();
        }

        public DenIzvod GetById(int id)
        {
            return _denBlDbContext
                .DenIzvodi
                .Include(x => x.DenDocuments)
                .ThenInclude(x => x.DenSmetki)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(DenIzvod entity)
        {
            _denBlDbContext.DenIzvodi.Add(entity);
            _denBlDbContext.SaveChanges();
        }
        public void Update(DenIzvod entity)
        {
            _denBlDbContext.DenIzvodi.Update(entity);
            _denBlDbContext.SaveChanges();
        }

        public void Delete(DenIzvod entity)
        {
            _denBlDbContext.DenIzvodi.Remove(entity);
            _denBlDbContext.SaveChanges();
        }


    }
}
