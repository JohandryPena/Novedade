using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class ProcedimientoData
    {
        public async Task<List<Procedimiento>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_procedimiento_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Procedimiento>();
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

        public async Task<Procedimiento> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_procedimiento_get_id", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_procedimiento", Id));
                    Procedimiento response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task Insert(Procedimiento value)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_procedimiento_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@descripcion_procedimiento", value.Descripcion));
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task Update(int Id, Procedimiento value)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_procedimiento_update", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_procedimiento", Id));
                    cmd.Parameters.Add(new SqlParameter("@descripcion_procedimiento", value.Descripcion));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_procedimiento_del", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_procedimiento", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }


        private Procedimiento MapToValue(SqlDataReader reader)
        {
            return new Procedimiento()
            {
                Id = (int)reader["id_procedimiento"],
                Descripcion = (string)reader["descripcion_procedimiento"],
                Estado = (int)reader["estado_procedimiento"],
               
            };
        }
    }
}
