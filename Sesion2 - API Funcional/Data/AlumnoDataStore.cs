using Sesion2___API_Funcional.Models;
using Sesion2___API_Funcional.Models.DTO;

namespace Sesion2___API_Funcional.Data
{
    public static class AlumnoDataStore
    {
        public static List<AlumnoDTO> Alumnos = new List<AlumnoDTO>()
            {
                new AlumnoDTO { Matricula = 1, Nombre = "1", Apellidos = "1", Edad = 23, Telefono = 4545454 },
                new AlumnoDTO { Matricula = 2, Nombre = "2", Apellidos = "2", Edad = 23, Telefono = 4545454 },
                new AlumnoDTO { Matricula = 3, Nombre = "3", Apellidos = "3", Edad = 23, Telefono = 4545454 },
                new AlumnoDTO { Matricula = 4, Nombre = "4", Apellidos = "4", Edad = 23, Telefono = 4545454 }
            };
    }
}
