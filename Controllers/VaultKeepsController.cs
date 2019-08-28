using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    [HttpPost] //NOTE "Can Create Vault Keep"
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_repo.AddKeepIdToVaultId(vaultKeep));
    }

    [HttpGet("{VaultId}")] //NOTE "Can Get Vault Keeps"
    public ActionResult<IEnumerable<Keep>> Get(int VaultId)
    {
      try
      {
        var UserId = HttpContext.User.FindFirstValue("Id");

        return Ok(_repo.GetVaultKeepsByVaultId(VaultId, UserId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut] //NOTE "Can Delete Vault Keep"
    public ActionResult<VaultKeep> Delete([FromBody] VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_repo.DeleteVaultKeep(vaultKeep));
    }
  }
}