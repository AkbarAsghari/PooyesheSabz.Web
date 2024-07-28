
using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;

namespace PooyesheSabz.Web.Components.Pages.Pages;
partial class PageGeneratorForm
{
    [Parameter] public string Title { get; set; }

    [Parameter]
    public PageDTO Page { get; set; } = new PageDTO
    {
        URL = string.Empty,
        Title = string.Empty,
        Description = string.Empty,
        Keywords = new List<string>(),
        Body = "مطلب خود را در اینجا بنویسید.",
    };

    [Parameter] public EventCallback OnValidSubmit { get; set; }
}
