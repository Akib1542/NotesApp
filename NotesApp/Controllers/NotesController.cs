using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;
using NotesApp.Repo;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly IRepo _repo;
        #endregion

        #region CTOR
        public NotesController(ApplicationDbContext context, IRepo repo)
        {
            _context = context;
            _repo = repo;
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAllNotes(int page = 1, int pageSize = 10)
        {
            var data = await _context.Notes.ToListAsync();
           /* var totalCount = data.Count;
            var totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var notePerPage = data
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();*/

            return Ok(data);
        }
        #endregion

        #region Pagination
        [HttpGet("GetPaginatedNotes")]
        public async Task<ActionResult<ApiResponse>>GetNotes(int pageIndex=1, int pageSize=10)
        {
            var notes = await _repo.GetNotes(pageIndex, pageSize);
            return new ApiResponse(true,null, notes);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> AddNote(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return Ok();
        }
        #endregion

        #region GETbyID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var data = _context.Notes.FirstOrDefault(x => x.Id == id);
            if (data == null) { 
                return NotFound();
            }
            return Ok(data);

        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<IActionResult> UpdateNote(Note updateNote)
        {
            var existingNote = await _context.Notes.FirstOrDefaultAsync(x => x.Id == updateNote.Id);
            if (existingNote == null)
            {
                 return NotFound("There is No Note with this ID");
            }

            existingNote.Title = updateNote.Title;
            existingNote.Description = updateNote.Description;
            existingNote.IsActive = updateNote.IsActive;

            _context.SaveChanges();

            return Ok(existingNote);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var data = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(data);
            _context.SaveChanges();
            return Ok(data);
        }
        #endregion
    }
}
