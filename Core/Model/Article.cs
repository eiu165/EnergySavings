using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Article : Entity
    {  
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)] 
        public string Url { get; set; }
        public string Content { get; set; }
        [StringLength(100)]
        public string AssignedTo { get; set; }
        [StringLength(100)]  
        public string Status { get; set; }

    }
}
