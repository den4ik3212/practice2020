using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Club
    {
        [Key]
        public int cl_Id { get; set; }
        public string cl_Name { get; set; }
    }
}
