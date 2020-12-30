using CommandHelper.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.IdentityService
{
    public interface IUserService
    {
        public string Register(UserRegisterDTO model);
        public string Login(UserLoginDTO model);
    }
}
