using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_dotnet_core_mvc.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> CheckUserCredentials(string userName, string password);
        string EncryptPlainTextToEncryptedText(string password);
        string DecryptEncriptedTextToPlainText(string decryptedPassword);
    }
}
