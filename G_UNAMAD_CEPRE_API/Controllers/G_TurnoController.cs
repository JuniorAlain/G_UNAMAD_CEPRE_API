using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Turno")]
    public class G_TurnoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_TurnoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_TurnoModel>>> G_TurnoGetAll()
        {
            var funcion = new G_TurnoData();

            return await funcion.G_TurnoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_TurnoModel>> G_TurnoGetId(string id)
        {
            var funcion = new G_TurnoData();

            return await funcion.G_TurnoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_TurnoPost([FromBody]G_TurnoModelDTO g_TurnoModelDTO)
        {
            var funcion = new G_TurnoData();
            G_TurnoModel g_TurnoModel = _mapper.Map<G_TurnoModel>(g_TurnoModelDTO);

            return await funcion.G_TurnoInsert(g_TurnoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TurnoPut(string id, string version, [FromBody] G_TurnoModelDTO g_TurnoModelDTO)
        {
            var funcion = new G_TurnoData();
            G_TurnoModel g_TurnoModel = _mapper.Map<G_TurnoModel>(g_TurnoModelDTO);
            g_TurnoModel.IdTurno = id;
            g_TurnoModel.CVersion = version;

            return await funcion.G_TurnoUpdate(g_TurnoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_TurnoDelete(string id, string version)
        {
            var funcion = new G_TurnoData();

            return await funcion.G_TurnoDelete(id, version);
        }
    }    
}
