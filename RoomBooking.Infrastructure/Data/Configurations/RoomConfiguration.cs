using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomBooking.CORE.Entities;

namespace RoomBooking.Infrastructure.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(r => r.Price).HasColumnType("decimal(18,2)");
            builder.HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId);
            builder.Property(r => r.Description)
                .HasMaxLength(1000);
            builder.Property(r => r.Location)
                .HasMaxLength(500);
        }
    }
}
