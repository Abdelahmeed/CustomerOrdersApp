using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CustomerOrdersApp.Models;
using CustomerOrdersApp.ViewModels;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                // Redirect based on role
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (await _userManager.IsInRoleAsync(user, "Salesman"))
                {
                    return RedirectToAction("Index", "Orders");
                }
                else if (await _userManager.IsInRoleAsync(user, "Customer"))
                {
                    return RedirectToAction("Index", "CustomerOrders");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
