using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string HomePlanet { get; set; }

        public Person(string APIText)
        {   

            JObject starData = JObject.Parse(APIText);

            JObject specie = JObject.Parse(StarWarsDAL.GetData(starData["species"][0].ToString()));
            JObject homePlanet = JObject.Parse(StarWarsDAL.GetData(starData["homeworld"].ToString()));

            Name = starData["name"].ToString();
            Species = specie["name"].ToString();
          
            Gender = starData["gender"].ToString();
            HomePlanet = homePlanet["name"].ToString();
        }
    }
}