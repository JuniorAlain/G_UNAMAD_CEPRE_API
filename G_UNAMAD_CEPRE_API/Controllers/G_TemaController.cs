using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Tema")]
    public class G_TemaController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_TemaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_TemaModel>>> G_TemaGetAll()
        {
            var funcion = new G_TemaData();

            return await funcion.G_TemaSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_TemaModel>> G_TemaGetId(string id)
        {
            var funcion = new G_TemaData();

            return await funcion.G_TemaSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_TemaPost([FromBody]G_TemaModelDTO g_TemaModelDTO)
        {
            var funcion = new G_TemaData();
            G_TemaModel g_TemaModel = _mapper.Map<G_TemaModel>(g_TemaModelDTO);

            return await funcion.G_TemaInsert(g_TemaModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TemaPut(string id, string version, [FromBody] G_TemaModelDTO g_TemaModelDTO)
        {
            var funcion = new G_TemaData();
            G_TemaModel g_TemaModel = _mapper.Map<G_TemaModel>(g_TemaModelDTO);
            g_TemaModel.IdTema = id;
            g_TemaModel.CVersion = version;

            return await funcion.G_TemaUpdate(g_TemaModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TemaDelete(string id, string version)
        {
            var funcion = new G_TemaData();

            return await funcion.G_TemaDelete(id, version);
        }
    }    
}
