using CRUDCatalogoPersonas.Core.PeopleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDCatalogoPersonas.Infrastructure.Data.Config;

public class PeopleConfiguration : IEntityTypeConfiguration<People>
{
    public void Configure(EntityTypeBuilder<People> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.LastName)
            .IsRequired();

        builder.Property(p => p.Email)
            .IsRequired();

        builder.Property(p => p.Gender)
            .IsRequired();

        builder.Property(p => p.Phone)
            .HasMaxLength(10)
            .IsRequired();
    }
}
