using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Sql.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Models.Product>
    {
        public void Configure(EntityTypeBuilder<Models.Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(250);

            builder.HasData(new Models.Product() { Description = "Bed description", Name = "Bed", Price = 100 });
            builder.HasData(new Models.Product() { Description = "Tv description", Name = "TV", Price = 50 });
            builder.HasData(new Models.Product() { Description = "Chair description", Name = "Chair", Price = 25 });
            builder.HasData(new Models.Product() { Description = "Coffe description", Name = "Coffe", Price = 10 });
        }
    }
}
