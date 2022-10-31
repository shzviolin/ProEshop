using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEshop.Entities.Identity;

namespace ProEshop.DataLayer.Configurations
{
    /// <summary>
    /// UserRole is an interface table=> we should declare 2 fluentApi for this
    /// </summary>
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(userRole => userRole.Role)
                .WithMany(userRole => userRole.UserRoles)
                .HasForeignKey(userRole => userRole.RoleId);

            builder.HasOne(userRole => userRole.User)
                .WithMany(userRole => userRole.UserRoles)
                .HasForeignKey(userRole => userRole.UserId);

            builder.ToTable("UserRoles");
        }
    }
}
