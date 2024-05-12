using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
	public class DeleteModel : PageModel
	{
		private readonly SupermarketContext _context;
		public DeleteModel(SupermarketContext context)
		{
			_context = context;
		}
		[BindProperty]

		public PayMode PayMode { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.PayModes == null)
			{
				return NotFound();
			}
			var paymode = await _context.PayModes.FirstOrDefaultAsync(m => m.Id == id);
			if (paymode == null)
			{
				return NotFound();
			}
			else
			{
				PayMode = paymode;
				_context.PayModes.Remove(paymode);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
