using Blagajna.Domain;
using Blagajna.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blagajna.DataAccess.Implementations
{
    public class PresmetkovnaEdRepo: IRepository<PresmetkovnaEd>
    {
        private DenBlDbContext _denBlDbContext;

        public PresmetkovnaEdRepo(DenBlDbContext denBlDbContext)
        {
            _denBlDbContext = denBlDbContext;
        }

        public List<PresmetkovnaEd> GetAll()
        {
            return _denBlDbContext
                .PresmetkovniEd
                .ToList();
        }
        public PresmetkovnaEd GetById(int id)
        {
            return _denBlDbContext
                .PresmetkovniEd
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(PresmetkovnaEd entity)
        {
            _denBlDbContext.PresmetkovniEd.Add(entity);
            _denBlDbContext.SaveChanges();
        }

        public void Delete(PresmetkovnaEd entity)
        {
            _denBlDbContext.PresmetkovniEd.Remove(entity);
            _denBlDbContext.SaveChanges();
        }


        public void Update(PresmetkovnaEd entity)
        {
            _denBlDbContext.PresmetkovniEd.Update(entity);
            _denBlDbContext.SaveChanges();
        }
    }
}
