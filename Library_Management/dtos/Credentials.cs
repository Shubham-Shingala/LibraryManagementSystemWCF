using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library_Management.dtos
{
    [DataContract]
    public class Credentials
    {
        [DataMember]
        public string CollegeId { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}