using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.employees
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public DetailsModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public Сотрудники Сотрудники { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Сотрудники = await _context.Сотрудникиs
                .Include(с => с.КодДолжностиNavigation).FirstOrDefaultAsync(m => m.КодСотрудника == id);

            if (Сотрудники == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
