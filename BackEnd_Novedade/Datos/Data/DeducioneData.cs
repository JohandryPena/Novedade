using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class DeducioneData
    {


        public async Task Insert(Deduciones Deduciones, int id)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_deduciones_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@i_vivienda", Deduciones.InteresVivienda));
                    cmd.Parameters.Add(new SqlParameter("@dependiente", Deduciones.Dependiente));
                    cmd.Parameters.Add(new SqlParameter("@prepagada", Deduciones.Prepagada));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task<List<Deduciones>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_deduciones_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Deduciones>();
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


        private Deduciones MapToValue(SqlDataReader reader)
        {
            return new Deduciones()
            {
                Id=(decimal)reader["ded_id_emp"],
                Nombre = (string)reader["Nombre"],
                Dependiente = (decimal)reader["ded_dependiente"],
                documento = (string)reader["empl_identificacion"],
                InteresVivienda = (decimal)reader["ded_interese_vienda"],
                Prepagada= (decimal)reader["ded_prepagada"],
                Total = (decimal)reader["ded_total"],

            };
        }
    }
}
