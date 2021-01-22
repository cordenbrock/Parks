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
  public class NationalParksController : ControllerBase
  {
    private readonly ParksContext _db;
    
    public NationalParksController(ParksContext db)
    {
      _db = db;
    }


    // GET api/nationalparks?name=[name]
    [HttpGet]
    public ActionResult<IEnumerable<NationalPark>> Get(string name, string state, string description)
    {
      var query = from p in _db.NationalParks select p;
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (state != null)
      {
        query = query.Where(entry => entry.State.Contains(state));
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description.Contains(description));
      }

      return query.ToList();
    }

    // GET api/nationalparks/[int]
    [HttpGet("{id}")]
    public ActionResult<NationalPark> Get(int id)
    {
      var nationalPark = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
      return nationalPark;
    }

    // POST api/nationalparks
    [HttpPost]
    public void Post([FromBody] NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      _db.SaveChanges();
    }

    // PUT api/nationalparks/[int]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalPark nationalPark)
    {
      nationalPark.NationalParkId = id;
      _db.Entry(nationalPark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/nationalparks/[int]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var nationalPark = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId ==  id);
      _db.Remove(nationalPark);
      _db.SaveChanges();
    }
  }
}
