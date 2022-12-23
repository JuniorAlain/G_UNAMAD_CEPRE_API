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

            return await funcion.G_CicloSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_CicloModel>> G_CicloGetId(string id)
        {
            var funcion = new G_CicloData();

            return await funcion.G_CicloSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_CicloPost([FromBody] G_CicloModelDTO g_CicloModelDTO)
        {
            var funcion = new G_CicloData();
            G_CicloModel g_CicloModel = _mapper.Map<G_CicloModel>(g_CicloModelDTO);
            
            return await funcion.G_CicloInsert(g_CicloModel);
        }
        [HttpPut("{id}/{cVersion}")]
        public async Task<ActionResult<ResponseSP>> G_CicloPut(string id, string cVersion, [FromBody] G_CicloModelDTO g_CicloModelDTO)
        {
            var funcion = new G_CicloData();
            G_CicloModel g_CicloModel = _mapper.Map<G_CicloModel>(g_CicloModelDTO);
            g_CicloModel.IdCiclo = id;
            g_CicloModel.CVersion = cVersion;            

            return await funcion.G_CicloUpdate(g_CicloModel);
        }
        [HttpDelete("{id}/{cVersion}")]
        public async Task<ActionResult<ResponseSP>> G_CicloDelete(string id, string cVersion)
        {
            var funcion = new G_CicloData();                                    

            return await funcion.G_CicloDelete(id, cVersion);
        }
    }
}
