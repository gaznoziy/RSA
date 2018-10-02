using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsa_api.Services
{
    public interface IRSAService
    {
        string Encrypt(string text);
        KeysViewModel GetRandomRSAKeys();
    }
}
