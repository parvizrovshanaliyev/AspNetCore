using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinIOExample1.Models
{
    public class File
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}
