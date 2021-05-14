using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Blagajna.Mappers
{
    public static class DenSmetkaMapper
    {
        public static DenSmetka ToDenSmetka(this DenSmetkaModel smetkaModel)
        {
            return new DenSmetka
            {
                Id = smetkaModel.Id,
                SmetkaDate = DateTime.Parse(smetkaModel.SmetkaDate),
                SmetkaInfo = smetkaModel.SmetkaInfo,
                SmetkaTotal = smetkaModel.SmetkaTotal,
                DenDocumnetId = smetkaModel.DenDocumnetId
            };
        }

        public static DenSmetkaModel ToDenSmetkaModel(this DenSmetka denSmetka)
        {
            return new DenSmetkaModel
            {
                Id = denSmetka.Id,
                SmetkaDate = denSmetka.SmetkaDate.ToString("d", CultureInfo.CreateSpecificCulture("de-De")),
                DenDocumnetId = denSmetka.DenDocumnetId,
                SmetkaInfo = denSmetka.SmetkaInfo,
                SmetkaTotal = denSmetka.SmetkaTotal
            };
        }
    }
}
