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
        private DateTime stop;

        public int Id { get; set; }
        [Required]
        [DisplayName("Номер")]
        public string Nomer { get; set; }
        [Required]
        [DisplayName("Приказ")]
        public string Prikaz { get; set; }
        [Required]
        [DisplayName("Начало")]
        [DataType(DataType.Date)]
        public System.DateTime Start { get; set; }
        [DisplayName("Завершение")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Stop 
        { 
            get => stop;
            set
            {
                DateTime date = value;
                if (date >= this.Start)
                    stop = value;
            }
        }
        [Required]
        [DisplayName("Территория")]
        public int TerrId { get; set; }
        [Required]
        [DisplayName("Завершен")]
        public bool Close { get; set; }

        public int NumberInt => Convert.ToInt32(this.Nomer);

        public Terr Terr { get; set; }
        public List<Risp> Risp { get; set; }
        public List<Rfile> Rfile { get; set; }
        public List<Rpokazatel> Rpokazatel { get; set; }
    }
}
