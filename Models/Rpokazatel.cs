//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raids.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    

    public class Rpokazatel
    {
        public int Id { get; set; }
        public int PokazatelId { get; set; }
        public int EtcId { get; set; }
        public int RaidId { get; set; }
        [DisplayName("Значение")]
        public decimal Amount { get; set; }
        public Nullable<int> ChapterId { get; set; }
        public Nullable<int> FuelId { get; set; }

        public Pokazatel Pokazatel { get; set; }
    }
}
