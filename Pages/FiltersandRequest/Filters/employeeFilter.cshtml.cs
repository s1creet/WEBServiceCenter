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

        public IList<����������> ��������� { get; set; }
        public ��������� ��������� { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ��������� = _context.���������s.First(m => m.������������ == id);

            if (��������� == null)
            {
                return NotFound();
            }
            ��������� = await _context.����������s
                .Include(e => e.������������).Where(m => m.������������ == ���������.������������).ToListAsync();
            return Page();
        }
    }
}