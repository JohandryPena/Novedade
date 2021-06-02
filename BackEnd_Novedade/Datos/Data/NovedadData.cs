
using Modelo.Models;
using Modelo.Models.Sesion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class NovedadData
    {
        public async Task<List<Novedad>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Novedad>();
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
        public async Task<List<Novedad>> GetPorFecha(DateTime fechaInico, DateTime fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaIncio", fechaInico));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
                    var response = new List<Novedad>();
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

        public async Task<Novedad> GetById(int Id)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_nov", Id));
                    Novedad response = null;
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
        public async Task<List<Novedad>> GetByString(string parametro)
        {

            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_get", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@parametro", parametro));
                    var response = new List<Novedad>();
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


        public async Task Insert(Novedad Novedad)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_add", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cantidad_nov", Novedad.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@valor_total_nov", Novedad.ValorTotal));
                    cmd.Parameters.Add(new SqlParameter("@valor_unitario_nov", Novedad.ValorUnitario));
                    cmd.Parameters.Add(new SqlParameter("@fecha_novedad_nov", Novedad.FechaNovedad));
                    cmd.Parameters.Add(new SqlParameter("@id_empleado_nov", Novedad.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@id_concepto_nov", Novedad.IdConcepto));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task Update(int Id, Novedad Novedad)
        {
            using (SqlConnection sql = new SqlConnection(Conexion.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("nom_novedad_update", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_novedad", Id));
                    cmd.Parameters.Add(new SqlParameter("@cantidad_nov", Novedad.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@valor_total_nov", Novedad.ValorTotal));
                    cmd.Parameters.Add(new SqlParameter("@valor_unitario_nov", Novedad.ValorUnitario));
                    cmd.Parameters.Add(new SqlParameter("@fecha_novedad_nov", Novedad.FechaNovedad));
                    cmd.Parameters.Add(new SqlParameter("@id_concepto_nov", Novedad.IdConcepto));


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
                using (SqlCommand cmd = new SqlCommand("nom_novedad_update", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_novedad", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }


        private Novedad MapToValue(SqlDataReader reader)
        {
            return new Novedad()
            {
                Id= (int)reader["nov_id"],
                Cantidad= (decimal)reader["nov_cantidad"],
                ValorUnitario = (decimal)reader["nov_valor_unitario"],
                ValorTotal = (decimal)reader["nov_valor_totales"],
                FechaNovedad = (DateTime)reader["nov_fecha_novedad"],
                NombreConcepto = (string)reader["Cnom_concepto"],
                IdConcepto=(decimal)reader["cnom_codigo"],
                IdEmpleado = (decimal)reader["empl_codigo"],
                 NombreEmpleado=(string)reader["empl_primer_nombre"],
                 ApellidoEmpleado = (string)reader["empl_primer_apellido"],
                liquidacion=(bool)reader["nov_liquidada"],
                Operacion= (string)reader["cnom_operacion"]
            };
        }
    }
}
