using System;
using System.Collections.Generic;
using LibraryAPI.Models;
using Dapper;
using System.Data;

namespace LibraryAPI.Repositories
{
  public class TagsRepository
  {
    private readonly IDbConnection _db;
    public TagsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Tag> GetAll()
    {
      string sql = "SELECT * FROM tags";
      return _db.Query<Tag>(sql);
    }

    internal Tag GetById(int id)
    {
      string sql = "SELECT * FROM tags WHERE id = @Id";
      return _db.QueryFirstOrDefault<Tag>(sql, new { id });
    }

    internal Tag Create(Tag newTag)
    {
      string sql = @"
      INSERT INTO tags
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID()";
      newTag.Id = _db.ExecuteScalar<int>(sql, newTag);
      return newTag;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM tags WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}