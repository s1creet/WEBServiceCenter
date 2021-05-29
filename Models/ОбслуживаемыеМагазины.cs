using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class ОбслуживаемыеМагазины
    {
        public ОбслуживаемыеМагазины()
        {
            Заказыs = new HashSet<Заказы>();
        }

        public long КодМагазина { get; set; }
        public long Наименование { get; set; }
        public long Адрес { get; set; }
        public long Телефон { get; set; }

        public virtual ICollection<Заказы> Заказыs { get; set; }
    }
}
