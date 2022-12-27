using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_CarreraData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_CarreraModel>> G_CarreraSelectAll()
        {
            var lista = new List<G_CarreraModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_CarreraSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_CarreraModel = new G_CarreraModel();
                            g_CarreraModel.IdCarrera = (string)item["idCarrera"];
                            g_CarreraModel.NCarrera = (string)item["nCarrera"];
                            g_CarreraModel.Activo = (int)item["activo"];
                            g_CarreraModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CarreraModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_CarreraModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_CarreraModel> G_CarreraSelectId(string idCarrera)
        {
            var g_CarreraModel = new G_CarreraModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CarreraSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCarrera", idCarrera);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_CarreraModel.IdCarrera = (string)item["idCarrera"];
                            g_CarreraModel.NCarrera = (string)item["nCarrera"];
                            g_CarreraModel.Activo = (int)item["activo"];
                            g_CarreraModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CarreraModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_CarreraModel;
        }
        public async Task<ResponseSP> G_CarreraInsert(G_CarreraModel g_CarreraModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CarreraInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCarrera", g_CarreraModel.IdCarrera);
                    cmd.Parameters.AddWithValue("@nCarrera", g_CarreraModel.NCarrera);
                    cmd.Parameters.AddWithValue("@activo", g_CarreraModel.Activo);
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
        public async Task<ResponseSP> G_CarreraUpdate(G_CarreraModel g_CarreraModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CarreraUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCarrera", g_CarreraModel.IdCarrera);
                    cmd.Parameters.AddWithValue("@nCarrera", g_CarreraModel.NCarrera);
                    cmd.Parameters.AddWithValue("@activo", g_CarreraModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_CarreraModel.CVersion));
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
        public async Task<ResponseSP>G_CarreraDelete(string idCarrera, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CarreraDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCarrera", idCarrera);
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
