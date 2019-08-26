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
      return _db.Query<Keep>("SELECT * FROM keeps");
    }
    public Keep CreateKeep(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (id, name, description, userId, img, isPrivate)
      VALUES (@Id, @Name, @Description, @UserId, @Img, @IsPrivate);
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