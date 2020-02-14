using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raids.Models
{
    public class Risp
    {
        public int Id { get; set; }
        public int IspId { get; set; }
        public Nullable<int> RpokazatelId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Stop { get; set; }
        public int RaidId { get; set; }
        public Nullable<int> EtcId { get; set; }

        public Isp Isp { get; set; }
    }

}
