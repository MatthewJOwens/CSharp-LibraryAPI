using System.Collections.Generic;
using System.Data;
using Dapper;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
  public class TagBooksRepository
  {
    private readonly IDbConnection _db;
    public TagBooksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<TagBook> GetAll()
    {
      string sql = @"
      SELECT *
      FROM tagbooks";
      return _db.Query<TagBook>(sql);
    }

    internal TagBook Create(TagBook newTagBook)
    {
      string sql = @"
        INSERT INTO tagbooks
        (bookId, tagID)
        VALUES
        (@BookId, @TagId);
        SELECT LAST_INSERT_ID()";
      newTagBook.Id = _db.ExecuteScalar<int>(sql, newTagBook);
      return newTagBook;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM tagbooks WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}