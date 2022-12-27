using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_TemaData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_TemaModel>> G_TemaSelectAll()
        {
            var lista = new List<G_TemaModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_TemaSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_TemaModel = new G_TemaModel();
                            g_TemaModel.IdTema = (string)item["idTema"];
                            g_TemaModel.NTema = (string)item["nTema"];
                            g_TemaModel.Activo = (int)item["activo"];
                            g_TemaModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TemaModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_TemaModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_TemaModel> G_TemaSelectId(string idTema)
        {
            var g_TemaModel = new G_TemaModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TemaSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTema", idTema);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_TemaModel.IdTema = (string)item["idTema"];
                            g_TemaModel.NTema = (string)item["nTema"];
                            g_TemaModel.Activo = (int)item["activo"];
                            g_TemaModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_TemaModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_TemaModel;
        }
        public async Task<ResponseSP> G_TemaInsert(G_TemaModel g_TemaModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TemaInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTema", g_TemaModel.IdTema);
                    cmd.Parameters.AddWithValue("@nTema", g_TemaModel.NTema);
                    cmd.Parameters.AddWithValue("@activo", g_TemaModel.Activo);
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
        public async Task<ResponseSP> G_TemaUpdate(G_TemaModel g_TemaModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TemaUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTema", g_TemaModel.IdTema);
                    cmd.Parameters.AddWithValue("@nTema", g_TemaModel.NTema);
                    cmd.Parameters.AddWithValue("@activo", g_TemaModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_TemaModel.CVersion));
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
        public async Task<ResponseSP>G_TemaDelete(string idTema, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_TemaDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTema", idTema);
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
