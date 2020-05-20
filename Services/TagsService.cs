using System;
using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
  public class TagsService
  {
    private readonly TagsRepository _repo;
    public TagsService(TagsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Tag> GetAll()
    {
      return _repo.GetAll();
    }
    public Tag GetById(int id)
    {
      return _repo.GetById(id);
    }
    internal Tag Create(Tag newTag)
    {
      return _repo.Create(newTag);
    }

    internal bool Delete(int id)
    {
      Tag foundTag = GetById(id);
      if (foundTag == null)
      {
        throw new Exception("Tag not found.");
      }
      return _repo.Delete(id);
    }
  }
}