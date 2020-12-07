using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Draw
    {
        /*public Draw()
        {
            BillDetail = new HashSet<BillDetail>();
        }*/

        public Guid DrawId { get; set; }
        public DateTime Date { get; set; }
        public int? Winner { get; set; }

        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
