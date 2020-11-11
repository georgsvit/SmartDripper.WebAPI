using SmartDripper.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
