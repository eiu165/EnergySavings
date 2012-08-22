using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class ArticleTag : Entity
    { 
        public Article Article { get; set; } 
        public Tag Tag  { get; set; }
    }
}
