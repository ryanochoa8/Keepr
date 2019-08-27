using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Vault> GetAction(int id)
    {
      try
      {
        return Ok(_repo.GetVaultById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //NOTE HttpGet("user") is not on the test
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get(string UserId)
    {
      try
      {
        UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetVaultsByUserId(UserId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault vault)
    {
      try
      {
        vault.UserId = HttpContext.User.FindFirstValue("Id"); // THIS IS HOW YOU GET THE ID of the currently logged in user
        return Ok(_repo.CreateVault(vault));
      }
      catch (Exception e)
      {
        return BadRequest("Incorrect data");
      }
    }

    [Authorize]
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