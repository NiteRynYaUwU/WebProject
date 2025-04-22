[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateEvent(EventCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var imageUrl = await ImageOptimizer.OptimizeAndSave(model.ImageFile);
            
            var newEvent = new Event
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = imageUrl,
                EventDate = model.EventDate,
                Location = model.Location,
                Rewards = model.Rewards
            };

            _context.Add(newEvent);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        return View(model);
    }
}