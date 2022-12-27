
using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Modalidad")]
    public class G_ModalidadController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_ModalidadController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_ModalidadModel>>> G_ModalidadGetAll()
        {
            var funcion = new G_ModalidadData();

            return await funcion.G_ModalidadSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_ModalidadModel>> G_ModalidadGetId(string id)
        {
            var funcion = new G_ModalidadData();

            return await funcion.G_ModalidadSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_ModalidadPost([FromBody]G_ModalidadModelDTO g_ModalidadModelDTO)
        {
            var funcion = new G_ModalidadData();
            G_ModalidadModel g_ModalidadModel = _mapper.Map<G_ModalidadModel>(g_ModalidadModelDTO);

            return await funcion.G_ModalidadInsert(g_ModalidadModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_ModalidadPut(string id, string version, [FromBody] G_ModalidadModelDTO g_ModalidadModelDTO)
        {
            var funcion = new G_ModalidadData();
            G_ModalidadModel g_ModalidadModel = _mapper.Map<G_ModalidadModel>(g_ModalidadModelDTO);
            g_ModalidadModel.IdModalidad = id;
            g_ModalidadModel.CVersion = version;

            return await funcion.G_ModalidadUpdate(g_ModalidadModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_ModalidadDelete(string id, string version)
        {
            var funcion = new G_ModalidadData();

            return await funcion.G_ModalidadDelete(id, version);
        }
    }    
}
