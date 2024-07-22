using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Supports;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Supports;

partial class New
{
    [Inject] ISupportRepository _SupportRepository { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }

    MudForm _CashPaymentForm;
    string _Amount;

    async Task GoToPay()
    {
        await _CashPaymentForm.Validate();

        if (_CashPaymentForm.IsValid)
        {
            if (int.TryParse(_Amount, out int amount))
            {
                var paymentLink = await _SupportRepository.NewSupportAsync(new NewSupportDTO { Amount = amount, SupportType = Enums.SupportTypeEnum.Cash });

                if (!String.IsNullOrEmpty(paymentLink))
                {
                    _NavigationManager.NavigateTo(paymentLink);
                }
            }
            else
            {
                _Snackbar.Add("مبلغ وارد شده صحیح نمیباشد", Severity.Warning);
            }
        }
    }
}
