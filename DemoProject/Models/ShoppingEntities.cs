namespace DemoProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoppingEntities : DbContext
    {
        public ShoppingEntities()
            : base("name=ShoppingEntities")
        {
        }

        public virtual DbSet<ItemMst> ItemMsts { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
