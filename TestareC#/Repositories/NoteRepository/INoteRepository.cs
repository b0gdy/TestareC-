using TestareC_.DTOs;
using TestareC_.Models;

namespace TestareC_.Repositories.NoteRepository
{
    public interface INoteRepository
    {

        List<MaterieDTO> GetMateriiAndNoteByStudent(int Student_Id);

        double GetMediaGeneralaByStudent(int Student_Id);

    }
}
