using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizza_API.Models
{
    public partial class s15885Context : DbContext
    {
        public s15885Context()
        {
        }

        public s15885Context(DbContextOptions<s15885Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPizza> OrderPizza { get; set; }
        public virtual DbSet<OrderSide> OrderSide { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        public virtual DbSet<Side> Side { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15885;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressDetails)
                    .IsRequired()
                    .HasColumnName("Address_details")
                    .HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNr).HasColumnName("Phone_nr");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Deal_pk");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Season).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.DealCode)
                    .IsRequired()
                    .HasColumnName("Deal_Code")
                    .HasMaxLength(10);

                entity.Property(e => e.Delivery).HasMaxLength(50);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_date")
                    .HasColumnType("date");

                entity.Property(e => e.OrderNr).HasColumnName("Order_nr");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Admin");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_purchase");

                entity.HasOne(d => d.DealCodeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DealCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Deal");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Payment");
            });

            modelBuilder.Entity<OrderPizza>(entity =>
            {
                entity.HasKey(e => new { e.PizzaId, e.OrderId })
                    .HasName("Order_Pizza_pk");

                entity.ToTable("Order_Pizza");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Pizza_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Pizza_Pizza");
            });

            modelBuilder.Entity<OrderSide>(entity =>
            {
                entity.HasKey(e => new { e.SideId, e.OrderId })
                    .HasName("Order_Side_pk");

                entity.ToTable("Order_Side");

                entity.Property(e => e.SideId).HasColumnName("Side_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderSide)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_14_Order");

                entity.HasOne(d => d.Side)
                    .WithMany(p => p.OrderSide)
                    .HasForeignKey(d => d.SideId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_14_Side");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.Method).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Payment_Client");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Menu");
            });

            modelBuilder.Entity<PizzaIngredient>(entity =>
            {
                entity.HasKey(e => new { e.PizzaId, e.IngredientId })
                    .HasName("Pizza_Ingredient_pk");

                entity.ToTable("Pizza_Ingredient");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.Property(e => e.IngredientId).HasColumnName("Ingredient_ID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredient)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ingredient_Ingredient");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredient)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ingredient_Pizza");
            });

            modelBuilder.Entity<Side>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Side)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Side_Menu");
            });
        }
    }
}
