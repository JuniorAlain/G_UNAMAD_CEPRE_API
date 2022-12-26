using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_CicloData : ConvertVersion
    {
        ConnectionBd cn = new ConnectionBd();
        public async Task<List<G_CicloModel>> G_CicloSelectAll()
        {
            var lista = new List<G_CicloModel>();
            //using para la conexion
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                //using para ejecutar el procedimiento almacenado
                using (var cmd = new SqlCommand("SP_G_CicloSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    //using para hacer el recorrido de datos
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var g_CicloModel = new G_CicloModel();
                            g_CicloModel.IdCiclo = (string)item["idCiclo"];
                            g_CicloModel.NCiclo = (string)item["nCiclo"];
                            g_CicloModel.Periodo = (string)item["periodo"];
                            g_CicloModel.FInicio = (DateTime)item["fInicio"];
                            g_CicloModel.FFin = (DateTime)item["fFin"];
                            g_CicloModel.EProgreso = (int)item["eProgreso"];
                            g_CicloModel.Activo = (int)item["activo"];
                            g_CicloModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CicloModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_CicloModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_CicloModel> G_CicloSelectId(string idCiclo)
        {
            var g_CicloModel = new G_CicloModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CicloSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCiclo", idCiclo);
                    await sql.OpenAsync();

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_CicloModel.IdCiclo = (string)item["idCiclo"];
                            g_CicloModel.NCiclo = (string)item["nCiclo"];
                            g_CicloModel.Periodo = (string)item["periodo"];
                            g_CicloModel.FInicio = (DateTime)item["fInicio"];
                            g_CicloModel.FFin = (DateTime)item["fFin"];
                            g_CicloModel.EProgreso = (int)item["eProgreso"];
                            g_CicloModel.Activo = (int)item["activo"];
                            g_CicloModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CicloModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }
                    }
                }
            }
            return g_CicloModel;
        }
        public async Task<ResponseSP> G_CicloInsert(G_CicloModel g_CicloModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CicloInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCiclo", g_CicloModel.IdCiclo);
                    cmd.Parameters.AddWithValue("@nCiclo", g_CicloModel.NCiclo);
                    cmd.Parameters.AddWithValue("@periodo", g_CicloModel.Periodo);
                    cmd.Parameters.AddWithValue("@fInicio", g_CicloModel.FInicio);
                    cmd.Parameters.AddWithValue("@fFin", g_CicloModel.FFin);
                    cmd.Parameters.AddWithValue("@eProgreso", g_CicloModel.EProgreso);
                    cmd.Parameters.AddWithValue("@activo", g_CicloModel.Activo);
                    await sql.OpenAsync();
                    //await cmd.ExecuteNonQueryAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            responseSP.TotalAffectedRecord = (int)item["totalAffectedRecord"];
                            responseSP.MessageException = (string)item["messageException"];
                        }
                    }
                }
            }
            return responseSP;
        }
        public async Task<ResponseSP> G_CicloUpdate(G_CicloModel g_CicloModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CicloUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCiclo", g_CicloModel.IdCiclo);
                    cmd.Parameters.AddWithValue("@nCiclo", g_CicloModel.NCiclo);
                    cmd.Parameters.AddWithValue("@periodo", g_CicloModel.Periodo);
                    cmd.Parameters.AddWithValue("@fInicio", g_CicloModel.FInicio);
                    cmd.Parameters.AddWithValue("@fFin", g_CicloModel.FFin);
                    cmd.Parameters.AddWithValue("@eProgreso", g_CicloModel.EProgreso);
                    cmd.Parameters.AddWithValue("@activo", g_CicloModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion(g_CicloModel.CVersion));
                    await sql.OpenAsync();
                    //await cmd.ExecuteNonQueryAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            responseSP.TotalAffectedRecord = (int)item["totalAffectedRecord"];
                            responseSP.MessageException = (string)item["messageException"];
                        }
                    }
                }
            }
            return responseSP;
        }
        public async Task<ResponseSP> G_CicloDelete(string idCiclo, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CicloDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCiclo", idCiclo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion(cVersion));
                    await sql.OpenAsync();
                    //await cmd.ExecuteNonQueryAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            responseSP.TotalAffectedRecord = (int)item["totalAffectedRecord"];
                            responseSP.MessageException = (string)item["messageException"];
                        }
                    }
                }
            }
            return responseSP;
        }
    }
}
