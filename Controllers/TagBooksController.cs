using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class TagBooksController : ControllerBase
  {
    private readonly TagBooksService _tbs;

    public TagBooksController(TagBooksService tbs)
    {
      _tbs = tbs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<TagBook>> GetAll()
    {
      try
      {
        return Ok(_tbs.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    // public ActionResult<IEnumerable<TagBook>> GetById(int id)
    // {
    //   return _tbs.GetById(id);
    // }
    [HttpPost]
    public ActionResult<TagBook> Create([FromBody] TagBook newTagBook)
    {
      try
      {
        return Ok(_tbs.Create(newTagBook));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_tbs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}