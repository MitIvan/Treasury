using Blagajna.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blagajna.Domain.Den.Bl.Models
{
    public class DenIzvod
    {
        public int Id { get; set; }
        public DateTime IzvodDate { get; set; }
        public int VkupnaIsplata { get; set; }
        public int VkupenPriem { get; set; }
        public int Saldo { get; set; }
        public  int DenBlSostojba { get; set; }
        public bool FinalIzvod { get; set; }
        public List<DenDocument> DenDocuments { get; set; }

    }
}
