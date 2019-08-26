using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using keepr.Models;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _repo;

    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetKeeps());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      try
      {
        keep.UserId = HttpContext.User.FindFirstValue("Id"); // THIS IS HOW YOU GET THE ID of the currently logged in user
        return Ok(_repo.CreateKeep(keep));
      }
      catch (Exception e)
      {
        return BadRequest("Incorrect Data");
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _repo.DeleteKeep(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest("Bad request");
      }
    }

    // [Authorize]
    // [HttpGet("{id}")]
    // public ActionResult<IEnumerable<Keep>> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetKeepsByUserId(id));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e.Message);
    //   }
    // }
  }
}
