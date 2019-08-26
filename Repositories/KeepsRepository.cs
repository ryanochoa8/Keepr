using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;
using Keepr.Models;
using Microsoft.AspNetCore.Http;

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
    // public IEnumerable<Keep> GetKeepsByUserId(int userId)
    // {
    //   return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    // }
    // internal User GetUserById(string id)
    // {
    //   var user = _db.Query<User>(@"
    //   SELECT * FROM users WHERE id = @id
    //   ", new { id }).FirstOrDefault();
    //   if (user == null) { throw new Exception("Invalid UserId"); }
    //   return user;
    // }
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