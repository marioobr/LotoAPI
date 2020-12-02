﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Bill
    {
        public Bill()
        {
            BillDetail = new HashSet<BillDetail>();
        }

        public int BillId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}