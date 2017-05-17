using AdressServiceProcess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VelibServiceProcess;

namespace Dat_VelibService
{
    public class DatVelibService
    {
        static public List<string> GetClosestVelibs(string Address1, string Address2)
        {
            AddressesProcess ap = new AddressesProcess(Address1, Address2);
            Console.WriteLine(ap.add1.Latitude + " " + ap.add1.Longitude);
            Console.WriteLine(ap.add2.Latitude + " " + ap.add2.Longitude);
            Console.WriteLine(ap.add1.GetDistanceTo(ap.add2));
            VelibProcess vp = new VelibProcess();
            return vp.FindBestVelibs(ap.add1,ap.add2);
        }
    }
}
