using GameBoi.Models.Layer.Pagination;

namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface IPaginationService
    {
        PagedList <TEntity> CreatePagedList<TEntity>(IQueryable<TEntity> source, int pageNumber, int pageSize);
        Pager CalculatePages(int totalItems, int pageNumber, int pageSize);
    }
}
