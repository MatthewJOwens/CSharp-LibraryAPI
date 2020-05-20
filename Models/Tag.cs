using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
  public class Tag
  {
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    public int Id { get; set; }
  }


  // NOTE this is for my Many-To-Many table
  public class TagBook
  {
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int TagId { get; set; }
  }
}