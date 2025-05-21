namespace DTO.Transport.Response
{
    public class ObtenerMaterias
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Creditos { get; set; }
        public string? NombreProfe { get; set; }
    }
    public class ObtenerMateriasDetalle
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Creditos { get; set; }
        public string? NombreProfe { get; set; }

        public List<EstudianteDetalle> Estudiantes {get; set; } 
    }
    public class EstudianteDetalle
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
    }
}
