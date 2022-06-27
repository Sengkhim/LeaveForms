using Domain.Authentication;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Mapconfig
{
    public class IdentityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = DefaultEntity.User,
                UserName = "BenZ",
                FirstName = "BenZ",
                LastName = "UTC",
                Status = true,
                Email = "benz@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "012273893",
                PhoneNumberConfirmed = true,
                NormalizedEmail = "benz@gmail.com".ToUpper(),
                NormalizedUserName = "benz".ToUpper(),
                PasswordHash = "AQAAAAEAACcQAAAAEL9cktyP+gHmmzf9H/EDjjVr7yan9Xo8kNhEBsfAC2o4xxxuluEo71+aVTpUB7YG7Q==",
                SecurityStamp = "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG",
                ConcurrencyStamp = "2708d6d2-9657-423a-bb75-34be3b1e2821",
                RefreshTokenExpiryTime = DateTime.MaxValue,
                RefreshToken = "WPOJONETW3HXSDNK4LQR47BNYJSG7OFG"
            });
        }
    }
}
