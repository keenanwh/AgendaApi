using System.ComponentModel.DataAnnotations;

namespace AgendaApi
{
    public class Note(string content)
    {
        public int Id { get; } = _nextId++;

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Content { get; set; } = content;

        private static int _nextId = 0;
    }
}
