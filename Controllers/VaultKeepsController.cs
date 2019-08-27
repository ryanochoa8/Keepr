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

    [HttpPost]
    public ActionResult<VaultKeep> AddKeepToVault([FromBody] VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_repo.AddKeepIdToVaultId(vaultKeep));
    }

    [HttpGet("{VaultId}")]
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
  }
}