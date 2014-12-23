using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;

namespace  CustomersList.Module.BusinessObjects {
	public class CustomersListDbContext : DbContext {
		public CustomersListDbContext(String connectionString)
			: base(connectionString) {
		}
		public CustomersListDbContext(DbConnection connection)
			: base(connection, false) {
		}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Customer>().HasMany(c=>c.Addresses).WithRequired(a=>a.Customer).WillCascadeOnDelete(true);
        }

		public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
	}
}