using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Classes
{
    public partial class Restaurant : DbContext
    {
        public Restaurant()
            : base("name=Restaurant")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chef> Chefs { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishOrder> DishOrders { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientString> IngredientStrings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Dishes)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chef>()
                .Property(e => e.Chef_FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Chef>()
                .Property(e => e.Chef_Education)
                .IsUnicode(false);

            modelBuilder.Entity<Chef>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Chef)
                .HasForeignKey(e => e.Chef_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Dish_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Dish_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.DishOrders)
                .WithRequired(e => e.Dish)
                .HasForeignKey(e => e.Dish_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.IngredientStrings)
                .WithRequired(e => e.Dish)
                .HasForeignKey(e => e.Dish_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Ingredient_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Ingredient_Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.IngredientStrings)
                .WithRequired(e => e.Ingredient)
                .HasForeignKey(e => e.Ingredient_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DishOrders)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
