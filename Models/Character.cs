using System.ComponentModel.DataAnnotations;

public class Character
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; } // PC or NPC
    public int CampaignId { get; set; } // Foreign key
    [Required]
    public Campaign Campaign { get; set; } // Navigation property

    public Character() => CampaignId = 1; // Set a default CampaignId if necessary
}
