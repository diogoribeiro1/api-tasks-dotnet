using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class TaskMap : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("tasks");

        builder.HasKey(c => c.id);

        builder.Property(c => c.id)
            .HasColumnName("id")
            .UseIdentityColumn();
        
        builder.Property(c => c.title)
            .HasColumnName("title");
        
        builder.Property(c => c.description)
            .HasColumnName("description");
    }
}