using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.models
{
    [DataContract]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        public string Author { get; set; }
        [DataMember]
        [Required]
        public string Category { get; set; }
        [DataMember]
        [Required]
        public int Edition { get; set; }
        [DataMember]
        [Required]
        public int No_of_Total_Copy { get; set; }
        [DataMember]
        [Required]
        public int No_of_Available_Copy { get; set; }
    }
}
