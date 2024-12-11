public class CampaignViewModel
{
    public IEnumerable<Campaign> Campaigns { get; set; }
    public Campaign NewCampaign { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CharactersCount { get; set; }
    public CampaignViewModel()
    {
        Campaigns = new List<Campaign>();
        NewCampaign = new Campaign();
    }

  



}
