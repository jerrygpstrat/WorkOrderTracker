using Microsoft.EntityFrameworkCore;
using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.DataLayer.Context
{
    public class WoTrackerDbContext : DbContext
    {
        public WoTrackerDbContext(DbContextOptions<WoTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public DbSet<Asset> Assets { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<WorkOrderTask> WorkOrderTasks { get; set; } = null!;
        public DbSet<WorkOrderPart> WorkOrderParts { get; set; } = null!;
        public DbSet<LaborLog> LaborLogs { get; set; } = null!;
        public DbSet<AppVar> AppVars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkOrderTask>()
            .HasOne<WorkOrder>()                       // A task has one parent WorkOrder
            .WithMany(w => w.Tasks)                    // A WorkOrder has many Tasks
            .HasForeignKey(t => t.WorkOrderId)         // The foreign key property on WorkOrderTask
            .OnDelete(DeleteBehavior.Cascade);         // If a WorkOrder is deleted, delete its tasks automatically


            // ==========================================
            // POINT 1: Many-to-Many (WorkOrder <-> Part via WorkOrderPart)
            // ==========================================

            // Composite Primary Key for the join table
            modelBuilder.Entity<WorkOrderPart>()
                .HasKey(wop => new { wop.WorkOrderId, wop.PartId });

            // Link: WorkOrder -> WorkOrderParts
            modelBuilder.Entity<WorkOrderPart>()
                .HasOne(wop => wop.WorkOrder)
                .WithMany(w => w.PartsUsed)
                .HasForeignKey(wop => wop.WorkOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Link: Part -> WorkOrderParts
            modelBuilder.Entity<WorkOrderPart>()
                .HasOne(wop => wop.Part)
                .WithMany() // No navigation property needed on Part class
                .HasForeignKey(wop => wop.PartId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting parts currently assigned to work orders


            // ==========================================
            // POINT 2: Unique Constraints and Indexes
            // ==========================================

            // Ensure OrderNumber is unique across the system and index it for fast searches
            modelBuilder.Entity<WorkOrder>()
                .HasIndex(w => w.OrderNumber)
                .IsUnique();

            // string lengths
            modelBuilder.Entity<WorkOrder>()
                .Property(w => w.Title)
                .HasMaxLength(128);

            modelBuilder.Entity<WorkOrder>()
                .Property(w => w.Description)
                .HasMaxLength(1024);

            modelBuilder.Entity<WorkOrderTask>()
                .Property(t => t.Description)
                .HasMaxLength(512);

            modelBuilder.Entity<Part>()
                .Property(t => t.Name)
                .HasMaxLength(256);
            
            modelBuilder.Entity<LaborLog>()
                .Property(t => t.Notes)
                .HasMaxLength(512);

            // Ensure Part SKU is unique so inventory isn't duplicated
            modelBuilder.Entity<Part>()
                .HasIndex(p => p.SKU)
                .IsUnique();


        }
    }
}
