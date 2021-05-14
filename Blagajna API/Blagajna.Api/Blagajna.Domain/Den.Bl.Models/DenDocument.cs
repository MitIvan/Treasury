using Blagajna.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blagajna.Domain.Den.Bl.Models
{
    [Table("DenDocumnents")]
    public class DenDocument
    {   
        public int Id { get; set;}
        [Required]
        public DateTime DocDate { get; set; }
        [Required]
        public int VidDocument { get; set; }
        public int PresmetkovnaEdId { get; set; }
        public PresmetkovnaEd PresmetkovnaEd { get; set; }
        public int VrabotenId { get; set; }
        public Vraboten Vraboten { get; set; }
        [MaxLength(200)]
        public string Zabeleska { get; set; }
        [Required]
        public  int DenIzvodId { get; set; }
        public  DenIzvod DenIzvod { get; set; }
        public List<DenSmetka> DenSmetki { get; set; }
  
    }
}
