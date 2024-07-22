namespace PooyesheSabz.Web.Interfaces.Providers
{
    public interface IAuthenticationProvider
    {
        Task Login(string token);
        Task Logout();
    }
}
