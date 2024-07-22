namespace PooyesheSabz.Web.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<bool> VerifyAsync(long trackId);
    }
}
