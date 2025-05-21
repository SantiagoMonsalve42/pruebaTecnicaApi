using DATA.Interfaces;
using DATA.ModelData;
using DTO.Common;
using DTO.Transport.Response;
using NEGOCIO.Interfaces;

namespace NEGOCIO.Implementations
{
    public class MateriaService: IMateriaService
    {
        private readonly IMateriaServiceDAO _materiaServiceDAO;
        private readonly IProfesorMateriaServiceDAO _profesorMateriaServiceDAO;
        private readonly IProfesoreServiceDAO _profesorServiceDAO;
        private readonly IEstudianteMateriaServiceDAO _estudianteMateriaServiceDAO;
        private readonly IEstudianteServiceDAO _estudianteServiceDAO;

        public MateriaService(IMateriaServiceDAO materiaServiceDAO, 
                              IProfesorMateriaServiceDAO profesorMateriaServiceDAO, 
                              IProfesoreServiceDAO profesorServiceDAO,
                              IEstudianteServiceDAO estudianteServiceDAO,
                              IEstudianteMateriaServiceDAO estudianteMateriaServiceDAO)
        {
            _materiaServiceDAO = materiaServiceDAO;
            _profesorMateriaServiceDAO = profesorMateriaServiceDAO;
            _profesorServiceDAO = profesorServiceDAO;
            _estudianteServiceDAO = estudianteServiceDAO;
            _estudianteMateriaServiceDAO = estudianteMateriaServiceDAO;
        }

        public Task<HttpResponseDto> ObtenerMaterias()
        {
            List<Materia> listado = _materiaServiceDAO.GetAllAsync().Result.ToList();
            if (listado.Count == 0)
            {
                return Task.FromResult(new HttpResponseDto
                {
                    Status = false,
                    Error = "No hay materias registradas"
                });
            }
            List<ObtenerMaterias> listadoResponse = new List<ObtenerMaterias>();
            List<ProfesorMateria> listadoprofesoresMaterias = _profesorMateriaServiceDAO.GetAllAsync().Result.ToList();
            List<Profesore> listadoprofesore = _profesorServiceDAO.GetAllAsync().Result.ToList();
            foreach (var materia in listado)
            {
                var profesorMateria = from profeMaterias in listadoprofesoresMaterias
                                      join profe in listadoprofesore
                                      on profeMaterias.ProfesorId equals profe.ProfesorId
                                      where profeMaterias.MateriaId == materia.MateriaId
                                      select  profe.Nombre;
                var nombre=profesorMateria.FirstOrDefault();
                
                listadoResponse.Add(new ObtenerMaterias
                {
                    Id = materia.MateriaId,
                    Nombre = materia.Nombre,
                    Creditos = materia.Creditos,
                    NombreProfe = nombre.ToString()
                });
            }
            return Task.FromResult(new HttpResponseDto
            {
                Status = true,
                Data = listadoResponse
            });
        }
        public async Task<HttpResponseDto> ObtenerDetalleMaterias(int id)
        {
            Materia? materia = await _materiaServiceDAO.GetByIdAsync(id);
            if (materia == null)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "No existe materia con el id solicitado."
                };
            }
            var estudiantesMateria = _estudianteMateriaServiceDAO.GetAllAsync().Result.ToList();
            var estudiantes = _estudianteServiceDAO.GetAllAsync().Result.ToList();
            List<EstudianteDetalle> estudiantesAsignados = (from estu in estudiantesMateria
                                     join estu2 in estudiantes
                                     on estu.EstudianteId equals estu2.EstudianteId
                                     where estu.MateriaId == id
                                     select new EstudianteDetalle
                                     {
                                         Nombre = estu2.Nombre,
                                         Apellido = estu2.Apellido,
                                         Email = estu2.Email
                                     }).ToList();
            return new HttpResponseDto
            {
                Status = true,
                Data = new ObtenerMateriasDetalle
                {
                    Id = materia.MateriaId,
                    Nombre = materia.Nombre,
                    Creditos = materia.Creditos,
                    Estudiantes = estudiantesAsignados
                }
            };
        }
    }
}
