public async Task<IActionResult> Index(string searchString, 
    string eventStatus, int? pageNumber)
{
    var events = _context.Events.AsQueryable();

    if (!string.IsNullOrEmpty(searchString))
    {
        events = events.Where(e => 
            e.Title.Contains(searchString) ||
            e.Description.Contains(searchString));
    }

    if (!string.IsNullOrEmpty(eventStatus))
    {
        events = events.Where(e => e.Status == eventStatus);
    }

    int pageSize = 9;
    return View(await PaginatedList<Event>.CreateAsync(
        events.AsNoTracking(), pageNumber ?? 1, pageSize));
}