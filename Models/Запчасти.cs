using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class Запчасти
    {
        public Запчасти()
        {
            ВидыНеисправностейЗапчасть2кодЗапчастиNavigations = new HashSet<ВидыНеисправностей>();
            ВидыНеисправностейЗапчасть3кодЗапчастиNavigations = new HashSet<ВидыНеисправностей>();
            ВидыНеисправностейКодЗапчастиNavigations = new HashSet<ВидыНеисправностей>();
        }

        public long КодЗапчасти { get; set; }
        public long Наименования { get; set; }
        public long Функции { get; set; }
        public long Цена { get; set; }

        public virtual ICollection<ВидыНеисправностей> ВидыНеисправностейЗапчасть2кодЗапчастиNavigations { get; set; }
        public virtual ICollection<ВидыНеисправностей> ВидыНеисправностейЗапчасть3кодЗапчастиNavigations { get; set; }
        public virtual ICollection<ВидыНеисправностей> ВидыНеисправностейКодЗапчастиNavigations { get; set; }
    }
}
