using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Ubigeo")]
    public class G_UbigeoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_UbigeoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_UbigeoModel>>> G_UbigeoGetAll()
        {
            var funcion = new G_UbigeoData();

            return await funcion.G_UbigeoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_UbigeoModel>> G_UbigeoGetId(string id)
        {
            var funcion = new G_UbigeoData();

            return await funcion.G_UbigeoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_UbigeoPost([FromBody]G_UbigeoModelDTO g_UbigeoModelDTO)
        {
            var funcion = new G_UbigeoData();
            G_UbigeoModel g_UbigeoModel = _mapper.Map<G_UbigeoModel>(g_UbigeoModelDTO);

            return await funcion.G_UbigeoInsert(g_UbigeoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_UbigeoPut(string id, string version, [FromBody] G_UbigeoModelDTO g_UbigeoModelDTO)
        {
            var funcion = new G_UbigeoData();
            G_UbigeoModel g_UbigeoModel = _mapper.Map<G_UbigeoModel>(g_UbigeoModelDTO);
            g_UbigeoModel.IdUbigeo = id;
            g_UbigeoModel.CVersion = version;

            return await funcion.G_UbigeoUpdate(g_UbigeoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_UbigeoDelete(string id, string version)
        {
            var funcion = new G_UbigeoData();

            return await funcion.G_UbigeoDelete(id, version);
        }
    }    
}
