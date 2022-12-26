using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_TurnoData : ConvertVersion
    {
        ConnectionBd cn = new ConnectionBd();
        public async Task<List<G_TurnoModel>> G_TurnoSelectAll()
        {
            var lista = new List<G_TurnoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_TurnoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_TurnoModel = new G_TurnoModel();
                            g_TurnoModel.IdTurno = (string)item["idTurno"];
                            g_TurnoModel.NTurno = (string)item["nTurno"];
                            g_TurnoModel.Activo = (int)item["activo"];
                            g_TurnoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TurnoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_TurnoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_TurnoModel> G_TurnoSelectId(string idTurno)
        {
            var g_TurnoModel = new G_TurnoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TurnoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTurno", idTurno);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_TurnoModel.IdTurno = (string)item["idTurno"];
                            g_TurnoModel.NTurno = (string)item["nTurno"];
                            g_TurnoModel.Activo = (int)item["activo"];
                            g_TurnoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TurnoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_TurnoModel;
        }
        public async Task<ResponseSP> G_TurnoInsert(G_TurnoModel g_TurnoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TurnoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTurno", g_TurnoModel.IdTurno);
                    cmd.Parameters.AddWithValue("@nTurno", g_TurnoModel.NTurno);
                    cmd.Parameters.AddWithValue("@activo", g_TurnoModel.Activo);
                    await sql.OpenAsync();

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
        public async Task<ResponseSP> G_TurnoUpdate(G_TurnoModel g_TurnoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TurnoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTurno", g_TurnoModel.IdTurno);
                    cmd.Parameters.AddWithValue("@nTurno", g_TurnoModel.NTurno);
                    cmd.Parameters.AddWithValue("@activo", g_TurnoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_TurnoModel.CVersion));
                    await sql.OpenAsync();

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
        public async Task<ResponseSP>G_TurnoDelete(string idTurno, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TurnoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTurno", idTurno);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)cVersion));
                    await sql.OpenAsync();

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
