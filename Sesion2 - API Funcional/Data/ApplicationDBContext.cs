using Microsoft.EntityFrameworkCore;
using Sesion2___API_Funcional.Models;
using System.Security.Cryptography.X509Certificates;

namespace Sesion2___API_Funcional.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
