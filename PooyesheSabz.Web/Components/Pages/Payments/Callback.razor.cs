﻿using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.Enums;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Payments;

partial class Callback
{
    [Inject] IPaymentRepository _PaymentRepository { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public long? TrackId { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? Success { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? Status { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public string? OrderId { get; set; }

    bool? IsVerified = null;
    string? Result = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (TrackId.HasValue)
                IsVerified = await _PaymentRepository.VerifyAsync(TrackId.Value);

            if (Status.HasValue)
            {
                switch (Status.Value)
                {
                    case (int)TransactionStatusEnum.PaidConfirmed:
                        Result = String.Empty;
                        break;
                    case (int)TransactionStatusEnum.PaidUnverified:
                        Result = "پرداخت شده - تاییدنشده";
                        break;
                    case (int)TransactionStatusEnum.CanceledByUser:
                        Result = "لغو شده توسط کاربر";
                        break;
                    case (int)TransactionStatusEnum.TheCardNumberIsInvalid:
                        Result = "‌شماره کارت نامعتبر می‌باشد";
                        break;
                    case (int)TransactionStatusEnum.TheAccountBalanceIsInsufficient:
                        Result = "‌موجودی حساب کافی نمی‌باشد";
                        break;
                    case (int)TransactionStatusEnum.TheEnteredPasswordIsWrong:
                        Result = "رمز واردشده اشتباه می‌باشد";
                        break;
                    case (int)TransactionStatusEnum.TheIssuerOfTheCardIsInvalid:
                        Result = "‌صادرکننده‌ی کارت نامعتبر می‌باشد";
                        break;
                    case (int)TransactionStatusEnum.TheCardIsNotAccessible:
                        Result = "‌کارت قابل دسترسی نمی‌باشد";
                        break;
                    case (int)TransactionStatusEnum.TheNumberOfRequestsIsOverTheLimit:
                    case (int)TransactionStatusEnum.TheNumberOfOnlinePaymentsPerDayIsMoreThanTheAllowedLimit:
                    case (int)TransactionStatusEnum.TheAmountOfDailyInternetPaymentIsMoreThanTheAllowedLimit:
                    case (int)TransactionStatusEnum.SwitchError:
                    default:
                        Result = "خطای نامعلوم";
                        break;
                }
            }

            await InvokeAsync(() => StateHasChanged());
        }
    }

    public void NavigateToHome()
    {
        _NavigationManager.NavigateTo("/", true);
    }
}