using Microsoft.AspNetCore.Components;
using PooyesheSabz.Web.Utilities;

namespace PooyesheSabz.Web.Components.Custom;
partial class UserProfileImage
{
    [Parameter] public int Size { get; set; }
    [Parameter] public string UserId { get; set; } = string.Empty;

    private string GenerateProfilePhoto(string userId)
    {
        return ProfileImageGenerator.GenerateSVG(userId, size: Size == 0 ? 100 : Size);
    }
}
