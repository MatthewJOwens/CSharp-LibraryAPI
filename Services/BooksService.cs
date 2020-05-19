using System;
using System.Collections.Generic;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
  public class BooksService
  {
    private readonly BooksRepository _repo;
    public BooksService(BooksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Book> GetAll()
    {
      return _repo.GetAll();
    }

    public Book GetById(int bookId)
    {
      return _repo.GetById(bookId);
    }

    internal Book Add(Book newBook)
    {
      return _repo.Add(newBook);
    }

    internal bool Delete(int id)
    {
      Book foundBook = GetById(id);
      if (foundBook == null)
      {
        throw new Exception("Book not found.");
      }
      return _repo.Delete(id);
    }

    internal Book Update(int id, Book updatedBook)
    {
      Book bookToUpdate = GetById(id);
      if (bookToUpdate == null)
      {
        throw new Exception("Invalid ID");
      }
      bookToUpdate.Available = updatedBook.Available;
      bookToUpdate.Title = updatedBook.Title;
      bookToUpdate.Description = updatedBook.Description;
      bookToUpdate.Author = updatedBook.Author;
      return _repo.Update(bookToUpdate);
    }
  }
}