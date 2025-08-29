namespace GameBoi.Models.Layer.Pagination
{
    public class PagedList<TEntity>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public Pager Pager { get; set; }
        public List<TEntity> Items { get; set; } = null!;
    }
}
