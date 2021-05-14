using Blagajna.Domain.Den.Bl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Domain.Shared.Models
{
    public class PresmetkovnaEd
    {
        public int Id  { get; set; }
        public int PeNumber { get; set; }
        public string PeName { get; set; }
        public List<DenDocument> DenDocuments { get; set; }
    }
}
