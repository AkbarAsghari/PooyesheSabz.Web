using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Pages;

partial class Page
{
    [Inject] public IPageRepository _PageRepository { get; set; }
    [Inject] public NavigationManager _NavigationManager { get; set; }

    [Parameter] public string PageType { get; set; }
    [Parameter] public string URL { get; set; }

    PublishPageDTO? publishPageDTO;
    string[]? keywords;

    protected override async Task OnInitializedAsync()
    {
        publishPageDTO = await _PageRepository.GetPageByURLAsync(url: $"{PageType}/{URL}");

        if (publishPageDTO == null)
        {
            _NavigationManager.NavigateTo("404");
        }
        var pageMetadata = await _PageRepository.GetPageMetadataAsync($"{PageType}/{URL}");

        keywords = pageMetadata == null ? null : pageMetadata.Keywords;

        await InvokeAsync(() => StateHasChanged());
    }
}
