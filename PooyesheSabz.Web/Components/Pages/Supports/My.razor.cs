using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Supports;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Supports;

partial class My
{
    [Inject] ISupportRepository _SupportRepository { get; set; }

    IEnumerable<SupportDTO>? _Supports;
    protected override async Task OnInitializedAsync()
    {
        _Supports = await _SupportRepository.GetMySupportsAsync();
    }

}
