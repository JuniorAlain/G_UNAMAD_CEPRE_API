using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Grupo")]
    public class G_GrupoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_GrupoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_GrupoModel>>> G_GrupoGetAll()
        {
            var funcion = new G_GrupoData();

            return await funcion.G_GrupoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_GrupoModel>> G_GrupoGetId(string id)
        {
            var funcion = new G_GrupoData();

            return await funcion.G_GrupoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_GrupoPost([FromBody]G_GrupoModelDTO g_GrupoModelDTO)
        {
            var funcion = new G_GrupoData();
            G_GrupoModel g_GrupoModel = _mapper.Map<G_GrupoModel>(g_GrupoModelDTO);

            return await funcion.G_GrupoInsert(g_GrupoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_GrupoPut(string id, string version, [FromBody] G_GrupoModelDTO g_GrupoModelDTO)
        {
            var funcion = new G_GrupoData();
            G_GrupoModel g_GrupoModel = _mapper.Map<G_GrupoModel>(g_GrupoModelDTO);
            g_GrupoModel.IdGrupo = id;
            g_GrupoModel.CVersion = version;

            return await funcion.G_GrupoUpdate(g_GrupoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_GrupoDelete(string id, string version)
        {
            var funcion = new G_GrupoData();

            return await funcion.G_GrupoDelete(id, version);
        }
    }    
}
