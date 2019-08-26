using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
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

    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      try
      {
        return Ok(_repo.CreateKeep(keep));
      }
      catch (Exception e)
      {
        return BadRequest("Incorrect Data");
      }
    }

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
  }
}
