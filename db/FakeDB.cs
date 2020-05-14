using System.Collections.Generic;

namespace LibraryAPI.DB
{
  public static class FakeDB
  {
    public static List<Book> Books = new List<Book>()
    {
      new Book("Where the Sidewalk Ends", "Shel Silverstein", "A book of poems."),
      new Book("Name of the Wind", "Patrick Rothfuss", "10th Anniversary Edition."),
      new Book("House of Chains", "Steven Erikson", "Book 7 of the Malazan Book of the Fallen series"),
      new Book("Gardens of the Moon", "Steven Erikson", "Book 1 of the Malazan Book of the Fallen series")
    };
  }
}