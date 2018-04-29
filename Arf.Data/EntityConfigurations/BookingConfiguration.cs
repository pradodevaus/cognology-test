using Arf.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Arf.Data.EntityConfigurations
{
    public class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        public BookingConfiguration()
        {
            Property(x => x.FlightNumber)
                .IsRequired();

            Property(x => x.TravelDate)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();

            HasRequired(x => x.Flight)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.FlightId)
                .WillCascadeOnDelete(false);
        }
    }
}