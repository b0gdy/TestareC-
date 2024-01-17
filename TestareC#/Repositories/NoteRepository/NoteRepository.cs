using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestareC_.Data;
using TestareC_.DTOs;
using TestareC_.Exceptions;
using TestareC_.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestareC_.Repositories.NoteRepository
{
    public class NoteRepository : INoteRepository
    {
        public UniversitateContext _universitateContext { get; set; }

        private readonly IMapper _mapper;

        public NoteRepository(UniversitateContext universitateContext, IMapper mapper)
        {
            _universitateContext = universitateContext;
            _mapper = mapper;
        }

        // 1. Să se creeze un serviciu web care primește ca parametru id-ul studentului și returnează un json cu materiile și notele obținute.
        public List<MaterieDTO> GetMateriiAndNoteByStudent(int Student_Id)
        {
            var materies = _universitateContext.Materies.Include(m => m.Notes.Where(n => n.StudentId == Student_Id)).Where(m => m.Notes.Any(n => n.StudentId == Student_Id)).ToList();

            var materieDTOs = new List<MaterieDTO>();
            foreach (var m in materies)
            {
                var materieDTO = new MaterieDTO();
                materieDTO = _mapper.Map(m, materieDTO);

                var NoteDTOs = new List<NoteDTO>();
                foreach (var n in m.Notes)
                {
                    var noteDTO = new NoteDTO();
                    noteDTO = _mapper.Map(n, noteDTO);
                    NoteDTOs.Add(noteDTO);
                }

                materieDTO.NoteDTOs = NoteDTOs;
                materieDTOs.Add(materieDTO);
            }

            return materieDTOs;
        }

        // 2. Să se creeze un serviciu web care primește ca parametru id-ul studentului și calculează media generală
        public double GetMediaGeneralaByStudent(int Student_Id)
        {
            var materies = _universitateContext.Materies.Include(m => m.Notes.Where(n => n.StudentId == Student_Id)).Where(m => m.Notes.Any(n => n.StudentId == Student_Id)).ToList();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var medie = new double();
            medie = 0.00D;

            foreach (var m in materies)
            {

                foreach (var n in m.Notes)
                {
                    if(dict.ContainsKey(n.MaterieId))
                    {
                        dict[n.MaterieId] = (int)n.NotaObtinuta;
                    }
                    else
                    {
                        dict.Add(n.MaterieId, (int)n.NotaObtinuta);
                    }

                }

            }

            foreach(var d in dict)
            {
                medie = medie + d.Value;
            }

             medie = medie / dict.Count;

            return medie;
        }


    }
}
