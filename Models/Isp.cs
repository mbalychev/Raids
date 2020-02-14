using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raids.Models
{
    /// <summary>
    /// класс представляющий таблицу исполнители в БД
    /// </summary>
    public class Isp
    {
        public int Id { get; set; }
        [DisplayName("ФИО Исполнителя")]
        public string Name { get; set; }
        public int OtdelId { get; set; }
        public Nullable<bool> Del { get; set; }
        public Nullable<bool> GenderM { get; set; }

    }
}
