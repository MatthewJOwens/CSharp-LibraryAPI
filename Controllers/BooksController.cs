using System;
using System.Collections.Generic;
using LibraryAPI.DB;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI
{
  [ApiController]
  [Route("/api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly BooksService _bs;

    public BooksController(BooksService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
      try
      {
        Book foundBook = _bs.GetById(id);
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
        return Ok(_bs.Add(newBook));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Edit(int id, [FromBody] Book updatedBook)
    {
      try
      {

        // //NOTE if this was not 'required'
        // bookToUpdate.Title = updatedBook.Title == null ? bookToUpdate.Title : updatedBook.Title;
        // bookToUpdate.Description = updatedBook.Description == null ? bookToUpdate.Description : updatedBook.Description;
        // bookToUpdate.Author = updatedBook.Author == null ? bookToUpdate.Author : updatedBook.Author;
        // //NOTE this says it will always be false because bool can't be null, but what is it if it's not included and not required?
        // bookToUpdate.Available = updatedBook.Available == null ? bookToUpdate.Available : updatedBook.Available;
        return Ok(_bs.Update(id, updatedBook));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Book> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}