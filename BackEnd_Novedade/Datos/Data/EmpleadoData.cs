
using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class EmpleadoData
    {

        public async Task<List<Empleado>> GetAll(string Parametro)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_empleados_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@parametro", Parametro));
                    List<Empleado> response = new List<Empleado>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<Empleado> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_empleados_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_empleado", Id));
                    Empleado response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response=(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Empleado MapToValue(SqlDataReader reader)
        {
            return new Empleado()
            {
                Id = (decimal)reader["empl_codigo"],
                Cedula = (string)reader["empl_identificacion"],
                Nombre = (string)reader["Nombre"],
                Salario = (decimal)reader["emps_sueldo"],

            };

        }
    } 
}
