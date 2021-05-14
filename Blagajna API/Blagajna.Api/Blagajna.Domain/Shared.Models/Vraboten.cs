using Blagajna.Domain.Den.Bl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Domain.Shared.Models
{
    public class Vraboten
    {
        public int Id { get; set; }
        public int Mb { get; set; }
        public string FullName { get; set; }
        public List<DenDocument> DenDocuments { get; set; }
    }
}
