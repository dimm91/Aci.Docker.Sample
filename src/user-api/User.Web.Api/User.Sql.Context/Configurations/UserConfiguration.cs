using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Sql.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Models.User>
    {
        public void Configure(EntityTypeBuilder<Models.User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(250);
            builder.Property(x => x.Username).HasMaxLength(50);

            builder.HasData(new Models.User() { Name = "Tim", Email = "Tim.test@email.com", Username = "tim.test" });
            builder.HasData(new Models.User() { Name = "John", Email = "John.test@email.com", Username = "john.test" });
            builder.HasData(new Models.User() { Name = "Jane", Email = "Jane.test@email.com", Username = "jane.test" });
            builder.HasData(new Models.User() { Name = "Doe", Email = "Doe.test@email.com", Username = "doe.test" });
            builder.HasData(new Models.User() { Name = "Carl", Email = "Carl.test@email.com", Username = "carl.test" });
        }
    }
}
