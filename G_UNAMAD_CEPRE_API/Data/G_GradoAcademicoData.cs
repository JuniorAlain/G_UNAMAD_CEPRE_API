using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Helpers;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_GradoAcademicoData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_GradoAcademicoModel>> G_GradoAcademicoSelectAll()
        {
            var lista = new List<G_GradoAcademicoModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_GradoAcademicoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_GradoAcademicoModel = new G_GradoAcademicoModel();
                            g_GradoAcademicoModel.IdGradoAcademico = (string)item["idGradoAcademico"];
                            g_GradoAcademicoModel.NGradoAcademico = (string)item["nGradoAcademico"];
                            g_GradoAcademicoModel.Activo = (int)item["activo"];
                            g_GradoAcademicoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_GradoAcademicoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_GradoAcademicoModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_GradoAcademicoModel> G_GradoAcademicoSelectId(string idGradoAcademico)
        {
            var g_GradoAcademicoModel = new G_GradoAcademicoModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GradoAcademicoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGradoAcademico", idGradoAcademico);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_GradoAcademicoModel.IdGradoAcademico = (string)item["idGradoAcademico"];
                            g_GradoAcademicoModel.NGradoAcademico = (string)item["nGradoAcademico"];
                            g_GradoAcademicoModel.Activo = (int)item["activo"];
                            g_GradoAcademicoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_GradoAcademicoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_GradoAcademicoModel;
        }
        public async Task<ResponseSP> G_GradoAcademicoInsert(G_GradoAcademicoModel g_GradoAcademicoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GradoAcademicoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGradoAcademico", g_GradoAcademicoModel.IdGradoAcademico);
                    cmd.Parameters.AddWithValue("@nGradoAcademico", g_GradoAcademicoModel.NGradoAcademico);
                    cmd.Parameters.AddWithValue("@activo", g_GradoAcademicoModel.Activo);
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
        public async Task<ResponseSP> G_GradoAcademicoUpdate(G_GradoAcademicoModel g_GradoAcademicoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GradoAcademicoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGradoAcademico", g_GradoAcademicoModel.IdGradoAcademico);
                    cmd.Parameters.AddWithValue("@nGradoAcademico", g_GradoAcademicoModel.NGradoAcademico);
                    cmd.Parameters.AddWithValue("@activo", g_GradoAcademicoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_GradoAcademicoModel.CVersion));
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
        public async Task<ResponseSP>G_GradoAcademicoDelete(string idGradoAcademico, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_GradoAcademicoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idGradoAcademico", idGradoAcademico);
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
