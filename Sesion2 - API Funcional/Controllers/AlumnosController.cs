using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sesion2___API_Funcional.Data;
using Sesion2___API_Funcional.Models;
using Sesion2___API_Funcional.Models.DTO;
using System.Linq;

namespace Sesion2___API_Funcional.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlumnosController : ControllerBase
    {
        private readonly ILogger<AlumnosController> _logger;
        
        public AlumnosController(ILogger<AlumnosController> logger) 
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlumnoDTO>> Get()
        {
            return Ok(AlumnoDataStore.Alumnos);
        }

        [HttpGet("{matricula}", Name = "GetAlumno")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AlumnoDTO> get(long matricula)
        {
            _logger.LogInformation("Obteniendo los alumnos");
            
            if (matricula <= 0) 
            {
                _logger.LogError("Error:Bad Request, La Matricula ingresada no es váida.");
                return BadRequest();
            }

            AlumnoDTO? alumno = AlumnoDataStore.Alumnos.FirstOrDefault(u => u.Matricula == matricula);

            if (alumno == null)
            {
                _logger.LogError("El alumno no se encontró.");
                return NotFound();
            }

            _logger.LogInformation("Alumno enviado.");
            return Ok(alumno);
        }

        // POST api/<AlumnosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlumnoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<AlumnoDTO> Post([FromBody] AlumnoDTO alumno)
        {
            if (alumno == null) return BadRequest();
            if (alumno.Matricula > 0) return StatusCode(StatusCodes.Status500InternalServerError);

            AlumnoDTO? ultimoAlumno = AlumnoDataStore.Alumnos.OrderByDescending(u => u.Matricula).FirstOrDefault();
            if (ultimoAlumno != null) alumno.Matricula = ultimoAlumno.Matricula + 1;
            else return StatusCode(StatusCodes.Status500InternalServerError);

            AlumnoDataStore.Alumnos.Add(alumno);

            return CreatedAtRoute("GetAlumno", new {matricula = alumno.Matricula}, alumno);

        }
        // PUT api/<AlumnosController>
        //[HttpPut]
        //[HttpDelete]

    }
}