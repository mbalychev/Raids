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

    public partial class Goszadanie
    {
        public int Id { get; set; }
        public int PokazatelId { get; set; }
        public int EtcId { get; set; }
        [DisplayName("План")]
        public decimal Plan { get; set; }
        [DisplayName("Год")]
        public int Year { get; set; }
    }
}
