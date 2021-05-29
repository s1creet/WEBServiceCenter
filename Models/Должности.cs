using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудникиs = new HashSet<Сотрудники>();
        }

        public long КодДолжности { get; set; }
        public string НаименованиеДолжности { get; set; }
        public long Оклад { get; set; }
        public long Обязанности { get; set; }
        public long Требования { get; set; }

        public virtual ICollection<Сотрудники> Сотрудникиs { get; set; }
    }
}
