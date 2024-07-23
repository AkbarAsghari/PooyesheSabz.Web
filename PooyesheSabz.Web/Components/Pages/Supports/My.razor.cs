using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Supports;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Supports;

partial class My
{
    [Inject] ISupportRepository _SupportRepository { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; } 

    IEnumerable<SupportDTO>? _Supports;
    protected override async Task OnInitializedAsync()
    {
        _Supports = await _SupportRepository.GetMySupportsAsync();
    }

    async Task PaySupport(Guid supportId)
    {
        var paymentLink = await _SupportRepository.PaySupportAsync(new PaySupportDTO
        {
            SupportId = supportId
        });

        if (!String.IsNullOrEmpty(paymentLink))
        {
            _NavigationManager.NavigateTo(paymentLink);
        }
        
    }
}
