using System.Security.Cryptography.X509Certificates;
using DATA.Implementations;
using DATA.Interfaces;
using DATA.ModelData;
using DTO.Common;
using NEGOCIO.Interfaces;

namespace NEGOCIO.Implementations
{
    public class EstudianteService: IEstudianteService
    {
        private readonly IEstudianteMateriaServiceDAO _estudianteMateria;
        private readonly IProfesorMateriaServiceDAO _profesorMateria;
        private readonly IMateriaServiceDAO _materiaServiceDAO;
        public EstudianteService(IEstudianteMateriaServiceDAO estudianteMateria,
                                IProfesorMateriaServiceDAO profesorMateria,
                                IMateriaServiceDAO materiaServiceDAO)
        {
            _estudianteMateria = estudianteMateria;
            _profesorMateria = profesorMateria;
            _materiaServiceDAO = materiaServiceDAO;
        }
        public async Task<HttpResponseDto> AsignarMateria(int idEstudiante, int idMateria)
        {
            //Validar que tenga tres materias
            List<EstudianteMateria?> materiasActuales=  await _estudianteMateria.GetByIdAsync(idEstudiante);
            if (materiasActuales.Any(x => x.MateriaId == idMateria))
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "El estudiante ya tiene asignada la materia"
                };
            }
            if (materiasActuales.Count >= 3)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "El estudiante ya tiene tres materias asignadas"
                };
            }
            //Validare que no repita profesor
            //obtener el id del profesor de la materia
            List<Materia> listado = _materiaServiceDAO.GetAllAsync().Result.ToList();
            List<ProfesorMateria> listadoprofesoresXMaterias = _profesorMateria.GetAllAsync().Result.ToList();
            List<EstudianteMateria> estudianteMaterias = _estudianteMateria.GetAllAsync().Result.ToList();
            var profesorMateriaNueva = from profeMaterias in listadoprofesoresXMaterias
                                  where profeMaterias.MateriaId == idMateria
                                  select profeMaterias.ProfesorId;
            int idProfesorMateriaNueva = profesorMateriaNueva.FirstOrDefault();

            var profesoresAsignados = from profeMaterias in listadoprofesoresXMaterias
                                      join materia in listado
                                      on profeMaterias.MateriaId equals materia.MateriaId
                                      join estudiante in estudianteMaterias
                                      on profeMaterias.MateriaId equals estudiante.MateriaId
                                      where estudiante.EstudianteId == idEstudiante
                                      select new {
                                            profesorId = profeMaterias.ProfesorId,
                                            materiaId = materia.MateriaId
                                      };

            if (profesoresAsignados.Any(x=> x.profesorId == idProfesorMateriaNueva))
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "El estudiante ya tiene asignada una materia con el mismo profesor"
                };
            }

            //insertar
            await _estudianteMateria.CreateAsync(new EstudianteMateria
            {
                EstudianteId = idEstudiante,
                MateriaId = idMateria
            });
            return new HttpResponseDto
            {
                Status = true,
                Data = "Materia asignada correctamente"
            };
        }
    }
}
