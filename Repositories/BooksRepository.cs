using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace LibraryAPI.Repositories
{
  public class BooksRepository
  {
    private readonly IDbConnection _db;
    public BooksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Book> GetAll()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }

    internal Book GetById(int id)
    {
      string sql = "SELECT * FROM books WHERE id = @Id";
      return _db.QueryFirstOrDefault<Book>(sql, new { id });
    }

    internal Book Add(Book newBook)
    {
      string sql = @"
      INSERT INTO books 
      (title, author, description, available)
      VALUES
      (@Title, @Author, @Description, @Available);
      SELECT LAST_INSERT_ID()";
      newBook.Id = _db.ExecuteScalar<int>(sql, newBook);
      return newBook;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM books WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal Book Update(Book updatedBook)
    {
      string sql = @"
      UPDATE books
      SET title = @Title, author = @Author, available = @Available
      WHERE id = @Id";
      int affectedRows = _db.Execute(sql, updatedBook);
      if (affectedRows == 1)
      {
        return updatedBook;
      }
      else
      {
        throw new Exception("Error updating book.");
      }
    }
  }
}