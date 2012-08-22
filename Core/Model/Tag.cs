using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Tag : Entity
    {

        [StringLength(50)]
        public string Name { get; set; }

    }
}
