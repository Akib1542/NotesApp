using NotesApp.Models;
using System.Numerics;

namespace NotesApp.Repo
{
    public interface IRepo
    {
        Task<PaginatedList<Note>> GetNotes(int pageIndex, int pageSize);
    }
}
