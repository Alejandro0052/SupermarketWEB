using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Reflection.Metadata.Ecma335;

namespace SupermarketWEB.Pages.Categories
{
    public class CreateModel : PageModel
    {
        /*@  public void OnGet()
          {
          }@*/
        private readonly SupermarketContext _context;


        public CreateModel(SupermarketContext cotext)
        {
            _context = cotext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Category == null)
            {
                return Page();
            }


            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}

