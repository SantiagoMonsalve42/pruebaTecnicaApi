using System.Text;
using COMMON.Utilities;
using DATA.Implementations;
using DATA.Interfaces;
using DATA.ModelData;
using DTO.Common;
using DTO.Transport.Request;
using NEGOCIO.Interfaces;

namespace NEGOCIO.Implementations
{
    public class SesionService : ISesionService
    {
        private readonly IEstudianteServiceDAO _estudianteServiceDAO;
        public SesionService(IEstudianteServiceDAO estudianteServiceDAO) {
            _estudianteServiceDAO = estudianteServiceDAO;
        }
        public async Task<HttpResponseDto> Login(string username, string password)
        {
            List<Estudiante> listado = _estudianteServiceDAO.GetAllAsync().Result.ToList();
            if(listado.Count == 0)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "No hay estudiantes registrados"
                };
            }
            Estudiante? existe = listado.Where(x => x.Email == username && x.Contraseña == Util.GetSHA256(password)).FirstOrDefault();
            if(existe == null)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = "Usuario o contraseña incorrectos"
                };
            }
            return new HttpResponseDto
            {
                Status = true,
                Data = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))
            };
        }

        public async Task<HttpResponseDto> Registro(CrearEstudiante request)
        {
            List<Estudiante> listado = _estudianteServiceDAO.GetAllAsync().Result.ToList();
            if (listado.Count > 0)
            {
                Estudiante? existe = listado.Where(x => x.Email == request.Email).FirstOrDefault();
                if(existe != null)
                {
                    return new HttpResponseDto
                    {
                        Status = false,
                        Error = "El correo ya existe"
                    };
                }
            }
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Email = request.Email,
                    Contraseña = Util.GetSHA256(request.Contraseña)
                };
                await _estudianteServiceDAO.CreateAsync(estudiante);
                return new HttpResponseDto
                {
                    Status = true,
                    Data = "Estudiante registrado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseDto
                {
                    Status = false,
                    Error = ex.Message
                };
            }

        }
    }
}
