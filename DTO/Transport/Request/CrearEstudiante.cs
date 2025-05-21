using System.ComponentModel.DataAnnotations;

namespace DTO.Transport.Request
{
    public class CrearEstudiante
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
