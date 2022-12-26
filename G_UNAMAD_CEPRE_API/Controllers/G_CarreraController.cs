using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Carrera")]
    public class G_CarreraController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_CarreraController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_CarreraModel>>> G_CarreraGetAll()
        {
            var funcion = new G_CarreraData();

            return await funcion.G_CarreraSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_CarreraModel>> G_CarreraGetId(string id)
        {
            var funcion = new G_CarreraData();

            return await funcion.G_CarreraSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_CarreraPost([FromBody]G_CarreraModelDTO g_CarreraModelDTO)
        {
            var funcion = new G_CarreraData();
            G_CarreraModel g_CarreraModel = _mapper.Map<G_CarreraModel>(g_CarreraModelDTO);

            return await funcion.G_CarreraInsert(g_CarreraModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_CarreraPut(string id, string version, [FromBody] G_CarreraModelDTO g_CarreraModelDTO)
        {
            var funcion = new G_CarreraData();
            G_CarreraModel g_CarreraModel = _mapper.Map<G_CarreraModel>(g_CarreraModelDTO);
            g_CarreraModel.IdCarrera = id;
            g_CarreraModel.CVersion = version;

            return await funcion.G_CarreraUpdate(g_CarreraModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_CarreraDelete(string id, string version)
        {
            var funcion = new G_CarreraData();

            return await funcion.G_CarreraDelete(id, version);
        }
    }    
}
