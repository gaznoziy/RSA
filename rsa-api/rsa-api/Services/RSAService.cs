using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using rsa_api.Common;

namespace rsa_api.Services
{
    public class RSAService : IRSAService
    {
        public KeysViewModel GetRandomRSAKeys()
        {
            var rsa = new RSACryptoServiceProvider(1024);

            return new KeysViewModel
            {
                PublicKey = KeyExporter.ExportPublicKey(rsa),
                PrivateKey = KeyExporter.ExportPrivateKey(rsa)
            };
        }

        public string Encrypt(string text)
        {
            var publicKeyString = "asd";
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            RSAParameters rsaParameters = new RSAParameters();
            rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
            rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
        }
    }
}
