using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_GrupoData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_GrupoModel>> G_GrupoSelectAll()
        {
            var lista = new List<G_GrupoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_GrupoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_GrupoModel = new G_GrupoModel();
                            g_GrupoModel.IdGrupo = (string)item["idGrupo"];
                            g_GrupoModel.NGrupo = (string)item["nGrupo"];
                            g_GrupoModel.Activo = (int)item["activo"];
                            g_GrupoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_GrupoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_GrupoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_GrupoModel> G_GrupoSelectId(string idGrupo)
        {
            var g_GrupoModel = new G_GrupoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GrupoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGrupo", idGrupo);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_GrupoModel.IdGrupo = (string)item["idGrupo"];
                            g_GrupoModel.NGrupo = (string)item["nGrupo"];
                            g_GrupoModel.Activo = (int)item["activo"];
                            g_GrupoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_GrupoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_GrupoModel;
        }
        public async Task<ResponseSP> G_GrupoInsert(G_GrupoModel g_GrupoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GrupoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGrupo", g_GrupoModel.IdGrupo);
                    cmd.Parameters.AddWithValue("@nGrupo", g_GrupoModel.NGrupo);
                    cmd.Parameters.AddWithValue("@activo", g_GrupoModel.Activo);
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
        public async Task<ResponseSP> G_GrupoUpdate(G_GrupoModel g_GrupoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GrupoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGrupo", g_GrupoModel.IdGrupo);
                    cmd.Parameters.AddWithValue("@nGrupo", g_GrupoModel.NGrupo);
                    cmd.Parameters.AddWithValue("@activo", g_GrupoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_GrupoModel.CVersion));
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
        public async Task<ResponseSP>G_GrupoDelete(string idGrupo, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GrupoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGrupo", idGrupo);
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
