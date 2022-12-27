using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/DocumentoGrado")]
    public class G_DocumentoGradoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_DocumentoGradoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_DocumentoGradoModel>>> G_DocumentoGradoGetAll()
        {
            var funcion = new G_DocumentoGradoData();

            return await funcion.G_DocumentoGradoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_DocumentoGradoModel>> G_DocumentoGradoGetId(string id)
        {
            var funcion = new G_DocumentoGradoData();

            return await funcion.G_DocumentoGradoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_DocumentoGradoPost([FromBody]G_DocumentoGradoModelDTO g_DocumentoGradoModelDTO)
        {
            var funcion = new G_DocumentoGradoData();
            G_DocumentoGradoModel g_DocumentoGradoModel = _mapper.Map<G_DocumentoGradoModel>(g_DocumentoGradoModelDTO);

            return await funcion.G_DocumentoGradoInsert(g_DocumentoGradoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_DocumentoGradoPut(string id, string version, [FromBody] G_DocumentoGradoModelDTO g_DocumentoGradoModelDTO)
        {
            var funcion = new G_DocumentoGradoData();
            G_DocumentoGradoModel g_DocumentoGradoModel = _mapper.Map<G_DocumentoGradoModel>(g_DocumentoGradoModelDTO);
            g_DocumentoGradoModel.IdDocumentoGrado = id;
            g_DocumentoGradoModel.CVersion = version;

            return await funcion.G_DocumentoGradoUpdate(g_DocumentoGradoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_DocumentoGradoDelete(string id, string version)
        {
            var funcion = new G_DocumentoGradoData();

            return await funcion.G_DocumentoGradoDelete(id, version);
        }
    }    
}
