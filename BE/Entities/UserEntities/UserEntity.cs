using Microsoft.AspNetCore.Identity;

namespace Entities;

//IdentityUser
//IdentityRole
//IdentityUserClaim
//IdentityUserToken
//IdentityUserLogin
//IdentityRoleClaim
//IdentityUserRole
public class UserEntity : IdentityUser
{
    public virtual PaymentDetailEntity? PaymentDetail { get; set; }
}
