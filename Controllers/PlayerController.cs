public class PlayerController : Controller
{
    private readonly AppDbContext _context;

    public PlayerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Teams = new SelectList(_context.Teams, "TeamId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Player player)
    {
        if (ModelState.IsValid)
        {
            _context.Add(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); // O cualquier otra vista
        }

        ViewBag.Teams = new SelectList(_context.Teams, "TeamId", "Name");
        return View(player);
    }
}
