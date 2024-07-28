using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Pages;

partial class New
{
    [Inject] IPageRepository _PageRepository { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    private List<string> Tags;

    private PageDTO page { get; set; } = new PageDTO
    {
        URL = String.Empty,
        Title = String.Empty,
        Description = String.Empty,
        Keywords = new List<string>(),
        Body = "مطلب خود را در اینجا بنویسید.",
    };

    public async Task Create()
    {
        if (await _PageRepository.NewPageAsync(page))
        {
            _NavigationManager.NavigateTo("Pages/My");
            _Snackbar.Add($"صفحه {page.Title} با موفقیت ایجاد شد", Severity.Success);
        }
    }
}
