using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Models;

namespace ServiceCenter.Pages.FiltersandRequest.Request
{
    public class HRdepModel : PageModel
    {
        private readonly ServiceCenter.Data.ServiceCenterContext _context;
        public  HRdepModel(ServiceCenter.Data.ServiceCenterContext context)
        {
            _context = context;
        }

        public IList<����������> ����������s { get; set; }
        public IList<���������> ���������s { get; set; }
        public async Task OnGetAsync()
        {
            ����������s = await _context.����������s.ToListAsync();
            ���������s = await _context.���������s.ToListAsync();
        }
    }
}
