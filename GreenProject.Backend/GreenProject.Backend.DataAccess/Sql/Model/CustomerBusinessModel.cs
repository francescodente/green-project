using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenProject.Backend.DataAccess.Sql.Model
{
    public class CustomerBusinessModel : IEntityTypeConfiguration<CustomerBusiness>
    {
        public const int BusinessNameSize = 100;
        public const int LegalFormSize = 10;
        public const int PecSize = 60;
        public const int SdiSize = 7;
        public const int VatNumberSize = 16;

        public void Configure(EntityTypeBuilder<CustomerBusiness> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasIndex(e => e.VatNumber)
                .IsUnique();

            entity.Property(e => e.BusinessName)
                .IsRequired()
                .HasMaxLength(BusinessNameSize);

            entity.Property(e => e.LegalForm)
                .IsRequired()
                .HasMaxLength(LegalFormSize);

            entity.Property(e => e.Pec)
                .HasMaxLength(PecSize);

            entity.Property(e => e.Sdi)
                .HasMaxLength(SdiSize);

            entity.Property(e => e.VatNumber)
                .IsRequired()
                .HasMaxLength(VatNumberSize);

            entity.HasOne(d => d.User)
                .WithOne(p => p.CustomerBusiness)
                .HasForeignKey<CustomerBusiness>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
