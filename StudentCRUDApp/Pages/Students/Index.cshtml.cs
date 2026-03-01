using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentCRUDApp.Data;
using StudentCRUDApp.Models;

namespace StudentCRUDApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentCRUDApp.Data.AppDbContext _context;

        public IndexModel(StudentCRUDApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
