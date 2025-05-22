using System.Security.Cryptography.X509Certificates;
using DATA.Implementations;
using DATA.Interfaces;
using DATA.ModelData;
using DTO.Common;
using DTO.Transport.Response;
using NEGOCIO.Interfaces;

namespace NEGOCIO.Implementations
{
    public class EstudianteService: IEstudianteService
    {
        private readonly IEstudianteMateriaServiceDAO _estudianteMateria;
        private readonly IProfesorMateriaServiceDAO _profesorMateria;
        private readonly IMateriaServiceDAO _materiaServiceDAO;
        private readonly IEstudianteServiceDAO _estudianteServiceDAO;
        private readonly IProfesoreServiceDAO _profesorServiceDAO;
        public EstudianteService(IEstudianteMateriaServiceDAO estudianteMateria,
                                IProfesorMateriaServiceDAO profesorMateria,
                                IMateriaServiceDAO materiaServiceDAO,
                                IEstudianteServiceDAO estudianteServiceDAO,
                                IProfesoreServiceDAO profesoreServiceDAO)
        {
            _estudianteMateria = estudianteMateria;
            _profesorMateria = profesorMateria;
            _materiaServiceDAO = materiaServiceDAO;
            _estudianteServiceDAO = estudianteServiceDAO;
            _profesorServiceDAO = profesoreServiceDAO;
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

        public async Task<HttpResponseDto> ConsultarDetalle(int idEstudiante)
        {
            Estudiante? estudianteExiste = await _estudianteServiceDAO.GetByIdAsync(idEstudiante);
            if(estudianteExiste == null)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Data = "Estudiante no existe."
                };
            }
            List<Materia> listado = _materiaServiceDAO.GetAllAsync().Result.ToList();
            List<ProfesorMateria> listadoprofesoresXMaterias = _profesorMateria.GetAllAsync().Result.ToList();
            List<EstudianteMateria> estudianteMaterias = _estudianteMateria.GetAllAsync().Result.ToList();
            List<Profesore> listadoprofesore = _profesorServiceDAO.GetAllAsync().Result.ToList();
            var materiasAsignadas = from profeMaterias in listadoprofesoresXMaterias
                                      join materia in listado
                                      on profeMaterias.MateriaId equals materia.MateriaId
                                      join estudiante in estudianteMaterias
                                      on profeMaterias.MateriaId equals estudiante.MateriaId
                                      join profe in listadoprofesore
                                      on profeMaterias.ProfesorId equals profe.ProfesorId
                                      where estudiante.EstudianteId == idEstudiante
                                      select new
                                      {
                                          materia.MateriaId,
                                          NombreMateria = materia.Nombre,
                                          materia.Creditos,
                                          NombreProfe = profe.Nombre
                                      };
            List<ObtenerMaterias> materias = new List<ObtenerMaterias>();
            foreach (var item in materiasAsignadas)
            {
                materias.Add(new ObtenerMaterias()
                {
                    Creditos = item.Creditos,
                    Id = item.MateriaId,
                    Nombre = item.NombreMateria,
                    NombreProfe = item.NombreProfe
                });
            }
            return new HttpResponseDto
            {
                Status = true,
                Data = new ObtenerDetalleEstudiante
                {
                    Apellido =estudianteExiste.Apellido,
                    Nombre = estudianteExiste.Nombre,
                    Email = estudianteExiste.Email,
                    Materias = materias
                }
            };

        }
    }
}
