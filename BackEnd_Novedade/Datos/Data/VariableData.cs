
using Modelo.Models.Sesion;
using Retefuente.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class VariableData
    {
        public async Task<List<Variable>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_variable_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Variable>();
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

        public async Task<Variable> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_variable_get_id", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_variable", Id));
                    Variable response = null;
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

        public async Task<Variable> GetByString(string Parametro)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_variable_get_id", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Parametro", Parametro));
                    Variable response = null;
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

        public async Task Insert(Variable Variable)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_variable_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
               
                    cmd.Parameters.Add(new SqlParameter("@rango_min_variable", Variable.RangoMin));
                    cmd.Parameters.Add(new SqlParameter("@rango_max_variable", Variable.RangoMax));
                    cmd.Parameters.Add(new SqlParameter("@tarifa_variable", Variable.Tarifa));
                    cmd.Parameters.Add(new SqlParameter("@descripcion_variable", Variable.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@uvt_sumar_variable", Variable.UvtSumar));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task Update(int Id, Variable Variable)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_variable_update", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_variable", Id));
                    cmd.Parameters.Add(new SqlParameter("@rango_min_variable", Variable.RangoMin));
                    cmd.Parameters.Add(new SqlParameter("@rango_max_variable", Variable.RangoMax));
                    cmd.Parameters.Add(new SqlParameter("@tarifa_variable", Variable.Tarifa));
                    cmd.Parameters.Add(new SqlParameter("@descripcion_variable", Variable.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@uvt_sumar_variable", Variable.UvtSumar));

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
                using (SqlCommand cmd = new SqlCommand("ret_variable_del", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_variable", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }


        private Variable MapToValue(SqlDataReader reader)
        {
            return new Variable()
            {
                Id= (int)reader["id_variable"],
                Descripcion = (string)reader["descripcion_variable"],
                RangoMax = (int)reader["rango_max_variable"],
                RangoMin = (int)reader["rango_min_variable"],
                Tarifa = (decimal)reader["tarifa_variable"],
                UvtSumar = (decimal)reader["uvt_sumar_variable"]
            };
        }
    }
}
