using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using WebAppPruebaTecnica.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppPruebaTecnica.Controllers
{
    public class AccountController : Controller
    {
        private readonly SalesDbContext _context;
        public AccountController(SalesDbContext context)
        {
            _context = context;
        }

        // GET: AccountController
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            return View();
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            try
            {
                var user = _context.Users.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();

                if (user is not null)
                {
                    var role = _context.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();

                    var claims = new List
                <Claim>
                {
                        new Claim(ClaimTypes.Email, login.Email),
                        new Claim(ClaimTypes.Role, role.Name),
                        new Claim(ClaimTypes.UserData, user.Id.ToString())
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );


                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
            }

            return View(nameof(Index), login);
        }
    }
}
