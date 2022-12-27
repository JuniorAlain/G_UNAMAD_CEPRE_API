using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Aula")]
    public class G_AulaController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_AulaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_AulaModel>>> G_AulaGetAll()
        {
            var funcion = new G_AulaData();

            return await funcion.G_AulaSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_AulaModel>> G_AulaGetId(string id)
        {
            var funcion = new G_AulaData();

            return await funcion.G_AulaSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_AulaPost([FromBody]G_AulaModelDTO g_AulaModelDTO)
        {
            var funcion = new G_AulaData();
            G_AulaModel g_AulaModel = _mapper.Map<G_AulaModel>(g_AulaModelDTO);

            return await funcion.G_AulaInsert(g_AulaModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_AulaPut(string id, string version, [FromBody] G_AulaModelDTO g_AulaModelDTO)
        {
            var funcion = new G_AulaData();
            G_AulaModel g_AulaModel = _mapper.Map<G_AulaModel>(g_AulaModelDTO);
            g_AulaModel.IdAula = id;
            g_AulaModel.CVersion = version;

            return await funcion.G_AulaUpdate(g_AulaModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_AulaDelete(string id, string version)
        {
            var funcion = new G_AulaData();

            return await funcion.G_AulaDelete(id, version);
        }
    }    
}
