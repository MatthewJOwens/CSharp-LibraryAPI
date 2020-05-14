using System;
using System.Collections.Generic;
using LibraryAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI
{
  [ApiController]
  [Route("/api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
      try
      {
        return Ok(FakeDB.Books);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{bookId}")]
    public ActionResult<Book> GetBook(string bookId)
    {
      try
      {
        Book foundBook = FakeDB.Books.find(b => b.id == bookId);
        if (foundBook == null)
        {
          throw new Exception("Book not found");
        }
        return Ok(foundBook);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        FakeDB.Books.Add(newBook);
        return Created($"api/books/{newBook.Id}", newBook);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Edit(string id, [FromBody] Book updatedBook)
    {
      try
      {
        Book bookToUpdate = FakeDB.Books.Find(b => b.id == id);
        if (bookToUpdate == null)
        {
          throw new Exception("Invalid ID");
        }
        //NOTE if this was not 'required'
        bookToUpdate.Title = updatedBook.Title == null ? bookToUpdate.Title : updatedBook.Title;
        bookToUpdate.Description = updatedBook.Description == null ? bookToUpdate.Description : updatedBook.Description;
        bookToUpdate.Author = updatedBook.Author == null ? bookToUpdate.Author : updatedBook.Author;
        //NOTE this says it will always be false because bool can't be null, but what is it if it's not included and not required?
        bookToUpdate.Available = updatedBook.Available == null ? bookToUpdate.Available : updatedBook.Available;
        return Ok(bookToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Book bookToDelete = FakeDB.Books.Find(b => b.Id == id);
        if (bookToDelete == null)
        {
          throw new Exception("Invalid ID");
        }
        FakeDB.Books.Remove(bookToDelete);
        return Ok("Deleted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}