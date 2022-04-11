namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkManagmenet
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
