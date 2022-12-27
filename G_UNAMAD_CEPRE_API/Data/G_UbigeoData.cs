using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_UbigeoData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_UbigeoModel>> G_UbigeoSelectAll()
        {
            var lista = new List<G_UbigeoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_UbigeoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_UbigeoModel = new G_UbigeoModel();
                            g_UbigeoModel.IdUbigeo = (string)item["idUbigeo"];
                            g_UbigeoModel.CDepartamento = (string)item["cDepartamento"];
                            g_UbigeoModel.NDepartamento = (string)item["nDepartamento"];
                            g_UbigeoModel.CProvincia = (string)item["cProvincia"];
                            g_UbigeoModel.NProvincia = (string)item["nProvincia"];
                            g_UbigeoModel.CDistrito = (string)item["cDistrito"];
                            g_UbigeoModel.NDistrito = (string)item["nDistrito"];
                            g_UbigeoModel.Activo = (int)item["activo"];
                            g_UbigeoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_UbigeoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_UbigeoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_UbigeoModel> G_UbigeoSelectId(string idUbigeo)
        {
            var g_UbigeoModel = new G_UbigeoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_UbigeoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUbigeo", idUbigeo);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {                            
                            g_UbigeoModel.IdUbigeo = (string)item["idUbigeo"];
                            g_UbigeoModel.CDepartamento = (string)item["cDepartamento"];
                            g_UbigeoModel.NDepartamento = (string)item["nDepartamento"];
                            g_UbigeoModel.CProvincia = (string)item["cProvincia"];
                            g_UbigeoModel.NProvincia = (string)item["nProvincia"];
                            g_UbigeoModel.CDistrito = (string)item["cDistrito"];
                            g_UbigeoModel.NDistrito = (string)item["nDistrito"];
                            g_UbigeoModel.Activo = (int)item["activo"];
                            g_UbigeoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_UbigeoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_UbigeoModel;
        }
        public async Task<ResponseSP> G_UbigeoInsert(G_UbigeoModel g_UbigeoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_UbigeoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUbigeo", g_UbigeoModel.IdUbigeo);
                    cmd.Parameters.AddWithValue("@cDepartamento", g_UbigeoModel.CDepartamento);
                    cmd.Parameters.AddWithValue("@nDepartamento", g_UbigeoModel.NDepartamento);
                    cmd.Parameters.AddWithValue("@cProvincia", g_UbigeoModel.CProvincia);
                    cmd.Parameters.AddWithValue("@nProvincia", g_UbigeoModel.NProvincia);
                    cmd.Parameters.AddWithValue("@cDistrito", g_UbigeoModel.CDistrito);
                    cmd.Parameters.AddWithValue("@nDistrito", g_UbigeoModel.NDistrito);
                    cmd.Parameters.AddWithValue("@activo", g_UbigeoModel.Activo);
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
        public async Task<ResponseSP> G_UbigeoUpdate(G_UbigeoModel g_UbigeoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_UbigeoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUbigeo", g_UbigeoModel.IdUbigeo);
                    cmd.Parameters.AddWithValue("@cDepartamento", g_UbigeoModel.CDepartamento);
                    cmd.Parameters.AddWithValue("@nDepartamento", g_UbigeoModel.NDepartamento);
                    cmd.Parameters.AddWithValue("@cProvincia", g_UbigeoModel.CProvincia);
                    cmd.Parameters.AddWithValue("@nProvincia", g_UbigeoModel.NProvincia);
                    cmd.Parameters.AddWithValue("@cDistrito", g_UbigeoModel.CDistrito);
                    cmd.Parameters.AddWithValue("@nDistrito", g_UbigeoModel.NDistrito);
                    cmd.Parameters.AddWithValue("@activo", g_UbigeoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_UbigeoModel.CVersion));
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
        public async Task<ResponseSP>G_UbigeoDelete(string idUbigeo, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_UbigeoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUbigeo", idUbigeo);
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
