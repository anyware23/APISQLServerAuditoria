using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DLLSQL;

namespace API_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        [HttpGet("Almacenar")]
        public string Almacenar(string Auditor, string Empresa, string Resultado, string Imagen, string ImagenFondo, string Latitud, string Longitud)
        {
            var Almacena = new ClaseSQL();
            bool resultado = Almacena.Guardar(
                Auditor,Empresa,Resultado,Imagen,ImagenFondo,Latitud,Longitud);
            if (resultado == true)
            {
                return "Almacenado en SQL Server" +
                    " desde API en .NET con DLL";
            }
            else
            {
                return "No almacenado";
            }
        }

        [HttpGet("Consultar")]

        public JsonResult Consultar(int ID)
        {
            var Consulta = new ClaseSQL();
            var Lista = Consulta.Consulta(ID);
            return new JsonResult(Lista);
        }


        [HttpGet("ConsultarTodo")]

        public JsonResult ConsultaTodo()
        {
            var Consulta = new ClaseSQL();
            var Lista = Consulta.ConsultaTodo();
            return new JsonResult(Lista);
        }

    }
}