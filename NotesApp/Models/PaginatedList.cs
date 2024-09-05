namespace NotesApp.Models
{
    public class PaginatedList<T>
    {
        #region Fields
        public IQueryable<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPage { get; }
        public bool HasPrevPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPage;
        #endregion

        #region CTOR
        public PaginatedList(IQueryable<T>items, int pageIndex, int totalPage)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPage = totalPage;
        }
        #endregion
    }
}
