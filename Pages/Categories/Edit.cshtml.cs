using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class EditModel : PageModel
    {
      /*  public void OnGet()
        {
        }*/
      private readonly SupermarketContext _context;
        
        public EditModel(SupermarketContext context)
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

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
        catch (DbUpdateConcurrencyException) //  HERE A MODIFICATION
         //  catch (Exception ex)             
            {
                if (!CategoryExists(Category.Id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            
            }
            return RedirectToPage("./Index");
        }
        private bool CategoryExists(int id) 
        {
         return (_context.Categories?.Any(e=> e.Id == id)).GetValueOrDefault();
        }

                                                                                 










    }
}
