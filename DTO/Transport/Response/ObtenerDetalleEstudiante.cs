namespace DTO.Transport.Response
{
    public class ObtenerDetalleEstudiante
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public List<ObtenerMaterias>? Materias { get; set; }
    }
}
