using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Providers;
using PooyesheSabz.Web.Interfaces.Repositories;
using System.Reflection;

namespace PooyesheSabz.Web.Repositories
{
    public class PageRepository(IHttpServiceProvider _HttpServiceProvider) : IPageRepository
    {
        const string APIController = "Page";
        public async Task<bool> DeletePageAsync(Guid id)
        {
            return await _HttpServiceProvider.Delete<bool>($"{APIController}/DeletePageAsync?id={id}");
        }

        public async Task<IEnumerable<PageSummaryDTO>?> GetAllPagesSummaryAsync()
        {
            return await _HttpServiceProvider.Get<IEnumerable<PageSummaryDTO>>($"{APIController}/GetAllPagesSummaryAsync");
        }

        public async Task<IEnumerable<PageSummaryDTO>?> GetAllPagesSummaryByTagAsync(string tag)
        {
            return await _HttpServiceProvider.Get<IEnumerable<PageSummaryDTO>>($"{APIController}/GetAllPagesSummaryByTagAsync");
        }

        public async Task<IEnumerable<LastContentsDTO>?> GetLastContentsAsync()
        {
            return await _HttpServiceProvider.Get<IEnumerable<LastContentsDTO>>($"{APIController}/GetLastContentsAsync");
        }

        public async Task<PageDTO?> GetPageAsync(Guid id)
        {
            return await _HttpServiceProvider.Get<PageDTO>($"{APIController}/GetPageAsync?Id={id}");
        }

        public async Task<PublishPageDTO?> GetPageByURLAsync(string url)
        {
            return await _HttpServiceProvider.Get<PublishPageDTO>($"{APIController}/GetPageByURLAsync?url={url}");
        }

        public async Task<PageMetadataDTO?> GetPageMetadataAsync(string url)
        {
            return await _HttpServiceProvider.Get<PageMetadataDTO>($"{APIController}/GetPageMetadataAsync?url={url}");
        }

        public async Task<bool> NewPageAsync(CreatePageDTO model)
        {
            return await _HttpServiceProvider.Post<CreatePageDTO, bool>($"{APIController}/NewPageAsync", model);
        }

        public async Task<bool> PublishPageAsync(Guid id)
        {
            return await _HttpServiceProvider.Put<bool>($"{APIController}/PublishPageAsync?id={id}");
        }

        public async Task<bool> UpdatePageAsync(PageDTO model)
        {
            return await _HttpServiceProvider.Put<PageDTO, bool>($"{APIController}/UpdatePageAsync", model);
        }
    }
}
