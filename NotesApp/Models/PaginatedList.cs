namespace NotesApp.Models
{
    public class PaginatedList<T>
    {
        #region Fields
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPage { get; }
        public bool HasPrevPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPage;
        #endregion

        #region CTOR
        public PaginatedList(List<T>item, int pageIndex, int totalPage)
        {
            Items = item;
            PageIndex = pageIndex;
            TotalPage = totalPage;
        }
        #endregion
    }
}
