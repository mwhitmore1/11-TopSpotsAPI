using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class JsonGrabber
    {
        private static string fileName = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/topspots2.JSON");

        public static Spot[] GetJson()
        {
            Spot[] spots;

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                spots = js.Deserialize<Spot[]>(json);
            }

            return spots;
        }

        // used to add a new spot to the JSON file.
        public static Spot AddSpot(Spot spot)
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Formatting = Formatting.Indented;
            ser.TypeNameHandling = TypeNameHandling.Auto;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                Encoding enc = new UTF8Encoding(false);

                using (StreamWriter sw = new StreamWriter(fs, enc))
                using (JsonTextWriter jtw = new JsonTextWriter(sw))
                {
                    fs.Seek(-Encoding.UTF8.GetByteCount("}"), SeekOrigin.End);
                    sw.Write(",");
                    sw.Flush();
                    ser.Serialize(jtw, spot);
                    sw.Write(']');
                }
            }
            return spot;
        }
        
    }
}