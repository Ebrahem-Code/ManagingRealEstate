using ManagingRealEstate.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagingRealEstate.API.Database.Configurations;

public class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.HasKey(re => re.Id);

        builder.HasIndex(re => re.Id).IsUnique();

        builder.Property(re => re.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(re => re.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(re => re.Price);

        builder.Property(re => re.Location)
            .IsRequired()
            .HasMaxLength(200);
    }
}
