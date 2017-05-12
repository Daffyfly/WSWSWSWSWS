
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string Station_Substring = "";
            // Station_Substring = "QUIT" to quit 
            while (String.Compare(Station_Substring,"QUIT")!=0)
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");
                
                // Get Substring in the name of the stations  
                Console.WriteLine("Entrez le nom de la station:");
                 Station_Substring = Console.ReadLine();
                
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

                // browse the XmlNodeList
                for (int i = 0; i < elemList.Count; i++)
                {
                    //Test if the substring is in the name of the station  
                    if (elemList[i].Attributes["name"].Value.Contains(Station_Substring))
                    {
                        //Get the number of the Station 
                        String numPoint = elemList[i].Attributes["number"].Value;

                        // Create a request for the URL.
                        WebRequest request_for_data = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + numPoint);

                        // Get Response 
                        WebResponse response_for_data = request_for_data.GetResponse();

                        // Open the stream using a StreamReader for easy access and put it into a string
                        Stream dataStream_for_data = response_for_data.GetResponseStream();
                        StreamReader reader_for_data = new StreamReader(dataStream_for_data); // Read the content.
                        string responseFromServer_for_data = reader_for_data.ReadToEnd(); // Put it in a String

                        // Parse the response and put the entries in XmlNodeList 
                        XmlDocument doc_for_data = new XmlDocument();
                        doc_for_data.LoadXml(responseFromServer_for_data);
                        XmlNodeList elemList_for_data = doc_for_data.GetElementsByTagName("available");

                        // Display the result 
                        Console.Write(elemList_for_data[0].FirstChild.Value);
                        Console.Write(" bikes are available ");
                        Console.WriteLine("at " + elemList[i].Attributes["name"].Value);
                        reader_for_data.Close();
                        response_for_data.Close();
                    }
                }
                // Clean up the streams and the response.
                reader.Close();
                response.Close();
            }
        }
    }
}
