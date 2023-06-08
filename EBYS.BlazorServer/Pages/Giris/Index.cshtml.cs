using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Kullanici;
using System.ComponentModel.DataAnnotations;

namespace EBYS.BlazorServer.Pages.Giris
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Kullanýcý adý alaný gereklidir.")]
        public string KullaniciAdi { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Parola alaný gereklidir.")]
        [MinLength(5, ErrorMessage = "Parola minimum 5 karakter olmalýdýr")]
        public string Sifre { get; set; }

        private readonly IKullaniciService _kullaniciService;

        public IndexModel(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
			//HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationScheme);

		}
        
		public void OnGet()
        {
			//if (HttpContext.User != null)
			//{
			//    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//    return Redirect("/giris");
			//}
			//return Page();
		}

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var girisDto = new GirisDto
            {
                KullaniciAdi = this.KullaniciAdi,
                Sifre = this.Sifre
            };

            var user = await _kullaniciService.Giris(girisDto);

            if (user == null)
            {
                ModelState.AddModelError("notfound", "Kullanýcý bulunamadý");

                return Page();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Token));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(user.Role)));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

            return Redirect("/personel");
        }
    }
}
