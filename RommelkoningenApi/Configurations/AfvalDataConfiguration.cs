using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Models;

namespace RommelkoningenApi.Configurations
{
    public class AfvalDataConfiguration : IEntityTypeConfiguration<AfvalData>
    {
        public void Configure(EntityTypeBuilder<AfvalData> builder)
        {
            builder.ToTable("AfvalData");
            builder.HasKey(a => a.Afval_Id);
            builder.Property(a => a.Afval_Type);
            builder.Property(a => a.Confidence);

            builder.HasOne<FotoData>()
                .WithMany()
                .HasForeignKey(a => a.Foto_Id);
        }
    }
}