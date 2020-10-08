using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace NetVet.Domain.Entities.Configuration
{
    public class AnimalConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            ToTable("Animals");
            HasKey(x => x.AnimalId)
                .Property(x => x.AnimalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
