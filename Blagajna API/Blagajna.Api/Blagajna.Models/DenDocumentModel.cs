using Blagajna.Domain.Den.Bl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Models
{
    public class DenDocumentModel
    {
        public int Id { get; set; }
        public DateTime DocDate { get; set; }
        public int VidDocument { get; set; }
        public int PresmetkovnaEdId { get; set; }
        public int PeNumber { get; set; }
        public string PresmetkovnaName { get; set; }
        public int VrabotenId { get; set; }
        public string VrabotenFullName { get; set; }
        public int VrabotenMb { get; set; }
        public string Zabeleska { get; set; }
        public int TotalSmetki { get; set; }
        public int DenIzvodId { get; set; }
        public List<DenSmetkaModel> DenSmetki { get; set; }
    }
}
