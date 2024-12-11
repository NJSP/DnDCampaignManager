public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // PC or NPC
    public int CampaignId { get; set; } // Foreign key
    public Campaign Campaign { get; set; } // Navigation property
}
