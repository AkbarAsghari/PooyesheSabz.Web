namespace UI.AppSettings;

public sealed class GlobalSettings
{
    public const string ApplicationName = "پویش سبز کریم الائمه";
    public const bool RightToLeft = true;
    public const bool DarkMode = false;
    public const string APIBaseAddress = "https://localhost:7090/";
}

public sealed class AuthorizeRoles
{
    public const string Admin = "Admin";
    public const string Writer = "Writer";
    public const string User = "User";
}