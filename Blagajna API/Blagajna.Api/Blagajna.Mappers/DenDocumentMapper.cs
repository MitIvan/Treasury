using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blagajna.Mappers
{
    public static class DenDocumentMapper
    {
        public static DenDocument ToDenDocument(this DenDocumentModel denDocumentModel)
        {
            
            return new DenDocument
            {
                Id = denDocumentModel.Id,
                DocDate = denDocumentModel.DocDate,
                VidDocument = denDocumentModel.VidDocument,
                Zabeleska = denDocumentModel.Zabeleska,
                PresmetkovnaEdId = denDocumentModel.PresmetkovnaEdId,
                VrabotenId = denDocumentModel.VrabotenId,
                DenSmetki = denDocumentModel.DenSmetki.Select(x => x.ToDenSmetka()).ToList(),
                DenIzvodId = denDocumentModel.DenIzvodId 
            };
        }

        public static DenDocumentModel ToDenDocumentModel(this DenDocument denDocument)
        {
            return new DenDocumentModel
            {
                Id = denDocument.Id,
                DocDate = denDocument.DocDate,
                VidDocument = denDocument.VidDocument,
                Zabeleska = denDocument.Zabeleska,
                PresmetkovnaEdId = denDocument.PresmetkovnaEdId,
                PeNumber = denDocument.PresmetkovnaEd.PeNumber,
                PresmetkovnaName = denDocument.PresmetkovnaEd.PeName,
                VrabotenId = denDocument.VrabotenId,
                VrabotenMb = denDocument.Vraboten.Mb,
                VrabotenFullName = $"{denDocument.Vraboten.FullName}",
                DenIzvodId = denDocument.DenIzvodId,
                DenSmetki = denDocument.DenSmetki.Select(x => x.ToDenSmetkaModel()).ToList(),
                TotalSmetki = denDocument.DenSmetki.Sum(x => x.SmetkaTotal)
            };
        }
    }
}
