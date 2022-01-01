using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Mappings
{
    public class ToDoMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.ToTable(nameof(ToDo));

            builder.HasKey(x => x.Id);
         
            builder
                .Property(x => x.Id)
                .HasMaxLength(36)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder
                .Property(x => x.Done)
                .HasColumnType("TINYINT")
                .IsRequired();

            builder
                .Property(x => x.StartedAt)
                .IsRequired();

            builder
                .Property(x => x.FinishedAt)
                .IsRequired(false);

            builder
                .Property(x => x.User)
                .IsRequired();

            builder
                .HasIndex(x => x.User);
        }
    }
}