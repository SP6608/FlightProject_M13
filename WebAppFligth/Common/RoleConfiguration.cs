using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppFligth.Common
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly ICollection<IdentityRole> Roles =
            new HashSet<IdentityRole>()
            {
               new IdentityRole
            {
                     Id = "6f2d5d5c-7d4f-4e6a-9d5a-1e7c1a2f4a11",
                     Name = "Admin",
                     NormalizedName = "ADMIN"
            },
                new IdentityRole
                    {
                     Id = "9a1c6c8e-3c5b-4a9a-b0a2-6c8d7f9b2e21",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                    }
            };
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(Roles);
        }
    }
}
