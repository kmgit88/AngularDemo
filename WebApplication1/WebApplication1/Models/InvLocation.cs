using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class InvLocation
    {
        public InvLocation()
        {
            InvInventories = new HashSet<InvInventory>();
            InverseParentInvLocation = new HashSet<InvLocation>();
        }

        public int InvLocationId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string WorksheetSaveEmail { get; set; }
        public string Email { get; set; }
        public string Attention { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Extension { get; set; }
        public bool? ActiveInd { get; set; }
        public bool? PurchaseInd { get; set; }
        public int? StateId { get; set; }
        public int? ParentInvLocationId { get; set; }
        public bool? DamagedInventoryInd { get; set; }
        public bool? WarrantyInd { get; set; }
        public string DefaultGlcode { get; set; }
        public string TaxGroup { get; set; }
        public bool? CreateNewItemInd { get; set; }
        public bool? EquipBillInd { get; set; }
        public Guid? JobExtraKey { get; set; }
        public Guid? JobKey { get; set; }
        public string JobNumber { get; set; }
        public string Coaddress { get; set; }

        public virtual InvLocation ParentInvLocation { get; set; }
        public virtual ICollection<InvInventory> InvInventories { get; set; }
        public virtual ICollection<InvLocation> InverseParentInvLocation { get; set; }
    }
}
