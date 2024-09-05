using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repo
{
    public class Repo : IRepo
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region CTOR
        public Repo(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<PaginatedList<Note>> GetNotes(int pageIndex, int pageSize)
        {
            var notes = _context.Notes
            .OrderBy(x => x.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

            var count = _context.Notes.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Note>(notes, pageIndex, totalPages);
        }
        #endregion
    }
}
