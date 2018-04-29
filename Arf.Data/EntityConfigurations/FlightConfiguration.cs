using Arf.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Arf.Data.EntityConfigurations
{
    public class FlightConfiguration : EntityTypeConfiguration<Flight>
    {
        public FlightConfiguration()
        {
            Property(x => x.FlightNumber)
                .IsRequired()
                .HasMaxLength(5);

            Property(x => x.StartTime)
                .IsRequired();

            Property(x => x.EndTime)
                .IsRequired();

            HasRequired(x => x.ArrivalCity)
                .WithMany(x => x.ArrivalFlights)
                .HasForeignKey(x => x.ArrivalCityId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.DepatureCity)
                .WithMany(x => x.DepatureFlights)
                .HasForeignKey(x => x.DepatureCityId)
                .WillCascadeOnDelete(false);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.UpdatedOn)
                .IsRequired();
        }
    }
}