using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/Curso")]
    public class G_CursoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_CursoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_CursoModel>>> G_CursoGetAll()
        {
            var funcion = new G_CursoData();
            //var lista = await funcion.G_CursoSelectAll();

            return await funcion.G_CursoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_CursoModel>> G_CursoGetId(string id)
        {
            var funcion = new G_CursoData();
           //var g_CursoModel = await funcion.G_CursoSelectId(id);
            
            return await funcion.G_CursoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_CursoPost([FromBody] G_CursoModelDTO g_CursoModelDTO)
        {
            var funcion = new G_CursoData();
            G_CursoModel g_CursoModel = _mapper.Map<G_CursoModel>(g_CursoModelDTO);
            //var responseSP = await funcion.G_CursoInsert(g_CursoModel);

            return await funcion.G_CursoInsert(g_CursoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>> G_CursoPut(string id, string version, [FromBody] G_CursoModelDTO g_CursoModelDTO)
        {
            var funcion = new G_CursoData();
            G_CursoModel g_CursoModel = _mapper.Map<G_CursoModel>(g_CursoModelDTO);
            g_CursoModel.IdCurso = id;
            g_CursoModel.CVersion = version;
            //var responseSP = await funcion.G_CursoUpdate(g_CursoModel);

            return await funcion.G_CursoUpdate(g_CursoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>> G_CursoDelete(string id, string version)
        {
            var funcion = new G_CursoData();
            //var responseSP = await funcion.G_CursoDelete(id, cVersion);
            
            return await funcion.G_CursoDelete(id, version);
        }
    }
}
