using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.Models
{
    public partial class TS_Relaunch_MergeContext : DbContext
    {
        public TS_Relaunch_MergeContext()
        {
        }

        public TS_Relaunch_MergeContext(DbContextOptions<TS_Relaunch_MergeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InvInventory> InvInventories { get; set; }
        public virtual DbSet<InvItem> InvItems { get; set; }
        public virtual DbSet<InvLocation> InvLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TS_Relaunch_Merge;Persist Security Info=True;User ID=sa;Password=sa;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvInventory>(entity =>
            {
                entity.ToTable("INV_Inventory");

                entity.HasIndex(e => e.InvItemId, "I2_INV_Inventory_INV_ItemId");

                entity.HasIndex(e => e.InvLocationId, "IDX_INV_Inventory_INV_LocationId");

                entity.Property(e => e.InvInventoryId).HasColumnName("INV_InventoryId");

                entity.Property(e => e.AccountingDate).HasColumnType("datetime");

                entity.Property(e => e.InvItemId).HasColumnName("INV_ItemId");

                entity.Property(e => e.InvLocationAreaId).HasColumnName("INV_LocationAreaId");

                entity.Property(e => e.InvLocationId).HasColumnName("INV_LocationId");

                entity.Property(e => e.InventoryInd)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemDescription).HasMaxLength(400);

                entity.Property(e => e.LastCountComments).HasMaxLength(400);

                entity.Property(e => e.LastCountDate).HasColumnType("datetime");

                entity.Property(e => e.Ytdallocated).HasColumnName("YTDAllocated");

                entity.HasOne(d => d.InvItem)
                    .WithMany(p => p.InvInventories)
                    .HasForeignKey(d => d.InvItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.InvLocation)
                    .WithMany(p => p.InvInventories)
                    .HasForeignKey(d => d.InvLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<InvItem>(entity =>
            {
                entity.ToTable("INV_Item");

                entity.HasIndex(e => new { e.ItemNumber, e.InvItemId }, "i1_iNV_Item");

                entity.Property(e => e.InvItemId).HasColumnName("INV_ItemId");

                entity.Property(e => e.ActiveInd).HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultCostCode)
                    .HasMaxLength(200)
                    .HasColumnName("Default_CostCode");

                entity.Property(e => e.DefaultCostCodeCategory)
                    .HasMaxLength(200)
                    .HasColumnName("Default_CostCodeCategory");

                entity.Property(e => e.DefaultInvVendorId).HasColumnName("Default_INV_VendorId");

                entity.Property(e => e.Glcode)
                    .HasMaxLength(200)
                    .HasColumnName("GLCode");

                entity.Property(e => e.HistoryRecalcNeeded).HasDefaultValueSql("((1))");

                entity.Property(e => e.InvItemTypeId).HasColumnName("INV_ItemTypeId");

                entity.Property(e => e.InventoryInvItemUomId).HasColumnName("Inventory_INV_ItemUomId");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber).HasMaxLength(400);

                entity.Property(e => e.LandedCost).HasColumnName("Landed_Cost");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.NonInventoryInd).HasDefaultValueSql("((0))");

                entity.Property(e => e.RwVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StandardCost).HasColumnName("Standard_Cost");
            });

            modelBuilder.Entity<InvLocation>(entity =>
            {
                entity.ToTable("INV_Location");

                entity.HasIndex(e => e.Name, "I1_INV_Location_Name");

                entity.HasIndex(e => e.JobExtraKey, "IDX_INV_Location_JOB_EXTRA_KEY");

                entity.HasIndex(e => e.JobKey, "IDX_INV_Location_JOB_KEY");

                entity.Property(e => e.InvLocationId).HasColumnName("INV_LocationId");

                entity.Property(e => e.ActiveInd)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address1).HasMaxLength(400);

                entity.Property(e => e.Address2).HasMaxLength(400);

                entity.Property(e => e.Attention).HasMaxLength(400);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Coaddress)
                    .HasMaxLength(500)
                    .HasColumnName("COAddress");

                entity.Property(e => e.CreateNewItemInd).HasDefaultValueSql("((0))");

                entity.Property(e => e.DamagedInventoryInd).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultGlcode)
                    .HasMaxLength(50)
                    .HasColumnName("DefaultGLCode");

                entity.Property(e => e.Email).HasMaxLength(400);

                entity.Property(e => e.EquipBillInd).HasDefaultValueSql("((0))");

                entity.Property(e => e.Extension).HasMaxLength(20);

                entity.Property(e => e.JobExtraKey).HasColumnName("JOB_EXTRA_KEY");

                entity.Property(e => e.JobKey).HasColumnName("JOB_KEY");

                entity.Property(e => e.JobNumber)
                    .HasMaxLength(256)
                    .HasColumnName("JOB_NUMBER");

                entity.Property(e => e.Name).HasMaxLength(400);

                entity.Property(e => e.ParentInvLocationId).HasColumnName("Parent_INV_LocationId");

                entity.Property(e => e.Phone1).HasMaxLength(100);

                entity.Property(e => e.Phone2).HasMaxLength(100);

                entity.Property(e => e.PurchaseInd)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TaxGroup)
                    .HasMaxLength(100)
                    .HasColumnName("Tax_Group");

                entity.Property(e => e.WarrantyInd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasMaxLength(20);

                entity.HasOne(d => d.ParentInvLocation)
                    .WithMany(p => p.InverseParentInvLocation)
                    .HasForeignKey(d => d.ParentInvLocationId)
                    .HasConstraintName("FK__INV_Locat__Paren__0CA83BE3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
