
using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Accounts;

partial class All
{
    [Inject] IAccountRepository _AccountRepository { get; set; }


    IEnumerable<UserDTO>? _AllUsers { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _AllUsers = await _AccountRepository.GetAllAsync();
    }
}
