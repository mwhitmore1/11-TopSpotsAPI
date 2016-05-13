using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class TopSpotsController : ApiController
    {
        public Spot[] GetName()
        {
            Spot[] spots = JsonGrabber.GetJson();
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent("test response")
            };
            return spots;
        }
        
        public Spot Post(Spot spot)
        {
            // Create new isntance of "Spot" class to be passed to the JsonGrabber for processing.
            return JsonGrabber.AddSpot(spot);
        }
        
    }
}
