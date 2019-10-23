using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;

namespace RealEstate.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		[HttpGet("login", Name = "ShowLogin")]
		public IActionResult Login()
		{
			var vm = new AccountViewModel {
				ShowMasterHeader = false,
			};

			return View(vm);
		}

		[HttpPost("login")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
		{
			if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
			{
				return RedirectToAction("Login", new AccountViewModel());
			}

			// For demo purposes we use a hardcoded username and password.
			if (userName.ToLowerInvariant() == "admin" && password == "password")
			{
				const string Issuer = "https://realestate.com";
				var claims = new List<Claim> {
					new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer)
				};

				var userIdentity = new ClaimsIdentity("NotSoSuperSecureLogin");
				userIdentity.AddClaims(claims);
				var userPrincipal = new ClaimsPrincipal(userIdentity);

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					userPrincipal,
					new AuthenticationProperties {
						ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
						IsPersistent = false,
						AllowRefresh = false
					});

				return RedirectToLocal(returnUrl);
			}

			return View(new AccountViewModel());
		}

		[HttpGet("logout", Name = "Logout")]
		public IActionResult Logout()
		{
			_ = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}


		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public IActionResult Forbidden()
		{
			return View(new AccountViewModel());
		}
	}
}