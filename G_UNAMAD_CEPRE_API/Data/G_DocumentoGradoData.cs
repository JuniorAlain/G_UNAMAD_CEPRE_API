using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_DocumentoGradoData : ConvertVersion
    {
        ConnectionBd cn = new ConnectionBd();
        public async Task<List<G_DocumentoGradoModel>> G_DocumentoGradoSelectAll()
        {
            var lista = new List<G_DocumentoGradoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_DocumentoGradoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_DocumentoGradoModel = new G_DocumentoGradoModel();
                            g_DocumentoGradoModel.IdDocumentoGrado = (string)item["idDocumentoGrado"];
                            g_DocumentoGradoModel.NDocumentoGrado = (string)item["nDocumentoGrado"];
                            g_DocumentoGradoModel.Activo = (int)item["activo"];
                            g_DocumentoGradoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_DocumentoGradoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_DocumentoGradoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_DocumentoGradoModel> G_DocumentoGradoSelectId(string idDocumentoGrado)
        {
            var g_DocumentoGradoModel = new G_DocumentoGradoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_DocumentoGradoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDocumentoGrado", idDocumentoGrado);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_DocumentoGradoModel.IdDocumentoGrado = (string)item["idDocumentoGrado"];
                            g_DocumentoGradoModel.NDocumentoGrado = (string)item["nDocumentoGrado"];
                            g_DocumentoGradoModel.Activo = (int)item["activo"];
                            g_DocumentoGradoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_DocumentoGradoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_DocumentoGradoModel;
        }
        public async Task<ResponseSP> G_DocumentoGradoInsert(G_DocumentoGradoModel g_DocumentoGradoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_DocumentoGradoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDocumentoGrado", g_DocumentoGradoModel.IdDocumentoGrado);
                    cmd.Parameters.AddWithValue("@nDocumentoGrado", g_DocumentoGradoModel.NDocumentoGrado);
                    cmd.Parameters.AddWithValue("@activo", g_DocumentoGradoModel.Activo);
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
        public async Task<ResponseSP> G_DocumentoGradoUpdate(G_DocumentoGradoModel g_DocumentoGradoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_DocumentoGradoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDocumentoGrado", g_DocumentoGradoModel.IdDocumentoGrado);
                    cmd.Parameters.AddWithValue("@nDocumentoGrado", g_DocumentoGradoModel.NDocumentoGrado);
                    cmd.Parameters.AddWithValue("@activo", g_DocumentoGradoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_DocumentoGradoModel.CVersion));
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
        public async Task<ResponseSP>G_DocumentoGradoDelete(string idDocumentoGrado, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_DocumentoGradoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDocumentoGrado", idDocumentoGrado);
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
