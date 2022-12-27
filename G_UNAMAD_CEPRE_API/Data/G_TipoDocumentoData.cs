using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_TipoDocumentoData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_TipoDocumentoModel>> G_TipoDocumentoSelectAll()
        {
            var lista = new List<G_TipoDocumentoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_TipoDocumentoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_TipoDocumentoModel = new G_TipoDocumentoModel();
                            g_TipoDocumentoModel.IdTipoDocumento = (string)item["idTipoDocumento"];
                            g_TipoDocumentoModel.NTipoDocumento = (string)item["nTipoDocumento"];
                            g_TipoDocumentoModel.Activo = (int)item["activo"];
                            g_TipoDocumentoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TipoDocumentoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_TipoDocumentoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_TipoDocumentoModel> G_TipoDocumentoSelectId(string idTipoDocumento)
        {
            var g_TipoDocumentoModel = new G_TipoDocumentoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TipoDocumentoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", idTipoDocumento);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_TipoDocumentoModel.IdTipoDocumento = (string)item["idTipoDocumento"];
                            g_TipoDocumentoModel.NTipoDocumento = (string)item["nTipoDocumento"];
                            g_TipoDocumentoModel.Activo = (int)item["activo"];
                            g_TipoDocumentoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TipoDocumentoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_TipoDocumentoModel;
        }
        public async Task<ResponseSP> G_TipoDocumentoInsert(G_TipoDocumentoModel g_TipoDocumentoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TipoDocumentoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", g_TipoDocumentoModel.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@nTipoDocumento", g_TipoDocumentoModel.NTipoDocumento);
                    cmd.Parameters.AddWithValue("@activo", g_TipoDocumentoModel.Activo);
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
        public async Task<ResponseSP> G_TipoDocumentoUpdate(G_TipoDocumentoModel g_TipoDocumentoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TipoDocumentoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", g_TipoDocumentoModel.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@nTipoDocumento", g_TipoDocumentoModel.NTipoDocumento);
                    cmd.Parameters.AddWithValue("@activo", g_TipoDocumentoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_TipoDocumentoModel.CVersion));
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
        public async Task<ResponseSP>G_TipoDocumentoDelete(string idTipoDocumento, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TipoDocumentoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoDocumento", idTipoDocumento);
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
