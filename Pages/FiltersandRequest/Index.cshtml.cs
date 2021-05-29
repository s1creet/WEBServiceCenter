using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceCenter.Pages.FiltersandRequest
{
    public class IndexModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public IndexModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public List<SelectListItem> HRdep { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> BugList { get; set; }



        public IActionResult OnGet()
        {
            HRdep = _context.Должностиs.Select(p =>
            new SelectListItem
            {
                Value = p.КодДолжности.ToString(),
                Text = p.НаименованиеДолжности
            }).ToList();

            return Page();
        }
    }
}