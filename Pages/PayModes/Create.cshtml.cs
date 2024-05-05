using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class CreateModel : PageModel
    {
		/* public void OnGet()
		 {
		 }*/
		private readonly SupermarketContext _context;
		public CreateModel(SupermarketContext context)
		{

			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public PayMode PayMode { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.PayModes == null || PayMode == null)
			{
				return Page();
			}
			// ERROR AQUI _context.PayModes.Add(PayMode);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}

	}
}
