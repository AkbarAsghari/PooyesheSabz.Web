using PooyesheSabz.Web.DTOs.Repositories.Pages;

namespace PooyesheSabz.Web.Interfaces.Repositories
{
    public interface IPageRepository
    {
        Task<bool> NewPageAsync(CreatePageDTO model);
        Task<bool> DeletePageAsync(Guid id);
        Task<bool> UpdatePageAsync(PageDTO model);
        Task<PageDTO?> GetPageAsync(Guid id);
        Task<PublishPageDTO?> GetPageByURLAsync(string url);
        Task<IEnumerable<PageSummaryDTO>?> GetAllPagesSummaryAsync();
        Task<IEnumerable<PageSummaryDTO>?> GetAllPagesSummaryByTagAsync(string tag);
        Task<PageMetadataDTO?> GetPageMetadataAsync(string url);
        Task<bool> PublishPageAsync(Guid id);
        Task<IEnumerable<LastContentsDTO>?> GetLastContentsAsync();
    }
}
