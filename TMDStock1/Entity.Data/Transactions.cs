using System;
using System.Collections.Generic;

namespace TMDStock1.Entity
{
    public partial class Transactions
    {
        public Transactions()
        {
            Positions = new HashSet<Positions>();
        }

        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Action { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public DateTime? DatePurchased { get; set; }
        public DateTime Datecreated { get; set; }

        public virtual ICollection<Positions> Positions { get; set; }
    }
}
