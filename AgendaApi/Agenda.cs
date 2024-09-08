namespace AgendaApi
{
    public class Agenda
    {
        public required int Id { get; set; }

        public Note? Note { get; set; }
    }
}
