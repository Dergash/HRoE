using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using HMM3;
using System.Web.Http.Cors;

namespace HROE.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MapsController : ApiController
    {

        public String Maps = System.Web.Hosting.HostingEnvironment.MapPath("~/Maps/");

        // [Route("{id}/name"])
        [Route("parse")]
        public Map getName(String MapName = "[SoD - RoE] ConfluxHero.h3m")
        {
            Map Test = ParseMap();
            return Test;
        }

        private Map ParseMap()
        {
            byte[] Source = File.ReadAllBytes(Maps + "[SoD-RoE] ConfluxHero.h3m");
            return new Map(Source);
        }
        
    }
}
