using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEshop.Entities.Identity;

namespace ProEshop.DataLayer.Configurations
{
    /// <summary>
    /// UserLogin has a one-to-many relation with User
    /// Each User can have many UserLogin
    /// </summary>
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasOne(userLogin => userLogin.User)
                .WithMany(userLogin => userLogin.UserLogins)
                .HasForeignKey(userLogin => userLogin.UserId);

            builder.ToTable("UserLogins");
        }
    }
}