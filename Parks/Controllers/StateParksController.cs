using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parks.Models;

namespace Parks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private readonly ParksContext _db;
    
    public StateParksController(ParksContext db)
    {
      _db = db;
    }


    // GET api/stateparks?name=[name]
    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get(string name, string location, string description)
    {
      var query = from p in _db.StateParks select p;
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (location != null)
      {
        query = query.Where(entry => entry.Location.Contains(location));
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description.Contains(description));
      }

      return query.ToList();
    }

    // GET api/stateparks/[int]
    [HttpGet("{id}")]
    public ActionResult<StatePark> Get(int id)
    {
      var statePark = _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
      return statePark;
    }

    // POST api/stateparks
    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

  }
}
