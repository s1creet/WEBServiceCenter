 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.orders
{
    public class IndexModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public IndexModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IList<Заказы> Заказы { get;set; }

        public async Task OnGetAsync()
        {
            Заказы = await _context.Заказыs
                .Include(з => з.КодВидаNavigation)
                .Include(з => з.КодМагазинаNavigation)
                .Include(з => з.КодСотрудникаNavigation).ToListAsync();
        }
    }
}
