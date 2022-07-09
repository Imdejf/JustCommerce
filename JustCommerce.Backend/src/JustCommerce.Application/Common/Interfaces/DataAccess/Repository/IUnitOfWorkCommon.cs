namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkCommon
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

