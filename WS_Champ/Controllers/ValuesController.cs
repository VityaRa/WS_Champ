using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Champ.Models;
using Newtonsoft.Json;

namespace WS_Champ.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Region> Get()
        {
            List<Region> regionList = new List<Region>();
            regionList = EasyConnection.GetRegionData(regionList, Region.SelectRegionCommand());
            return regionList;
        }

        // GET api/values/5
        public Region Get(int id)
        {
            return EasyConnection.GetRegionDataById(Region.SelectRegionCommand(), id);
        }


        // POST api/values
        public void Post([FromBody] Region value)
        {
            EasyConnection.AddRegion(value.name, value.capital, value.district);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
