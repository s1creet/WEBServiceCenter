using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.view
{
    public class CreateModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;

        public CreateModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Запчасть2кодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
        ViewData["Запчасть3кодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
        ViewData["КодЗапчасти"] = new SelectList(_context.Запчастиs, "КодЗапчасти", "КодЗапчасти");
        ViewData["КодМодели"] = new SelectList(_context.РемонтируемыеМоделиs, "КодМодели", "КодМодели");
            return Page();
        }

        [BindProperty]
        public ВидыНеисправностей ВидыНеисправностей { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ВидыНеисправностейs.Add(ВидыНеисправностей);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
