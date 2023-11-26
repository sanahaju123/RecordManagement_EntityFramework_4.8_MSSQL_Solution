using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordManagementApp.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}