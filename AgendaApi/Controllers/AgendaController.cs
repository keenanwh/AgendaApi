using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {
        private static List<Agenda> Agendas = [];

        // GET: api/agenda
        [HttpGet]
        public IEnumerable<Agenda> GetAgendas()
        {
            return Agendas;
        }

        // GET: api/agenda/{id}
        [HttpGet("{id}")]
        public ActionResult<Agenda> GetAgendaById(int id)
        {
            var agenda = Agendas.FirstOrDefault(a => a.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }
            return agenda;
        }

        // POST: api/agenda
        [HttpPost]
        public IActionResult CreateAgenda([FromBody] Agenda newAgenda)
        {
            Agendas.Add(newAgenda);
            return CreatedAtAction(nameof(GetAgendaById), new { id = newAgenda.Id }, newAgenda);
        }

        // PUT: api/agenda/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAgenda(int id, [FromBody] Agenda updatedAgenda)
        {
            var agenda = Agendas.FirstOrDefault(a => a.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }
            agenda.Note = updatedAgenda.Note;
            return NoContent();
        }

        // DELETE: api/agenda/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAgenda(int id)
        {
            var agenda = Agendas.FirstOrDefault(a => a.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }
            Agendas.Remove(agenda);
            return NoContent();
        }
    }
}
