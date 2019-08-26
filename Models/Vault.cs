// id int NOT NULL AUTO_INCREMENT,
// name VARCHAR(20) NOT NULL,
// description VARCHAR(255) NOT NULL,
// userId VARCHAR(255),

namespace Keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
  }
}