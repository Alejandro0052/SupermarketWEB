using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        /*public void OnGet()
        {
        }*/
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
          _context = context;
        }
		[BindProperty]
		public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id );

            if (category == null) 
            {
                return NotFound();
            
            }
            else 
            {
                Category = category;
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

            }
            return RedirectToPage("./Index");
        }


        /*
		public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null) 
            {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
        */


	}
}
