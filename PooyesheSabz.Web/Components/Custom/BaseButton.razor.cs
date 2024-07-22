using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace PooyesheSabz.Web.Components.Custom;

partial class BaseButton
{
    [Parameter]
    public EditContext EditContext { get; set; }
    protected override async Task OnClickHandler(MouseEventArgs ev)
    {
        base.Disabled = true;

        if (EditContext == null)
            await OnClick.InvokeAsync();
        else if (EditContext.Validate())
            await OnClick.InvokeAsync();

        base.Disabled = false;
        await InvokeAsync(() => StateHasChanged());
    }
}
