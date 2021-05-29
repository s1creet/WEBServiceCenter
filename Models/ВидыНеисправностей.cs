using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class ВидыНеисправностей
    {
        public ВидыНеисправностей()
        {
            Заказыs = new HashSet<Заказы>();
        }

        public long КодВида { get; set; }
        public long Описание { get; set; }
        public long Симптомы { get; set; }
        public long МетодыРемонта { get; set; }
        public long ЦенаРаботы { get; set; }
        public long КодЗапчасти { get; set; }
        public long КодМодели { get; set; }
        public long Запчасть2кодЗапчасти { get; set; }
        public long Запчасть3кодЗапчасти { get; set; }

        public virtual Запчасти Запчасть2кодЗапчастиNavigation { get; set; }
        public virtual Запчасти Запчасть3кодЗапчастиNavigation { get; set; }
        public virtual Запчасти КодЗапчастиNavigation { get; set; }
        public virtual РемонтируемыеМодели КодМоделиNavigation { get; set; }
        public virtual ICollection<Заказы> Заказыs { get; set; }
    }
}
