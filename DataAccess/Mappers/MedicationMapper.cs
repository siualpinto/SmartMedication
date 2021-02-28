using BussinessLogic.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappers
{
    public class MedicationMapper : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(e => e.PKID);
            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.Quantity);
            builder.Property(e => e.CreationDate);
            builder.HasCheckConstraint("CK_Medication_Quantity", "[Quantity] > 0");
        }
    }
}
