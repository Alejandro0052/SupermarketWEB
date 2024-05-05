using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class EditModel : PageModel
    {
		/*public void OnGet()
        {
        }*/
		private readonly SupermarketContext _context;

		public EditModel(SupermarketContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Provider Provider { get; set; } = default;

//ERRORRRR ACOMODAR ERROR
	/*	public async Task<IActionResult> OnGetAsync(int? id)
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
			Provider = provider;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Provider).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (!ProviderExists(Provider.Id))
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

		private bool ProviderExists(int id)
		{
			return (_context.Providers?.Any(e => e.Id == id)).GetValueOrDefault();
		} 
		*/
	}
}
