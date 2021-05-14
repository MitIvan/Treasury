using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Blagajna.Mappers
{
    public static class DenIzvodMapper
    {
        public static DenIzvod ToDenizvod(this DenIzvodModel denIzvodModel)
        {

            return new DenIzvod
            {
                Id = denIzvodModel.Id,
                DenBlSostojba = denIzvodModel.DenBlSostojba,
                IzvodDate = denIzvodModel.IzvodDate,
                VkupenPriem = denIzvodModel.VkupenPriem,
                VkupnaIsplata = denIzvodModel.VkupnaIsplata,
                Saldo = denIzvodModel.Saldo,
                DenDocuments = denIzvodModel.DenDocuments.Select(x => x.ToDenDocument()).ToList(),
                FinalIzvod = denIzvodModel.FinalIzvod
            };
        }
        public static DenIzvodModel ToDenIzvodModel (this DenIzvod denIzvod)
        {
            int vkupnaIsplata = denIzvod.DenDocuments.Where(x => x.VidDocument == 1 || x.VidDocument == 2 || x.VidDocument == 3 || x.VidDocument == 4)
                    .Select(y => y.DenSmetki
                    .Sum(x => x.SmetkaTotal))
                    .Sum();
            int vkupenPriem = denIzvod.DenDocuments.Where(x => x.VidDocument == 5 || x.VidDocument == 6)
                    .Select(y => y.DenSmetki
                    .Sum(x => x.SmetkaTotal))
                    .Sum();
            int saldo = denIzvod.DenBlSostojba - vkupnaIsplata + vkupenPriem;

            return new DenIzvodModel
            {
                Id = denIzvod.Id,
                DenBlSostojba = denIzvod.DenBlSostojba,
                IzvodDate = denIzvod.IzvodDate,
                VkupenPriem = vkupenPriem,
                VkupnaIsplata = vkupnaIsplata,
                Saldo = saldo,
                FinalIzvod = denIzvod.FinalIzvod
            };
        }
    }
}
