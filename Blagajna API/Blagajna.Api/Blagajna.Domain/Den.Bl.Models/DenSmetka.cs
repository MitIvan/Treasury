using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Blagajna.Domain.Den.Bl.Models
{
    public class DenSmetka
    {
        public int Id { get; set; }
        public string SmetkaInfo { get; set; }
        public DateTime SmetkaDate { get; set; }
        public int SmetkaTotal { get; set; }
        public int DenDocumnetId { get; set; }
        public  DenDocument DenDocumnet { get; set; }
    }
}
