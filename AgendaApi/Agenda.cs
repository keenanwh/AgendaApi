namespace AgendaApi
{
    public class Agenda(Note note)
    {
        public int Id { get; } = _nextId++;
        public Note? Note { get; set; } = note;

        private static int _nextId = 0;
    }
}