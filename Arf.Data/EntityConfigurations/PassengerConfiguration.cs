using Arf.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Arf.Data.EntityConfigurations
{
    public class PassengerConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            Property(x => x.Firstname)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Dob)
                .IsRequired();

            Property(x => x.Email)
                //.IsRequired()
                .HasMaxLength(50);

            Property(x => x.Mobile)
                //.IsRequired()
                .HasMaxLength(10);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.UpdatedOn)
                .IsRequired();

            HasRequired(x => x.Booking)
                .WithMany(x => x.Passengers)
                .HasForeignKey(x => x.BookingId)
                .WillCascadeOnDelete(false);
        }
    }
}