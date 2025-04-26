using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JugadoresFutbolPeruano.Data;
using JugadoresFutbolPeruano.Models;

namespace JugadoresFutbolPeruano.Controllers
{
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
            // CORREGIDO: "Id" en lugar de "TeamId"
            ViewBag.Teams = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player, int teamId)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                var assignment = new Assignment
                {
                    PlayerId = player.Id,
                    TeamId = teamId
                };

                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Teams = new SelectList(_context.Teams, "Id", "Name");
            return View(player);
        }
    }
}
