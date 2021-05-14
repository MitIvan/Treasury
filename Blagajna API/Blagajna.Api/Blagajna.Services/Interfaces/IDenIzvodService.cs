using Blagajna.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Interfaces
{
    public interface IDenIzvodService
    {
        List<DenIzvodModel> GetAllDenIzvods();
        DenIzvodModel GetDenIzvodById(int id);
        DenIzvodModel GetLastDenIzvod();
        void AddDenIzvod(DenIzvodModel denIzvodModel);
        void UpdateDenIzvod(DenIzvodModel denIzvodModel);
    }
}
