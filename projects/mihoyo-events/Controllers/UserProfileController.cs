public class UserProfileController : Controller
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var model = new UserProfileViewModel
        {
            Username = user.UserName,
            Email = user.Email,
            JoinedEvents = _context.UserEvents
                .Include(ue => ue.Event)
                .Where(ue => ue.UserId == user.Id)
                .ToList()
        };
        return View(model);
    }
}