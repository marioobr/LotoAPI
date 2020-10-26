﻿using System;
using System.Collections.Generic;

namespace APILoto.Models
{
    public partial class Draw
    {
        public Draw()
        {
            BillDetail = new HashSet<BillDetail>();
        }

        public int DrawId { get; set; }
        public DateTime Date { get; set; }
        public int? Winner { get; set; }

        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}