public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Character> Characters { get; set; } = new List<Character>(); // Navigation property
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}