using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library_Management.models
{
    [DataContract]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string CollegeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string MobileNum { get; set; }
        [DataMember]
        public string Password { get; set; }
        public string Salt { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string  Branch { get; set; }
    }
}