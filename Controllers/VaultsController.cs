using System;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }

    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault vault)
    {
      try
      {
        return Ok(_repo.CreateVault(vault));
      }
      catch (Exception e)
      {
        return BadRequest("Incorrect data");
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _repo.DeleteVault(id);
        return Ok("Successfully Deleted");
      }
      catch (System.Exception)
      {
        return BadRequest("Bad request");
      }
    }
  }
}