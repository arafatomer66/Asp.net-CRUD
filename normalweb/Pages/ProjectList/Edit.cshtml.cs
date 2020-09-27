using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using normalweb.Modal;

namespace normalweb.Pages.ProjectList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Project Project { get; set; }
        public async Task OnGet(int Id)
        {
            Project = await _db.Project.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProjectObj = await _db.Project.FindAsync(Project.Id);
                ProjectObj.Name = Project.Name;
                ProjectObj.Manager = Project.Manager;
                ProjectObj.Description = Project.Description;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
