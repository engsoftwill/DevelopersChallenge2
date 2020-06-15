using SRC.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SRC.Model

{
    public class Mapofx : IEntityTypeConfiguration<ofx>
    {
        public void Configure(EntityTypeBuilder<ofx> builder)
        {
            builder.ToTable("ofx");
            builder.HasKey(x => x.DTPOSTED);
            builder.HasKey(x => x.TRNAMT);
            builder.Property(x => x.DTPOSTED)
                .HasColumnName("<DTPOSTED>")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.TRNTYPE)
                .HasColumnName("<TRNTYPE>")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.TRNAMT)
                .HasColumnName("<TRNAMT>")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.MEMO)
                .HasColumnName("<MEMO>")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

