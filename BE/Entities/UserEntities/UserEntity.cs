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
    public virtual List<PaymentDetailEntity>? PaymentDetails { get; set; }
    public bool IsDeleted { get; set; } = false;
}