using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Task : Entity
    {

        [StringLength(50)]
        public string Title { get; set; }
        public bool IsDone { get; set; } 
    }
}
