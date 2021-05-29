using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class Сотрудники
    {
        public Сотрудники()
        {
            Заказыs = new HashSet<Заказы>();
        }

        public long ПаспортныеДанные { get; set; }
        public long Телефон { get; set; }
        public long Адрес { get; set; }
        public long Пол { get; set; }
        public long КодСотрудника { get; set; }
        public long КодДолжности { get; set; }
        public long ФИО { get; set; }
        public long Возраст { get; set; }


        public virtual Должности КодДолжностиNavigation { get; set; }
        public virtual ICollection<Заказы> Заказыs { get; set; }
    }
}
