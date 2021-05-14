using Blagajna.DataAccess;
using Blagajna.Domain.Shared.Models;
using Blagajna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Implementation
{
    public class PresmetkovnaEdService : IPresmetkovnaEd
    {
        private IRepository<PresmetkovnaEd> _presmetkovnaEdRepository;
        public PresmetkovnaEdService(IRepository<PresmetkovnaEd> presmetkovnaEdRepository)
        {
            _presmetkovnaEdRepository = presmetkovnaEdRepository;
        }

        public List<PresmetkovnaEd> GetPresmetkovnaEds()
        {
            List<PresmetkovnaEd> presmetkovnaEds = _presmetkovnaEdRepository.GetAll();
            return presmetkovnaEds;
        }
    }
}
