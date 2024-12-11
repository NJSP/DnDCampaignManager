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
            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index", new { campaignId = character.CampaignId });
        }
        var campaigns = _context.Campaigns.ToList();
        ViewBag.Campaigns = new SelectList(campaigns, "Id", "Title");
        var characters = _context.Characters.ToList(); // Fetch characters from the database
        return View("Index", characters);
    }
}