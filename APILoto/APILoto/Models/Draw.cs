using System;
using System.Collections.Generic;

namespace APILoto.Models
{
    public partial class Draw
    {
        public Draw()
        {
           
        }

        public int DrawId { get; set; }
        public DateTime Date { get; set; }
        public int? Winner { get; set; }

       
    }
}
