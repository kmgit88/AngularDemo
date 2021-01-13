using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class InvInventory
    {
        public int InvInventoryId { get; set; }
        public int InvItemId { get; set; }
        public string ItemDescription { get; set; }
        public int InvLocationId { get; set; }
        public double? MinQty { get; set; }
        public double? MaxQty { get; set; }
        public double? QtyOnHand { get; set; }
        public double? QtyOnOrder { get; set; }
        public double? QtyAllocated { get; set; }
        public double? Ytdallocated { get; set; }
        public int? InvLocationAreaId { get; set; }
        public double? QtyReserve { get; set; }
        public bool? InventoryInd { get; set; }
        public string LastCountComments { get; set; }
        public DateTime? LastCountDate { get; set; }
        public DateTime? AccountingDate { get; set; }

        public virtual InvItem InvItem { get; set; }
        public virtual InvLocation InvLocation { get; set; }
    }
}
