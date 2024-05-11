using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    [Authorize]
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

		public Product Product { get; set; } = default!;
		                                                        
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			else
			{
				Product = product;
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
