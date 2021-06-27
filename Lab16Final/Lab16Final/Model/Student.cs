using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab16Final.Model
{
    public class Student
    {
        [JsonProperty("_id")]
        public String Id { get; set; }

        [JsonProperty("DNI")]
        public String DNI { get; set; }

        [JsonProperty("apellido")]
        public String lastName { get; set; }

        [JsonProperty("fechaNacimiento")]
        public DateTime dateBirth { get; set; }

        [JsonProperty("grado")]
        public String Grade { get; set; }

        [JsonProperty("nombre")]
        public String Name { get; set; }
    }
}
