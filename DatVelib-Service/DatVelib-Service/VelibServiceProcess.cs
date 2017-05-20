using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace VelibServiceProcess
{
    public class Station
    {
        public string name { get; set; }
        public string addr { get; set; }
        public string number { get; set; }
        public GeoCoordinate geo { get; set; }

        public Station(string name,string addr, string number, GeoCoordinate geo)
        {
            this.name = name;
            this.addr = addr;
            this.number = number;
            this.geo = geo;
        }
    }

    public class VelibProcess
    {
        public List<Station> stations { get; set; }

        public VelibProcess()
        {
            stations = new List<Station>();
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            // Get Response from the Service 
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();


            // Open the stream using a StreamReader for easy access and put it into a string
            StreamReader reader = new StreamReader(dataStream); // Read the content.
            string responseFromServer = reader.ReadToEnd(); // Put it in a String 

            // Parse the response and put the entries in XmlNodeList 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            XmlNodeList elemList = doc.GetElementsByTagName("marker");

            for (int i = 0; i < elemList.Count; i++)
            {
                double lat_station = double.Parse(elemList[i].Attributes["lat"].Value, CultureInfo.InvariantCulture);
                double lng_station = double.Parse(elemList[i].Attributes["lng"].Value, CultureInfo.InvariantCulture);
                GeoCoordinate tmp = new GeoCoordinate(lat_station, lng_station);
                stations.Add(new Station(elemList[i].Attributes["name"].Value,
                    elemList[i].Attributes["address"].Value,
                    elemList[i].Attributes["number"].Value,
                    tmp));
            }


            response.Close();
            reader.Close();
        }

        static string FindClosestAvailable(List<Station> stations, string type)
        {
            foreach (Station station in stations)
            {
                //Test if Velib has places or is full
                WebRequest request_for_data = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + station.number);
                // Get Response 
                WebResponse response_for_data = request_for_data.GetResponse();

                // Open the stream using a StreamReader for easy access and put it into a string
                Stream dataStream_for_data = response_for_data.GetResponseStream();
                StreamReader reader_for_data = new StreamReader(dataStream_for_data); // Read the content.
                string responseFromServer_for_data = reader_for_data.ReadToEnd(); // Put it in a String

                // Parse the response and put the entries in XmlNodeList 
                XmlDocument doc_for_data = new XmlDocument();
                doc_for_data.LoadXml(responseFromServer_for_data);
                XmlNodeList elemList_for_data = doc_for_data.GetElementsByTagName(type);

                // Display the result 
                bool available = (Convert.ToInt16(doc_for_data.GetElementsByTagName(type)[0].FirstChild.Value) != 0);
                reader_for_data.Close();
                response_for_data.Close();
                if (available)
                {
                    return station.addr;
                }
            }
            return "";
        }

        public List<string> FindBestVelibs(GeoCoordinate add1, GeoCoordinate add2)
        {
            List<Station> stations_start = stations.OrderBy(o => o.geo.GetDistanceTo(add1)).ToList();
            List<Station> stations_dest = stations.OrderBy(o => o.geo.GetDistanceTo(add2)).ToList();

            List<string> velibs = new List<string>();
            velibs.Add(FindClosestAvailable(stations_start, "available"));
            velibs.Add(FindClosestAvailable(stations_dest, "free"));
            return velibs;
        }
    }
}
