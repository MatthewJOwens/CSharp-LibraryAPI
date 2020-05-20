using System;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
  public class TagBooksService
  {
    private readonly TagBooksRepository _repo;
    public TagBooksService(TagBooksRepository repo)
    {
      _repo = repo;
    }
    internal TagBook Create(TagBook newTagBook)
    {
      return _repo.Create(newTagBook);
    }

    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted successfully.";
      }
      throw new Exception("Invalid tag or unable to delete for some reason");
    }
  }
}