using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_AulaData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_AulaModel>> G_AulaSelectAll()
        {
            var lista = new List<G_AulaModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_AulaSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_AulaModel = new G_AulaModel();
                            g_AulaModel.IdAula = (string)item["idAula"];
                            g_AulaModel.NAula = (string)item["nAula"];
                            g_AulaModel.Activo = (int)item["activo"];
                            g_AulaModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_AulaModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_AulaModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_AulaModel> G_AulaSelectId(string idAula)
        {
            var g_AulaModel = new G_AulaModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_AulaSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAula", idAula);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_AulaModel.IdAula = (string)item["idAula"];
                            g_AulaModel.NAula = (string)item["nAula"];
                            g_AulaModel.Activo = (int)item["activo"];
                            g_AulaModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_AulaModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_AulaModel;
        }
        public async Task<ResponseSP> G_AulaInsert(G_AulaModel g_AulaModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_AulaInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAula", g_AulaModel.IdAula);
                    cmd.Parameters.AddWithValue("@nAula", g_AulaModel.NAula);
                    cmd.Parameters.AddWithValue("@activo", g_AulaModel.Activo);
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
        public async Task<ResponseSP> G_AulaUpdate(G_AulaModel g_AulaModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_AulaUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAula", g_AulaModel.IdAula);
                    cmd.Parameters.AddWithValue("@nAula", g_AulaModel.NAula);
                    cmd.Parameters.AddWithValue("@activo", g_AulaModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_AulaModel.CVersion));
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
        public async Task<ResponseSP>G_AulaDelete(string idAula, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_AulaDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAula", idAula);
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
