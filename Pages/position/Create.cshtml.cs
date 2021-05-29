using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.position
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
            return Page();
        }

        [BindProperty]
        public Должности Должности { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Должностиs.Add(Должности);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
