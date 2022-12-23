using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_CursoData : ConvertVersion
    {
        ConnectionBd cn = new ConnectionBd();        
        public async Task<List<G_CursoModel>> G_CursoSelectAll()
        {
            var lista = new List<G_CursoModel>();
            using (var sql = new SqlConnection(cn.cadendaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CursoSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var g_CursoModel = new G_CursoModel();
                            g_CursoModel.IdCurso = (string)item["idCurso"];
                            g_CursoModel.NCurso = (string)item["nCurso"];
                            g_CursoModel.Activo = (int)item["activo"];
                            g_CursoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CursoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_CursoModel);
                        }                          
                    }
                }                
            }
            return lista;
        }
        public async Task<G_CursoModel> G_CursoSelectId(string idCurso)
        {
            var g_CursoModel = new G_CursoModel();
            using (var sql = new SqlConnection(cn.cadendaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CursoSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCurso", idCurso);
                    await sql.OpenAsync();

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {                   
                            g_CursoModel.IdCurso = (string)item["idCurso"];
                            g_CursoModel.NCurso = (string)item["nCurso"];
                            g_CursoModel.Activo = (int)item["activo"];
                            g_CursoModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_CursoModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }
                    }
                }                
            }
            return g_CursoModel;
        }
        public async Task<ResponseSP> G_CursoInsert(G_CursoModel g_CursoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadendaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CursoInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCurso", g_CursoModel.IdCurso);
                    cmd.Parameters.AddWithValue("@nCurso", g_CursoModel.NCurso);
                    cmd.Parameters.AddWithValue("@activo", g_CursoModel.Activo);
                    await sql.OpenAsync();

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if(await item.ReadAsync())
                        {
                            responseSP.TotalAffectedRecord = (int)item["totalAffectedRecord"];
                            responseSP.MessageException = (string)item["messageException"];
                        }
                    }
                }
            }
            return responseSP;
        }
        public async Task<ResponseSP> G_CursoUpdate(G_CursoModel g_CursoModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadendaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CursoUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCurso", g_CursoModel.IdCurso);
                    cmd.Parameters.AddWithValue("@nCurso", g_CursoModel.NCurso);
                    cmd.Parameters.AddWithValue("@activo", g_CursoModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion(g_CursoModel.CVersion));
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
        public async Task<ResponseSP> G_CursoDelete(string idCurso, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadendaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_CursoDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCurso", idCurso);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion(cVersion));
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
