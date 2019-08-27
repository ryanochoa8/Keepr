using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;
using Keepr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

    // NOTE tried userId, FromBody, keep keep, and id. No clue how to do this
    public IEnumerable<Keep> GetKeepsByUserId(string UserId)
    {
      try
      {
        return _db.Query<Keep>(@"SELECT * FROM keeps WHERE UserId = @UserId", new { UserId });
      }
      catch (Exception)
      {

        throw new Exception("No keeps found on this user " + UserId);
      }
    }
    public Keep GetKeepById(int id)
    {
      try
      {
        return _db.QuerySingle<Keep>(@"SELECT * FROM keeps WHERE id = @id", new { id });
      }
      catch (Exception)
      {

        throw new Exception("No keep found at this id: " + id);
      }
    }
    public Keep CreateKeep(Keep keep)
    {

      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, description, userId, img, isPrivate)
      VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;
    }
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      return success > 0;
    }

  }
}