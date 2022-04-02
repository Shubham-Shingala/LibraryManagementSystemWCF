using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library_Management.dtos
{
    [DataContract]
    public class StudentDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CollegeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}