using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomBooking.CORE.Entities;
namespace RoomBooking.Infrastructure.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Description).HasMaxLength(500);
            builder.Property(b => b.TotalPrice).HasColumnType("decimal(18,2)");
            builder.Property(b => b.StartDate).HasColumnType("date");   
            builder.Property(b => b.EndDate).HasColumnType("date");
            builder.Property(b => b.ReservationDate).HasColumnType("timestamp");
            builder.Property(b => b.UserId).IsRequired();
            builder.HasOne(b => b.Room)
                   .WithMany(r => r.Bookings)
                   .HasForeignKey(b => b.RoomId);
        }
    }
}
