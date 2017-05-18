using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatVelib_Service
{
    public class TravelProcess
    {

        public static bool GetTravel(string address1, string address2)
        {//https://maps.googleapis.com/maps/api/directions/json?origin=75%209th%20Ave%20New%20York%2C%20NY&destination=MetLife%20Stadium%201%20MetLife%20Stadium%20Dr%20East%20Rutherford%2C%20NJ%2007073&key=AIzaSyB866tux2Kc4sC-MzRFTYECvFYqDsRsNwg

            ///THIS WORKS !!!!!!
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://maps.googleapis.com/maps/api/directions/json?origin=75%209th%20Ave%20New%20York%2C%20NY&destination=MetLife%20Stadium%201%20MetLife%20Stadium%20Dr%20East%20Rutherford%2C%20NJ%2007073&key=AIzaSyB866tux2Kc4sC-MzRFTYECvFYqDsRsNwg");
                var obj = JObject.Parse(json);
                //var url = (string)obj;
                //le dernier int est à changer pour parcourir

                JToken j = obj["routes"][0]["legs"][0]["steps"][0]["html_instructions"];
                for (int i = 0; j!= null ; i++)
                {
                    //Using the magic trick because the json lib is so cool there's no obvious way to check if soemthing is null
                    try
                    {
                        Console.WriteLine(obj["routes"][0]["legs"][0]["steps"][i]["html_instructions"]);

                    }
                    catch (Exception)
                    {

                        break;
                    }
                }

            }
            return true;
        }
    }
}
