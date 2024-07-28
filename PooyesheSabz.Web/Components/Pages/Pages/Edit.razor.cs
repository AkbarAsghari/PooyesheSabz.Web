using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Pages;

partial class Edit
{
    [Inject] IPageRepository _PageRepository { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    [Parameter] public Guid PageId { get; set; }

    private PageDTO? existPage;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            existPage = await _PageRepository.GetPageAsync(PageId);
            await this.InvokeAsync(() => StateHasChanged());
        }
    }

    public async Task Update()
    {
        if (await _PageRepository.UpdatePageAsync(existPage!))
        {
            _NavigationManager.NavigateTo("Pages/My");
            _Snackbar.Add($"صفحه {existPage!.Title} با موفقیت ویرایش شد", Severity.Success);
        }
    }
}
