using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSql.Entities.Concrate;
using System;

namespace PostgreSql.DataAccess.Concrete.EntityFramework.Configurations
{
    public class ExampleConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> modelBuilder)
        {
            modelBuilder.Property<int>(x => x.Id).IsRequired(true).ValueGeneratedOnAdd();
            modelBuilder.Property<string>(x => x.Title).IsRequired(true).ValueGeneratedNever();
            modelBuilder.Property<string>(x => x.Description).IsRequired(true).ValueGeneratedNever();
            modelBuilder.Property<DateTime>(x => x.CreatedDate).IsRequired(true).ValueGeneratedNever();
        }
    }
}
