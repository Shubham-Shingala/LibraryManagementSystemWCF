using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library_Management.models
{
    [DataContract]
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string SecureToken { get; set; }
        public int StudentId { get; set; }
        public System.DateTime CreateDate { get; set; }

        public virtual Student Student { get; set; }
    }
}