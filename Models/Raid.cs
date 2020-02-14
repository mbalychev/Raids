using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raids.Models
{
    public partial class Raid
    {
        public int Id { get; set; }
        [DisplayName("Номер")]
        public string Nomer { get; set; }
        [DisplayName("Приказ")]
        public string Prikaz { get; set; }
        [DisplayName("Начало")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Start { get; set; }
        [DisplayName("Завершение")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Stop { get; set; }
        public int TerrId { get; set; }
        [DisplayName("Завершен")]
        public bool Close { get; set; }
        
        public Terr Terr { get; set; }
        public List<Risp> Risp { get; set; }
        public List<Rfile> Rfile { get; set; }
        public List<Rpokazatel> Rpokazatel { get; set; }
    }
}
