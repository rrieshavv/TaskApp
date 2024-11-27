using Application.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.Claims;
using TaskApp.Services.Models;
using TaskApp.Services.Services.User;

namespace Application.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}


		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View();
				}

				var loginResponse = await _userService.Login(loginModel.Email, loginModel.Password);

				if (loginResponse.Code == 0)
				{
					// login successfull

					var claims = new List<Claim>
				{
					 new Claim(ClaimTypes.Name, loginResponse.Email)
				};

					var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

					var authProperties = new AuthenticationProperties
					{
						//IsPersistent = true, // Keep cookie across browser sessions
						ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
					};

					await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);
					TempData["loginSuccess"] = loginResponse.Message;
					return RedirectToAction("Index", "Home");
				}
				else
				{
					TempData["error"] = loginResponse.Message;
					return View();
				}
			}
			catch (Exception ex)
			{
				TempData["error"] = "Error occured while logging you in.";
				return View();
			}
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel registerModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			};

			var requestModel = new UserRegisterModel
			{
				Email = registerModel.Email,
				Password = registerModel.Password1,
				Firstname = registerModel.Firstname,
				Lastname = registerModel.Lastname,
				Middlename = registerModel.Middlename,
				Phone = registerModel.MobileNumber,
				Country = registerModel.Country,
				Address = registerModel.Address,
			};

			var registerResponse = await _userService.Register(requestModel);

			if(registerResponse.Code == 0)
			{
				TempData["success"] = registerResponse.Message;
				return RedirectToAction("login");
			}
			else
			{
				TempData["error"] = registerResponse.Message;
			}

			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("CookieAuth");
			TempData["success"] = "You have been logged out.";
			return RedirectToAction("Login", "User");
		}
	}
}
