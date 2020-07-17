using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Sportsmen
    {
        [Key]
        public int sp_Id { get; set; }
        public int cl_Id {get; set;}
        public string sp_Name { get; set; }
    }
}
