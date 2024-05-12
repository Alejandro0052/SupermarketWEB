using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketWEB.Pages.PayModes
{
	[Authorize]
	public class EditModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
