using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class IndexModel : PageModel
    {
		/*public void OnGet()
        {
        }*/
		private readonly SupermarketContext _context;

		public IndexModel(SupermarketContext context)
		{
			_context = context;
		}
		public IList<Provider> Providers { get; set; } = default;

		public async Task OnGetAsync()
		{
			if (_context.Providers != null)
			{
		//FAIL HERE CHECK  Providers = await _context.Providers.ToListAsync();
			}
		}



	}
}
