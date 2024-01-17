using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestareC_.DTOs;
using TestareC_.Models;
using TestareC_.Repositories.NoteRepository;

namespace TestareC_.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NoteController
    {

        public INoteRepository _noteRepository { get; set; }

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet("GetMateriiAndNoteByStudent/{Student_Id}")]
        public ActionResult<List<MaterieDTO>> GetMateriiAndNoteByStudent(int Student_Id)
        {
            var materieDTOs = _noteRepository.GetMateriiAndNoteByStudent(Student_Id);
            return materieDTOs;
        }

        [HttpGet("GetMediaGeneralaByStudent/{Student_Id}")]
        public ActionResult<double> GetMediaGeneralaByStudent(int Student_Id)
        {
            var medie = _noteRepository.GetMediaGeneralaByStudent(Student_Id);
            return medie;
        }


    }
}
