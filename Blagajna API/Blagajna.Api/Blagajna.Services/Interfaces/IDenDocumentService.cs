using Blagajna.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Services.Interfaces
{
    public interface IDenDocumentService
    {
        List<DenDocumentModel> GetAllDenDocuments();
        List<DenDocumentModel> GetAllDenDocumentsFinalIzvodFalse();
        DenDocumentModel GetDenDocumentById(int id);
        void AddDenDocument(DenDocumentModel denDocumentModel);
        void UpdateDenDocument(DenDocumentModel denDocumentModel);
        void DeleteDenDocument(int id);
    }
}
