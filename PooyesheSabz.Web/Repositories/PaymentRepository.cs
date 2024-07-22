using PooyesheSabz.Web.DTOs.Repositories.Supports;
using PooyesheSabz.Web.Interfaces.Providers;
using PooyesheSabz.Web.Interfaces.Repositories;
using System.Reflection;

namespace PooyesheSabz.Web.Repositories
{
    public class PaymentRepository(IHttpServiceProvider _HttpServiceProvider) : IPaymentRepository
    {
        const string APIController = "Payment";
        public async Task<bool> VerifyAsync(long trackId)
        {
            return await _HttpServiceProvider.Get<bool>($"{APIController}/VerifyAsync?trackId={trackId}");
        }
    }
}
