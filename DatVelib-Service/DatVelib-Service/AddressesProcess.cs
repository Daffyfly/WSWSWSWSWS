using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Device.Location;

namespace AdressServiceProcess
{

    public class AddressesProcess
    {
        public GeoCoordinate add1 { get; set; }
        public GeoCoordinate add2 { get; set; }

        static GeoCoordinate AddressToLatLng(string Address1)
        {
            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + Address1 + "&sensor=false";
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string responseFromServer = reader.ReadToEnd(); // Put it in a String 

                    // Parse the response and put the entries in XmlNodeList 
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseFromServer);
                    XmlNodeList elemList = doc.GetElementsByTagName("location");

                    double lat = 0;
                    double lng = 0;
                    // browse the XmlNodeList
                    if (elemList.Count != 1)
                        return new GeoCoordinate(0, 0);
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        IEnumerator ienum = elemList[i].GetEnumerator();
                        while (ienum.MoveNext())
                        {
                            XmlNode tmp = (XmlNode)ienum.Current;
                            if (tmp.Name == "lat")
                                lat = double.Parse(tmp.InnerText, CultureInfo.InvariantCulture);
                            if (tmp.Name == "lng")
                                lng = double.Parse(tmp.InnerText, CultureInfo.InvariantCulture);
                        }
                    }

                    return new GeoCoordinate(lat, lng);
                }
            }
        }

        public AddressesProcess(string Address1, string Address2)
        {
            Address1 = Address1.Replace(' ', '+');
            Address2 = Address2.Replace(' ', '+');
            this.add1 = AddressToLatLng(Address1);
            this.add2 = AddressToLatLng(Address2);
        }
    }
}
