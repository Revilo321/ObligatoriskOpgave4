using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatoriskOpgave4.Model;

namespace ObligatoriskOpgave4.Controllers
{
    

    [Route("fans")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {

        private static readonly List<FanOutPut> fans = new List<FanOutPut>()
        {
            new FanOutPut(1,"DR24",25,50),
            new FanOutPut(2,"DR25",17,35),
            new FanOutPut(3,"DR26",20,40),
            new FanOutPut(4,"DR27",23,66),
            new FanOutPut(5,"DR28",15,30)
        };

        /// <summary>
        /// Returnerer alle fans
        /// </summary>
        /// <returns></returns>
        // GET: fans
        [HttpGet]
        public IEnumerable<FanOutPut> Get()
        {
            return fans;
        }

        /// <summary>
        /// Returnerer fan på id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: fans/5
        [HttpGet("{id}", Name = "Get")]
        public FanOutPut Get(int id)
        {
            return fans.Find(x => x.Id == id);
        }

        /// <summary>
        /// Opretter nyt fan objekt
        /// </summary>
        /// <param name="value"></param>
        // POST: fans
        [HttpPost]
        public void Post([FromBody] FanOutPut value)
        {
            fans.Add(value);   
        }

        /// <summary>
        /// Opdaterer et allerede eksisterende objekt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: fans/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutPut value)
        {
            FanOutPut fan = Get(id);
            if (fan != null)
            {
                fan.Id = value.Id;
                fan.Name = value.Name;
                fan.Temp = value.Temp;
                fan.Fugt = value.Fugt;
            }

        }

        /// <summary>
        /// Sletter et objekt
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutPut fan = Get(id);
            fans.Remove(fan);
        }
    }
}
