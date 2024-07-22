using PooyesheSabz.Web.DTOs.Repositories.Supports;

namespace PooyesheSabz.Web.Interfaces.Repositories
{
    public interface ISupportRepository
    {
        Task<string?> NewSupportAsync(NewSupportDTO model);
        Task<string?> PaySupportAsync(PaySupportDTO model);
        Task<IEnumerable<SupportDTO>?> GetMySupportsAsync();
    }
}
