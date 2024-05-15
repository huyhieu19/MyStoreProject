using Microsoft.AspNetCore.Identity;

namespace Entities.UserEntities
{
    //IdentityUser
    //IdentityRole
    //IdentityUserClaim
    //IdentityUserToken
    //IdentityUserLogin
    //IdentityRoleClaim
    //IdentityUserRole
    public class UserBaseEntity : IdentityUser
    {
        public virtual PaymentDetailEntity? PaymentDetail { get; set; }
    }
}
