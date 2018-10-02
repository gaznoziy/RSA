using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using rsa_api.Services;

namespace rsa_api.Hubs
{
    public class RSAHub : Hub
    {
        private readonly IRSAService _rsaService;

        public RSAHub(IRSAService rsaService)
        {
            _rsaService = rsaService;
        }

        public async Task Connected()
        {
            var keys = _rsaService.GetRandomRSAKeys();

            await Clients.Caller.SendAsync("SendKeys", keys.PublicKey, keys.PrivateKey);
        }
    }
}