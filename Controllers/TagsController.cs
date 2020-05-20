using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class TagsController : ControllerBase
  {
    private readonly TagsService _ts;
    private readonly BooksService _bs;
    public TagsController(TagsService ts)
    {
      _ts = ts;
    }
    [HttpGet]

    public ActionResult<IEnumerable<Tag>> GetAll()
    {
      try
      {
        return Ok(_ts.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/books")]
    public ActionResult<IEnumerable<TagBookViewModel>> GetBooksByTagId(int id)
    {
      try
      {
        //NOTE We could go request to get the tag, and make sure it exists right here by using the tag service.
        return Ok(_bs.GetBooksByTagId(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPost]
    public ActionResult<Tag> Create([FromBody] Tag newTag)
    {
      try
      {
        return Ok(_ts.Create(newTag));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{id")]
    public ActionResult<Book> Delete(int id)
    {
      try
      {
        return Ok(_ts.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}