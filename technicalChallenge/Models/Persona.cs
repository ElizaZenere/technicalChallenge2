using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace technicalChallenge.Models
{
  
        [DataContract]
        public class Persona
        {
           
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string nombre { get; set; }
            [DataMember]
            public int edad { get; set; }
        }

    
}