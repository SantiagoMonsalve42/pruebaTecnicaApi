using DTO.Common;

namespace NEGOCIO.Interfaces
{
    public interface IEstudianteService
    {
        Task<HttpResponseDto> AsignarMateria(int idEstudiante, int idMateria);
    }
}
