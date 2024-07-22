using PooyesheSabz.Web.DTOs.Repositories.Supports;
using PooyesheSabz.Web.Interfaces.Providers;
using PooyesheSabz.Web.Interfaces.Repositories;
using System.Reflection;

namespace PooyesheSabz.Web.Repositories
{
    public class SupportRepository(IHttpServiceProvider _HttpServiceProvider) : ISupportRepository
    {
        const string APIController = "Support";

        public async Task<IEnumerable<SupportDTO>?> GetMySupportsAsync()
        {
            return await _HttpServiceProvider.Get<IEnumerable<SupportDTO>?>($"{APIController}/GetMySupportsAsync");
        }

        public async Task<string?> NewSupportAsync(NewSupportDTO model)
        {
            return await _HttpServiceProvider.Post<NewSupportDTO, string?>($"{APIController}/NewSupportAsync", model);
        }

        public async Task<string?> PaySupportAsync(PaySupportDTO model)
        {
            return await _HttpServiceProvider.Post<PaySupportDTO, string?>($"{APIController}/PaySupportAsync", model);
        }
    }
}
