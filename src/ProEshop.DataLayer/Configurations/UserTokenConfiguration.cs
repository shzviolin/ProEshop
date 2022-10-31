using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEshop.Entities.Identity;

namespace ProEshop.DataLayer.Configurations
{
    /// <summary>
    /// UserToken has a one-to-many relation with User
    /// Each User can have many UserToken
    /// We use this for external logins like google, facebook ,...
    /// </summary>
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasOne(userToken => userToken.User)
                .WithMany(userToken => userToken.UserTokens)
                .HasForeignKey(userToken => userToken.UserId);

            builder.ToTable("UserTokens");
        }
    }
}
