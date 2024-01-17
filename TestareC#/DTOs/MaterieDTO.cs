using TestareC_.Models;
using static Azure.Core.HttpHeader;

namespace TestareC_.DTOs
{
    public class MaterieDTO
    {

        public int Id { get; set; }

        public string? Nume { get; set; }

        public List<NoteDTO> NoteDTOs { get; set; } = new List<NoteDTO>();

    }
}
