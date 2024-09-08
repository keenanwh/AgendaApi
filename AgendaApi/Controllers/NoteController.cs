using AgendaApi;
using Microsoft.AspNetCore.Mvc;

namespace NoteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private static List<Note> Notes = [];

        // GET: api/Note
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            return Notes;
        }

        // GET: api/Note/{id}
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var Note = Notes.Find(a => a.Id == id);
            if (Note == null)
            {
                return NotFound();
            }
            return Note;
        }

        // POST: api/Note
        [HttpPost]
        [ProducesResponseType(typeof(Note), StatusCodes.Status200OK)]
        public IActionResult CreateNote([FromBody] Note newNote)
        {
            Notes.Add(newNote);
            return CreatedAtAction(nameof(GetNoteById), new { id = newNote.Id }, newNote);
        }

        // PUT: api/Note/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note updatedNote)
        {
            var Note = Notes.Find(a => a.Id == id);
            if (Note == null)
            {
                return NotFound();
            }
            Note.Content = updatedNote.Content;
            return NoContent();
        }

        // DELETE: api/Note/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var Note = Notes.Find(a => a.Id == id);
            if (Note == null)
            {
                return NotFound();
            }
            Notes.Remove(Note);
            return NoContent();
        }
    }
}
