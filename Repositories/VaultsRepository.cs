using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault CreateVault(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (id, name, description, userId)
      VALUES (@Id, @Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ", vault);
      vault.Id = id;
      return vault;
    }

    public bool DeleteVault(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}