using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Models;

namespace RommelkoningenApi.Configurations
{
    public class FotoDataConfiguration : IEntityTypeConfiguration<FotoData>
    {
        public void Configure(EntityTypeBuilder<FotoData> builder)
        {
            builder.ToTable("FotoData");
            builder.HasKey(f => f.Foto_Id);
            builder.Property(f => f.Datum_En_Tijd);
            builder.Property(f => f.Camera_Naam);
            builder.Property(f => f.Longitude);
            builder.Property(f => f.Latitude);
            builder.Property(f => f.Postcode);
            builder.Property(f => f.Windrichting);
            builder.Property(f => f.Temperatuur);
            builder.Property(f => f.Weer_Omschrijving);
        }
    }
}