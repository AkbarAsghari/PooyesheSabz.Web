using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Pages;

partial class My
{
    [Inject] public IPageRepository _PageRepository { get; set; }
    [Inject] public NavigationManager _NavigationManager { get; set; }
    [Inject] public IDialogService _DialogService { get; set; }
    [Inject] public ISnackbar _Snackbar { get; set; }


    IEnumerable<PageSummaryDTO>? _PageSummaries;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadPages();
            await this.InvokeAsync(() => StateHasChanged());
        }
    }

    private async Task LoadPages()
    {
        _PageSummaries = await _PageRepository.GetAllPagesSummaryAsync();
    }

    private async Task DeletePage(PageSummaryDTO record)
    {
        bool? result = await _DialogService.ShowMessageBox(
           "هشدار",
           $"آیا از حذف صفحه {record.Title} مطمئن هستید؟",
           yesText: "حذف", cancelText: "انصراف");

        if (result == true)
        {
            if (await _PageRepository.DeletePageAsync(record.Id))
            {
                _PageSummaries = _PageSummaries!.Where(x => x.Id != record.Id).ToList();
            }
        }
    }

    private async Task PublishPage(PageSummaryDTO record)
    {
        bool? result = await _DialogService.ShowMessageBox(
           "هشدار",
           $"آیا از انتشار صفحه {record.Title} مطمئن هستید؟",
           yesText: "انتشار", cancelText: "انصراف");

        if (result == true)
        {
            if (await _PageRepository.PublishPageAsync(record.Id))
            {
                _PageSummaries!.First(x => x.Id == record.Id).IsPublieshed = true;
                _Snackbar.Add($"صفحه {record.Title} با موفقیت منتشر شد", Severity.Success);
            }
        }
    }

    private void EditPage(PageSummaryDTO record)
    {
        _NavigationManager.NavigateTo("Pages/Edit/" + record.Id);
    }
}
