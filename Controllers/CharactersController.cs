using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DnDCampaignManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class CharactersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CharactersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var campaigns = _context.Campaigns.ToList(); // Fetch campaigns from the database
        ViewBag.Campaigns = new SelectList(campaigns, "Id", "Title"); // Pass campaigns to the view
        var characters = _context.Characters.ToList(); // Fetch characters from the database
        ViewBag.CampaignId = 0; // Set a default campaign ID if needed
        return View(characters);
    }

    [HttpPost]
    public IActionResult Create(Character character)
    {
        if (ModelState.IsValid)
        {
            if (character.CampaignId == 0)
            {
                ModelState.AddModelError("CampaignId", "CampaignId is required.");
                return View(character);
            }

            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index", new { Id = character.CampaignId });
        }
        var campaigns = _context.Campaigns.ToList();
        ViewBag.Campaigns = _context.Campaigns
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            })
            .ToList();
        var characters = _context.Characters.ToList(); // Fetch characters from the database
        return View("Index", characters);
    }
}