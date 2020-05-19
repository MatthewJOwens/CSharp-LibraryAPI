using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI
{
  public class Book
  {
    public Book(string title, string author, string descrition, int id)
    {
      Title = title;
      Author = author;
      Available = true;
      Description = descrition;
      Id = id;
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
    public int Id { get; set; }
  }
}