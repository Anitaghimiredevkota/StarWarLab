using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace StarWarsAPI.Models
{
    public class StarWarsDAL
    {

        //Method calling
        public static string GetData(String url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                //JObject starData = new JObject(data.ReadToEnd());
                return data.ReadToEnd();
            }
            return "";
        }

        public static Person GetPerson(int i)
        {
            string personText = GetData($"https://swapi.co/api/people/{i}/");

            return new Person(personText);
        }
        public static Planet GetPlanet(int i)
        {
            string planetText = GetData($"https://swapi.co/api/planets/{i}/");

            return new Planet(planetText);
        }

    }
}