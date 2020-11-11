using SmartDripper.WebAPI.Data;

namespace SmartDripper.WebAPI.Services
{
    public class AdminService : GenericUserService
    {
        public AdminService(ApplicationContext applicationContext,
                            JWTTokenService tokenService)
            : base(applicationContext, tokenService)
        { }

    }
}
