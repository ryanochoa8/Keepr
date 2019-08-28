using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeep AddKeepIdToVaultId(VaultKeep vaultKeep) //NOTE "Can Create Vault Keep"
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }

    internal IEnumerable<VaultKeep> GetVaultKeepsByVaultId(int VaultId, string UserId) //NOTE "Can Get Vault Keeps"
    {
      string query = @"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId)
      ";
      return _db.Query<VaultKeep>(query, new { VaultId, UserId });
    }

    public VaultKeep DeleteVaultKeep(VaultKeep vaultKeep) //NOTE "Can Delete Vault Keep"
    {
      int id = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }
  }
}