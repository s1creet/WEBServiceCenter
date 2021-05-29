using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.FiltersandRequest.Filters
{
    public class employeeFilterModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public employeeFilterModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IList<Сотрудники> Сотрудник { get; set; }
        public Должности Должность { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Должность = _context.Должностиs.First(m => m.КодДолжности == id);

            if (Должность == null)
            {
                return NotFound();
            }
            Сотрудник = await _context.Сотрудникиs
                .Include(e => e.КодДолжности).Where(m => m.КодДолжности == Должность.КодДолжности).ToListAsync();
            return Page();
        }
    }
}