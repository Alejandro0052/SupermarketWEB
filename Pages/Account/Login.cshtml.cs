using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Security.Claims;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel

    {
        private readonly SupermarketContext _context;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Busca un usuario con el correo electrónico especificado
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email);

            if (user != null && user.Password == User.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email,User.Email),
                };
                //asociando los claims creados al nombre de una cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //se agrega la identidad crada al ClaimPrincipal de la apliacacion
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                //registro exitoso y se crea la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/index");
            }
            ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos.");
            return Page();
        }

    }
}
