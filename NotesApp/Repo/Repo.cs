using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;
using System.Numerics;

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
            var players = await _context.Notes
            .OrderBy(x => x.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            var count = await _context.Notes.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Note>(players, pageIndex, totalPages);
        }
        #endregion
    }
}
