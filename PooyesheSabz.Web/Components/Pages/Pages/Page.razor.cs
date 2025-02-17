﻿using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.DTOs.Repositories.Pages;
using PooyesheSabz.Web.Interfaces.Repositories;

namespace PooyesheSabz.Web.Components.Pages.Pages;

partial class Page
{
    [Inject] public IPageRepository _PageRepository { get; set; }
    [Inject] public NavigationManager _NavigationManager { get; set; }

    [Parameter] public string URL { get; set; }

    PublishPageDTO? _PublishPageDTO;
    string[]? keywords;

    protected override async Task OnInitializedAsync()
    {
        _PublishPageDTO = await _PageRepository.GetPageByURLAsync(url: $"{URL}");

        if (_PublishPageDTO == null)
        {
            _NavigationManager.NavigateTo("404");
        }
        var pageMetadata = await _PageRepository.GetPageMetadataAsync($"{URL}");

        keywords = pageMetadata == null ? null : pageMetadata.Keywords;

        await InvokeAsync(() => StateHasChanged());
    }
}
