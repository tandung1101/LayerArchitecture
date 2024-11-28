﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LayerArchitecture.Core;
using LayerArchitecture.Core.Model;

namespace LayerArchitecture.Repository.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(c => c.Id)
               .ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
}
