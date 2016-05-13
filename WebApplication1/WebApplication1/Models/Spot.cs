using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Spot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float[] Location { get; set; }
    }
}