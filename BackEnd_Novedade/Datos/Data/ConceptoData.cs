using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class ConceptoData
    {

        public async Task<List<Concepto>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString ))
            {
                using (SqlCommand cmd = new SqlCommand("nom_concepto_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 //   cmd.Parameters.Add(new SqlParameter("@cantidad_nov", Novedad.Cantidad));
                    var response = new List<Concepto>();
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
        public async Task<Concepto> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_concepto_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_concepto", Id));
                    Concepto response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = (MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }
        private Concepto MapToValue(SqlDataReader reader)
        {
            return new Concepto()
            {
                Id = (decimal)reader["cnom_codigo"],
                Nombre = (string)reader["Cnom_concepto"],
                TipoConcepto = (decimal)reader["cnom_tipo_concepto"],
                Operacion = (string)reader["cnom_operacion"],
                Cantidad = (bool)reader["cnom_sw_cantidad"],
                Valor = (bool)reader["cnom_valores_permitidos"],
                Porcentaje = (decimal)reader["cpor_porcentaje"],
                PorHora = (bool)reader["por_hora"]
                
            };
        }
    }
}
