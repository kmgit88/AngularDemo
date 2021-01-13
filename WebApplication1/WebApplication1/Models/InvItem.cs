using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class InvItem
    {
        public InvItem()
        {
            InvInventories = new HashSet<InvInventory>();
        }

        public int InvItemId { get; set; }
        public string Name { get; set; }
        public int? InvItemTypeId { get; set; }
        public string ItemNumber { get; set; }
        public double? UnitCost { get; set; }
        public int? DefaultInvVendorId { get; set; }
        public string Glcode { get; set; }
        public string DefaultCostCode { get; set; }
        public string DefaultCostCodeCategory { get; set; }
        public bool? TaxInd { get; set; }
        public int? InventoryInvItemUomId { get; set; }
        public double? LastPurchasedUnitCost { get; set; }
        public bool? NonInventoryInd { get; set; }
        public double? AvgCost { get; set; }
        public bool? ActiveInd { get; set; }
        public string ItemDescription { get; set; }
        public double? StandardCost { get; set; }
        public double? LandedCost { get; set; }
        public byte[] RwVersion { get; set; }
        public bool? HistoryRecalcNeeded { get; set; }

        public virtual ICollection<InvInventory> InvInventories { get; set; }
    }
}
