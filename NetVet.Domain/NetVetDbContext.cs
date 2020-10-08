using System.Data.Entity;
using NetVet.Domain.Entities;

namespace NetVet.Domain
{
    /// <summary>
    /// Example DB Context. There is no database as part of this example, but provided 
    /// to outline how the repository and Unit of Work patterns are laid out.
    /// </summary>
    internal class NetVetDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public NetVetDbContext(string connectionString = "NetVetConnectionString")
            : base(connectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
