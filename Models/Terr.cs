using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Raids.Models
{
    public class Terr
    {
        public int Id { get; set; }
        [DisplayName("Территория")]
        public string Name { get; set; }
        
    }
}
