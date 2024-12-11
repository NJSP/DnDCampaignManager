using Microsoft.AspNetCore.Mvc;
using DnDCampaignManager.Models;
using System.Linq;

public class CampaignsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CampaignsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var campaigns = _context.Campaigns
            .Select(c => new CampaignViewModel
            {
                Id = c.Id,
                Title = c.Title ?? "Default Name", // Provide a default value for NULL
                Description = c.Description,
                CreatedDate = c.CreatedDate,
                CharactersCount = c.Characters.Count
            })
            .ToList();

        var viewModel = new CampaignsIndexViewModel
        {
            Campaigns = campaigns,
            NewCampaign = new CampaignViewModel()
        };

        ViewBag.CampaignId = campaigns.FirstOrDefault()?.Id ?? 0; // Set a default value if no campaigns exist


        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(Campaign campaign)
    {
        if (ModelState.IsValid)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(campaign);
    }
}