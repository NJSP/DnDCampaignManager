using System.ComponentModel.DataAnnotations;


public class Campaign
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public List<Character> Characters { get; set; } = new List<Character>(); // Navigation property
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}