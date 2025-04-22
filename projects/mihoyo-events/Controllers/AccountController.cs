[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, 
            model.Password, model.RememberMe, lockoutOnFailure: false);
        
        if (result.Succeeded)
        {
            return RedirectToLocal(returnUrl);
        }
    }

    [Authorize(Roles = "Admin")]
    public IActionResult AdminDashboard()
    {
        return View();
    }
}