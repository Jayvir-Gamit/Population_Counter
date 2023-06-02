using PopulationCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PopulationCounter.Controllers
{
    public class SecondApiController : ApiController
    {
        populationEntities1 db1 = new populationEntities1();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamiliesByPincode(int pin)
        {
            List<Family> obj = db1.Families.Where(model => model.pincode == pin).ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamiliesByVillage(string vil)
        {
            List<Family> obj = db1.Families.Where(model => model.village == vil).ToList();
            return Ok(obj);
        }
    }
}
