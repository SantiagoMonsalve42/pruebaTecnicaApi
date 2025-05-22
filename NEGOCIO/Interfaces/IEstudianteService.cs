using DTO.Common;

namespace NEGOCIO.Interfaces
{
    public interface IEstudianteService
    {
        Task<HttpResponseDto> AsignarMateria(int idEstudiante, int idMateria);
        Task<HttpResponseDto> ConsultarDetalle(int idEstudiante);
        Task<HttpResponseDto> DesasignarMateria(int idEstudiante, int idMateria);
    }
}
