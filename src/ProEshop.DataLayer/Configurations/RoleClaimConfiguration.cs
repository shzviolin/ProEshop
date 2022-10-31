using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEshop.Entities.Identity;

namespace ProEshop.DataLayer.Configurations
{
    /// <summary>
    /// RoleClaim has a one-to-many relation with Role
    /// Each role can have many roleClaim
    /// </summary>
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasOne(roleClaim => roleClaim.Role)
                .WithMany(roleClaim => roleClaim.RoleClaims)
                .HasForeignKey(roleClaim => roleClaim.RoleId);

            builder.ToTable("RoleClaims");
        }
    }
}
