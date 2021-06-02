using Modelo.Models;
using Modelo.Models.Sesion;
using Retefuente.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class ValorTributarioData
    {
        public async Task<List<ValorTributario>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_uvt_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ValorTributario>();
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

        public async Task<ValorTributario> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_uvt_get_id", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_uvt", Id));
                    ValorTributario response = null;
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

        public async Task<ValorTributario> GetByString(string Parametro)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_uvt_get_id", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Parametro", Parametro));
                    ValorTributario response = null;
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

        public async Task Insert(ValorTributario ValorTributario)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_uvt_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fecha_uvt", ValorTributario.FechaRetefuente));
                    cmd.Parameters.Add(new SqlParameter("@valor_uvt", ValorTributario.ValorRetefuente));
                    //cmd.Parameters.Add(new SqlParameter("@estado_uvt", 1));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task Update(int Id, ValorTributario ValorTributario)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_uvt_update", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_uvt", Id));
                    cmd.Parameters.Add(new SqlParameter("@fecha_uvt", ValorTributario.FechaRetefuente));
                    cmd.Parameters.Add(new SqlParameter("@valor_uvt", ValorTributario.ValorRetefuente));
                   
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
                using (SqlCommand cmd = new SqlCommand("ret_uvt_del", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_uvt", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }


        private ValorTributario MapToValue(SqlDataReader reader)
        {
            return new ValorTributario()
            {
                IdRetefuente = (int)reader["id_uvt"],
                FechaRetefuente = (decimal)reader["fecha_uvt"],
                ValorRetefuente = (decimal)reader["valor_uvt"],
                Estado= (int)reader["estado_uvt"]
            };
        }
    }
}
