using Blagajna.DataAccess;
using Blagajna.Domain.Shared.Models;
using Blagajna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Implementation
{
    public class VrabotenService : IVraboten
    {
        private IRepository<Vraboten> _vrabotenRepository;
        public VrabotenService(IRepository<Vraboten> vrabotenRepository)
        {
            _vrabotenRepository = vrabotenRepository;
        }
        public List<Vraboten> GetAllVraboteni()
        {
            List<Vraboten> vraboteni = _vrabotenRepository.GetAll();
            return vraboteni;
        }
    }
}
