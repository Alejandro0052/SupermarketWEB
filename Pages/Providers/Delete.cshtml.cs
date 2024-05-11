using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;


namespace SupermarketWEB.Pages.Providers
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

			public Provider Provider { get; set; } = default!;

    
     
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Providers == null)
			{
				return NotFound();
			}
		
				var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);

				if (provider == null)
				{
					return NotFound();
				}
				else
				{
					Provider = provider;
					_context.Providers.Remove(provider);
					await _context.SaveChangesAsync();
				}
				return RedirectToPage("./Index");
			}

      

    }

}
