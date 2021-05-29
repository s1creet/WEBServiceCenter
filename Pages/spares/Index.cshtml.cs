using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.spares
{
    public class IndexModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public IndexModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IList<Запчасти> Запчасти { get;set; }

        public async Task OnGetAsync()
        {
            Запчасти = await _context.Запчастиs.ToListAsync();
        }
    }
}
