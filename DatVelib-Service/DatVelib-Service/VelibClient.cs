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

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string Address1 = "81 Chemin des Poissonniers grasse";
            string Address2 = "Polytech Sophia Nice";
            AddressesProcess ap = new AddressesProcess(Address1, Address2);
            Console.WriteLine(ap.add1.Latitude + " " + ap.add1.Longitude);
            Console.WriteLine(ap.add2.Latitude + " " + ap.add2.Longitude);
            Console.WriteLine(ap.add1.GetDistanceTo(ap.add2));
            VelibProcess vp = new VelibProcess();
            Console.WriteLine(vp.FindBestVelibs(ap.add1, ap.add2));
        }
    }
}
