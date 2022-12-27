using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/TipoDocumento")]
    public class G_TipoDocumentoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_TipoDocumentoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_TipoDocumentoModel>>> G_TipoDocumentoGetAll()
        {
            var funcion = new G_TipoDocumentoData();

            return await funcion.G_TipoDocumentoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_TipoDocumentoModel>> G_TipoDocumentoGetId(string id)
        {
            var funcion = new G_TipoDocumentoData();

            return await funcion.G_TipoDocumentoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_TipoDocumentoPost([FromBody]G_TipoDocumentoModelDTO g_TipoDocumentoModelDTO)
        {
            var funcion = new G_TipoDocumentoData();
            G_TipoDocumentoModel g_TipoDocumentoModel = _mapper.Map<G_TipoDocumentoModel>(g_TipoDocumentoModelDTO);

            return await funcion.G_TipoDocumentoInsert(g_TipoDocumentoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TipoDocumentoPut(string id, string version, [FromBody] G_TipoDocumentoModelDTO g_TipoDocumentoModelDTO)
        {
            var funcion = new G_TipoDocumentoData();
            G_TipoDocumentoModel g_TipoDocumentoModel = _mapper.Map<G_TipoDocumentoModel>(g_TipoDocumentoModelDTO);
            g_TipoDocumentoModel.IdTipoDocumento = id;
            g_TipoDocumentoModel.CVersion = version;

            return await funcion.G_TipoDocumentoUpdate(g_TipoDocumentoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TipoDocumentoDelete(string id, string version)
        {
            var funcion = new G_TipoDocumentoData();

            return await funcion.G_TipoDocumentoDelete(id, version);
        }
    }    
}
