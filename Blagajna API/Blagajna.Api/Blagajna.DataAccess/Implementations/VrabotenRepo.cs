using Blagajna.Domain;
using Blagajna.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blagajna.DataAccess.Implementations
{
    public class VrabotenRepo: IRepository<Vraboten>
    {
        private DenBlDbContext _denBlDbContext;

        public VrabotenRepo(DenBlDbContext denBlDbContext)
        {
            _denBlDbContext = denBlDbContext;
        }

        public List<Vraboten> GetAll()
        {
            return _denBlDbContext
                .Vraboteni
                .ToList();
        }
        public Vraboten GetById(int id)
        {
            return _denBlDbContext
                .Vraboteni
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Vraboten entity)
        {
            _denBlDbContext.Vraboteni.Add(entity);
            _denBlDbContext.SaveChanges();
        }

        public void Delete(Vraboten entity)
        {
            _denBlDbContext.Vraboteni.Remove(entity);
            _denBlDbContext.SaveChanges();
        }


        public void Update(Vraboten entity)
        {
            _denBlDbContext.Vraboteni.Update(entity);
            _denBlDbContext.SaveChanges();
        }
    }
}
