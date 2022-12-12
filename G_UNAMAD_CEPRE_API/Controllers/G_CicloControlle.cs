using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Ciclo")]
    public class G_CicloControlle : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_CicloControlle(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_CicloModel>>> G_CicloGetAll()
        {
            var funcion = new G_CicloData();
            var lista = await funcion.G_CicloSelectAll();

            return lista;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_CicloPost([FromBody] G_CicloModelDTOPost g_CicloModelDTOPost)
        {
            var funcion = new G_CicloData();
            G_CicloModel g_CicloModel = _mapper.Map<G_CicloModel>(g_CicloModelDTOPost);
            var respuestaSP = await funcion.G_CicloInsert(g_CicloModel);

            return respuestaSP;
        }
        [HttpPut("{idCiclo}/{cVersion}")]
        public async Task<ActionResult<ResponseSP>> G_CicloPut(string idCiclo, string cVersion, [FromBody] G_CicloModelDTOPut g_CicloModelDTOPut)
        {
            var funcion = new G_CicloData();
            G_CicloModel g_CicloModel = _mapper.Map<G_CicloModel>(g_CicloModelDTOPut);
            g_CicloModel.IdCiclo = idCiclo;
            g_CicloModel.CVersion = cVersion;
            var respuestaSP = await funcion.G_CicloUpdate(g_CicloModel);

            return respuestaSP;
        }
        [HttpDelete("{idCiclo}/{cVersion}")]
        public async Task<ActionResult<ResponseSP>> G_CicloDelete(string idCiclo, string cVersion)
        {
            var funcion = new G_CicloData();
            G_CicloModel g_CicloModel = new G_CicloModel();
            g_CicloModel.IdCiclo = idCiclo;
            g_CicloModel.CVersion = cVersion;
            var respuestaSP = await funcion.G_CicloDelete(g_CicloModel);

            return respuestaSP;
        }
    }
}
