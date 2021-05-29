using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class РемонтируемыеМодели
    {
        public РемонтируемыеМодели()
        {
            ВидыНеисправностейs = new HashSet<ВидыНеисправностей>();
        }

        public long КодМодели { get; set; }
        public long Наименование { get; set; }
        public long Тип { get; set; }
        public long Производитель { get; set; }
        public long ТехническиеХарантеристики { get; set; }
        public long Особенности { get; set; }

        public virtual ICollection<ВидыНеисправностей> ВидыНеисправностейs { get; set; }
    }
}
