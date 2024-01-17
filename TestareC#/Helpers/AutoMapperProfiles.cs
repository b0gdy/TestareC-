using AutoMapper;
using TestareC_.DTOs;
using TestareC_.Models;

namespace TestareC_.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Note, NoteDTO>();
            CreateMap<NoteDTO, Note>();
            CreateMap<Materie, MaterieDTO>();
            CreateMap<MaterieDTO, Materie>();
        }

    }
}
