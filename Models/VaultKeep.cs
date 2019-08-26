// id int NOT NULL AUTO_INCREMENT,
// vaultId int NOT NULL,
// keepId int NOT NULL,
// userId VARCHAR(255) NOT NULL,

namespace Keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
  }
}