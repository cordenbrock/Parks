using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{

  [Route("api/[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  public class StateParksV1Controller : ControllerBase
  {
    private readonly ParksContext _db;
    
    public StateParksV1Controller(ParksContext db)
    {
      _db = db;
    }


    // GET api/stateparks
    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get()
    {
      var query = _db.StateParks.AsQueryable();
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

    // PUT api/stateparks/[int]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
      statePark.StateParkId = id;
      _db.Entry(statePark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/stateparks/[int]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var statePark = _db.StateParks.FirstOrDefault(entry => entry.StateParkId ==  id);
      _db.Remove(statePark);
      _db.SaveChanges();
    }
  }

  [ApiController]
  [ApiVersion("2.0")]
  [Route("api/[controller]")]

    public class StateParksV2Controller : ControllerBase
    {
    private readonly ParksContext _db;
    
    public StateParksV2Controller(ParksContext db)
    {
      _db = db;
    }

    // SEARCH api/stateparks?search=[string]
    [HttpGet("search")]
    public ActionResult<IEnumerable<StatePark>> Search(string name, string location, string description)
    {
      var query = _db.StateParks.AsQueryable();
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
  }
}
