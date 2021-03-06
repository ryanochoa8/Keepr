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

    [Authorize]
    [HttpPost] //NOTE "Can Create Keep"
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

    [HttpGet] //NOTE "Can Get Public Keeps
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
    [HttpGet("user")] //NOTE "Can Get keeps by User"
    public ActionResult<IEnumerable<Keep>> Get(string UserId)
    {
      try
      {
        UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepsByUserId(UserId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")] //NOTE "Can Get Keep By keep Id"
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_repo.GetKeepById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")] //NOTE "Can Edit Keep"
    public ActionResult<string> Put(int id, [FromBody] Keep keep)
    {
      try
      {
        _repo.UpdateByID(keep);
        return Ok("Update Successful");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")] //NOTE "Can Delete Keep"
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
  }
}
