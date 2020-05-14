using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI
{
  public class Book
  {
    public Book(string title, string author, string descrition)
    {
      Title = title;
      Author = author;
      Available = true;
      Description = descrition;
      Id = Guid.NewGuid().ToString();
    }
    //Properties

    [Required]
    [MinLength(5)]
    public string Title { get; set; }

    [Required]
    [MaxLength(140)]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    // [Range(1, 100)]
    public bool Available { get; set; }
    public string Id { get; set; }
  }
}