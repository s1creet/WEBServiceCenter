using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.view
{
    public class IndexModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public IndexModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IList<ВидыНеисправностей> ВидыНеисправностей { get;set; }

        public async Task OnGetAsync()
        {
            ВидыНеисправностей = await _context.ВидыНеисправностейs
                .Include(в => в.Запчасть2кодЗапчастиNavigation)
                .Include(в => в.Запчасть3кодЗапчастиNavigation)
                .Include(в => в.КодЗапчастиNavigation)
                .Include(в => в.КодМоделиNavigation).ToListAsync();
        }
    }
}
