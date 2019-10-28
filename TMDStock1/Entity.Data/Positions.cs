using System;
using System.Collections.Generic;

namespace TMDStock1.Entity
{
    public partial class Positions
    {
        public int Id { get; set; }
        public int? TransactionId { get; set; }
        public int? Qty { get; set; }
        public double? Cost { get; set; }
        public double? Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Transactions Transaction { get; set; }
    }
}
