using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Models
{
    public class DenSmetkaModel
    {
        public int Id { get; set; }
        public string SmetkaInfo { get; set; }
        public string SmetkaDate { get; set; }
        public int SmetkaTotal { get; set; }
        public int DenDocumnetId { get; set; }
    }
}
