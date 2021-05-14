using Blagajna.Domain.Den.Bl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Models
{
    public class DenIzvodModel
    {
        public int Id { get; set; }
        public DateTime IzvodDate { get; set; }
        public int VkupnaIsplata { get; set; }
        public int VkupenPriem { get; set; }
        public int Saldo { get; set; }
        public int DenBlSostojba { get; set; }
        public bool FinalIzvod { get; set; }
        public List<DenDocumentModel> DenDocuments { get; set; }
    }
}
