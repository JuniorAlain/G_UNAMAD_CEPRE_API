using G_UNAMAD_CEPRE_API.Connection;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G_UNAMAD_CEPRE_API.Data
{
    public class G_ModalidadData : ConvertVersion
    {
        ConnectionDb cn = new ConnectionDb();
        public async Task<List<G_ModalidadModel>> G_ModalidadSelectAll()
        {
            var lista = new List<G_ModalidadModel>();
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("SP_G_ModalidadSelectAll", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var g_ModalidadModel = new G_ModalidadModel();
                            g_ModalidadModel.IdModalidad = (string)item["idModalidad"];
                            g_ModalidadModel.NModalidad = (string)item["nModalidad"];
                            g_ModalidadModel.Activo = (int)item["activo"];
                            g_ModalidadModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_ModalidadModel.CVersion = StringVersion((byte[])item["cVersion"]);
                            lista.Add(g_ModalidadModel);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<G_ModalidadModel> G_ModalidadSelectId(string idModalidad)
        {
            var g_ModalidadModel = new G_ModalidadModel();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_ModalidadSelectId", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idModalidad", idModalidad);
                    await sql.OpenAsync();

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            g_ModalidadModel.IdModalidad = (string)item["idModalidad"];
                            g_ModalidadModel.NModalidad = (string)item["nModalidad"];
                            g_ModalidadModel.Activo = (int)item["activo"];
                            g_ModalidadModel.FRegistroM = (DateTime)item["fRegistroM"];
                            g_ModalidadModel.CVersion = StringVersion((byte[])item["cVersion"]);
                        }                        
                    }
                }
            }
            return g_ModalidadModel;
        }
        public async Task<ResponseSP> G_ModalidadInsert(G_ModalidadModel g_ModalidadModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_ModalidadInsert", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idModalidad", g_ModalidadModel.IdModalidad);
                    cmd.Parameters.AddWithValue("@nModalidad", g_ModalidadModel.NModalidad);
                    cmd.Parameters.AddWithValue("@activo", g_ModalidadModel.Activo);
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
        public async Task<ResponseSP> G_ModalidadUpdate(G_ModalidadModel g_ModalidadModel)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_ModalidadUpdate", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idModalidad", g_ModalidadModel.IdModalidad);
                    cmd.Parameters.AddWithValue("@nModalidad", g_ModalidadModel.NModalidad);
                    cmd.Parameters.AddWithValue("@activo", g_ModalidadModel.Activo);
                    cmd.Parameters.AddWithValue("@cVersion", ByteVersion((string)g_ModalidadModel.CVersion));
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
        public async Task<ResponseSP>G_ModalidadDelete(string idModalidad, string cVersion)
        {
            var responseSP = new ResponseSP();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_G_ModalidadDelete", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idModalidad", idModalidad);
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
