using System.Data.SqlClient;
using System.Data;

namespace DLLSQL
{
    public class ClaseSQL
    {
        public List<Auditores>? ListadeAuditores;
        public bool Guardar(string Auditor, string Empresa, string Resultado, string Imagen, string ImagenFondo, string Latitud, string Longitud)
        {
            var Conexion = new SqlConnection("Server=tcp:davidaguilasvr.database.windows.net,1433;Initial Catalog=Auditorias;Persist Security Info=False;User ID=david;Password=Sqlsiempre123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            try
            {
                var Insertar = new SqlCommand("EXEC Guardar '" + Auditor + "','" + Empresa + "','" + Resultado + "','"+Imagen+"','"+ImagenFondo+"','"+Latitud+"','"+Longitud+"'", Conexion);
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        public List<Auditores> Consulta(int ID)
        {
            var dt = new DataTable();
            var Conexion = new SqlConnection("Server=tcp:davidaguilasvr.database.windows.net,1433;Initial Catalog=Auditorias;Persist Security Info=False;User ID=david;Password=Sqlsiempre123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var cmd = new SqlCommand("EXEC Consultar'" + ID + "'", Conexion);
            try
            {
                ListadeAuditores = new List<Auditores>();
                Conexion.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Auditores auditor = new Auditores();
                    auditor.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    auditor.Auditor = dt.Rows[i]["Auditor"].ToString();
                    auditor.Empresa = dt.Rows[i]["Empresa"].ToString();
                    auditor.Resultado = dt.Rows[i]["Resultado"].ToString();
					auditor.Imagen = dt.Rows[i]["Imagen"].ToString();
					auditor.ImagenFondo = dt.Rows[i]["ImagenFondo"].ToString();
					auditor.Latitud = dt.Rows[i]["Latitud"].ToString();
					auditor.Longitud = dt.Rows[i]["Longitud"].ToString();
					ListadeAuditores.Add(auditor);
                }
                return ListadeAuditores;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return ListadeAuditores;
            }
        }

        public List<Auditores> ConsultaTodo()
        {
            var dt = new DataTable();
            var Conexion = new SqlConnection("Server=tcp:davidaguilasvr.database.windows.net,1433;Initial Catalog=Auditorias;Persist Security Info=False;User ID=david;Password=Sqlsiempre123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var cmd = new SqlCommand("EXEC ConsultarTodo", Conexion);
            try
            {
                ListadeAuditores = new List<Auditores>();
                Conexion.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Auditores auditor = new Auditores();
                    auditor.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    auditor.Auditor = dt.Rows[i]["Auditor"].ToString();
                    auditor.Empresa = dt.Rows[i]["Empresa"].ToString();
                    auditor.Resultado = dt.Rows[i]["Resultado"].ToString();
					auditor.Imagen = dt.Rows[i]["Imagen"].ToString();
					auditor.ImagenFondo = dt.Rows[i]["ImagenFondo"].ToString();
					auditor.Latitud = dt.Rows[i]["Latitud"].ToString();
					auditor.Longitud = dt.Rows[i]["Longitud"].ToString();
					ListadeAuditores.Add(auditor);
                }
                return ListadeAuditores;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return ListadeAuditores;
            }
        }
    }

    public class Auditores
    {
        public int ID { get; set; }
        public string Auditor { get; set; }
        public string Empresa { get; set; }
        public string Resultado { get; set; }
		public string Imagen { get; set; }
		public string ImagenFondo { get; set; }
		public string Latitud { get; set; }
		public string Longitud { get; set; }
	}
}