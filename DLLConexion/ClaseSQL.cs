using System.Data;
using System.Data.SqlClient;

namespace DLLSQL
{
    public class ClaseSQL
    {
        public List<Auditores>? ListadeAuditores;
        public bool Guardar(string Auditor, string Empresa, string Resultado)
        {
            var Conexion = new SqlConnection("Data Source=Andy; Initial Catalog=Auditorias; User ID=sa; Password=Andy123 ");

            try
            {
                var Insertar = new SqlCommand("EXEC Guardar '" + Auditor + "'," + Empresa + "'," + Resultado + "'", Conexion);
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception)
            {
                Conexion.Close();
                return false;
            }
        }

        public List<Auditores> Consulta(int ID)
        {
            SqlConnection Conexion = new SqlConnection("Data Source=Andy;Initial Catalog=Auditoria;" +
                ";User ID=sa;Password=Andy123");
            var dt = new DataTable();
            var cmd = new SqlCommand("EXEC Consultar'"+ID+"'", Conexion);
            try
            {
                ListadeAuditores = new List<Auditores>();
                Conexion.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Conexion.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Auditores Auditor = new Auditores();
                    Auditor.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    Auditor.Auditor = dt.Rows[i]["Auditor"].ToString();
                    Auditor.Empresa = dt.Rows[i]["Empresa"].ToString();
                    Auditor.Resultado = dt.Rows[i]["Resultado"].ToString();
                    ListadeAuditores.Add(Auditor);
                }
                return ListadeAuditores;
            }
            catch (Exception)
            {
                Conexion.Close();
                return ListadeAuditores;
            }

        }

        public List<Auditores> ConsultarTodo()
        {
            SqlConnection Conexion = new SqlConnection("Data Source=Andy;Initial Catalog=Auditoria;" +
                ";User ID=sa;Password=Andy123");
            var dt = new DataTable();
            var cmd = new SqlCommand("EXEC ConsultarTodo'",Conexion);
            try
            {
                ListadeAuditores = new List<Auditores>();
                Conexion.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Conexion.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Auditores Auditor = new Auditores();
                    Auditor.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    Auditor.Auditor = dt.Rows[i]["Auditor"].ToString();
                    Auditor.Empresa = dt.Rows[i]["Empresa"].ToString();
                    Auditor.Resultado = dt.Rows[i]["Resultado"].ToString();
                    ListadeAuditores.Add(Auditor);
                }
                return ListadeAuditores;
            }
            catch (Exception)
            {
                Conexion.Close();
                return ListadeAuditores;
            }

        }

        public class Auditores
        {
            public int ID { get; set; }
            public string Auditor { get; set; }
            public string Empresa { get; set; }
            public string Resultado { get; set; }
        }
    }
}