using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceCenter.Models
{
    public partial class Заказы
    {
        public long ЗаказыId { get; set; }
        public long ДатаЗаказа { get; set; }
        public long ДатаВозврата { get; set; }
        public long ФиоЗаказчика { get; set; }
        public long СерийныеНомер { get; set; }
        public long КодВидаНеисправности { get; set; }
        public long ОтметкаОГарантии { get; set; }
        public long СкорГарантииРемонта { get; set; }
        public long Цена { get; set; }
        public long КодСотрудника { get; set; }
        public long КодМагазина { get; set; }
        public string  КодВида { get; set; }

        public virtual ВидыНеисправностей КодВидаNavigation { get; set; }
        public virtual ОбслуживаемыеМагазины КодМагазинаNavigation { get; set; }
        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
    }
}
