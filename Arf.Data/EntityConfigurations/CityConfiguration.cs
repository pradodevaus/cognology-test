using Arf.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Arf.Data.EntityConfigurations
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(5);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.UpdatedOn)
                .IsRequired();
        }
    }
}