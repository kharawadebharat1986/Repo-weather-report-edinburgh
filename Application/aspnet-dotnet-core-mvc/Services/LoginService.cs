using aspnet_dotnet_core_mvc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_dotnet_core_mvc.Services
{
    public class LoginService:ILoginService
    {
        public bool CheckUserCredentials(string userName, string password)
        {
            //user validation logic will come here
            return true;
        }
    }
}
