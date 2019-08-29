using System;
using System.Collections.Generic;
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
    public Vault CreateVault(Vault vault) //NOTE "Can Create Vault"
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (id, name, description, userId)
      VALUES (@Id, @Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ", vault);
      vault.Id = id;
      return vault;
    }
    public IEnumerable<Vault> GetVaultsByUserId(string UserId) //NOTE "Can Get User Vaults"
    {
      try
      {
        return _db.Query<Vault>(@"SELECT * FROM vaults WHERE UserId = @UserId", new { UserId });
      }
      catch (Exception)
      {

        throw new Exception("No vault found at this id: " + UserId);
      }
    }

    public Vault GetVaultById(int id) //NOTE "Can Get Vault By Id"
    {
      try
      {
        return _db.QuerySingle<Vault>(@"SELECT * FROM vaults WHERE id = @id", new { id });
      }
      catch (Exception)
      {

        throw new Exception("No vault found at this id: " + id);
      }
    }


    public bool DeleteVault(int id) //NOTE "Can Delete Vault"
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}