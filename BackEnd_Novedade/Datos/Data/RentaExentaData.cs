using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class RentaExentaData
    {


        public async Task Insert(RentaExenta RentaExenta, int id)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_rentas_exentas_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@renta_exenta", RentaExenta.Rentaexenta));
                    cmd.Parameters.Add(new SqlParameter("@AFC", RentaExenta.AFT));
                    cmd.Parameters.Add(new SqlParameter("@pension_volun", RentaExenta.PensionVoluntaria));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task<List<RentaExenta>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ret_rentas_exentas_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<RentaExenta>();
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


        private RentaExenta MapToValue(SqlDataReader reader)
        {
            return new RentaExenta()
            {
                Nombre = (string)reader["Nombre"],
                AFT = (decimal)reader["ren_AFC"],
                PensionVoluntaria= (decimal)reader["ren_pension_volun"],
                Rentaexenta= (decimal)reader["ren_renta_exenta"],
                Total = (decimal)reader["ren_total"],

            };
        }
    }
}
