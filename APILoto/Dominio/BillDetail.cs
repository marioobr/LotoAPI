using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class BillDetail
    {
        [Key]
        public int DetailId { get; set; }
        public int BillId { get; set; }
        public int DrawId { get; set; }
        public int Number { get; set; }
        public double Investment { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Draw Draw { get; set; }
    }
}
