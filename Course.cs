using System.ComponentModel.DataAnnotations;

public class Course
{
    public int CourseId { get; set; }
        
    [Required]
    public string Title { get; set; }
        
    public string Description { get; set; }
        
    [Required]
    public decimal Price { get; set; }
}