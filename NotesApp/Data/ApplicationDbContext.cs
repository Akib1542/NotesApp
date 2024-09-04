using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region CTOR
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Note> Notes { get; set; }
        #endregion
    }
}
