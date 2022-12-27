using AutoMapper;
using G_UNAMAD_CEPRE_API.Data;
using G_UNAMAD_CEPRE_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_UNAMAD_CEPRE_API.Controllers
{
    [ApiController]
    [Route("api/GradoAcademico")]
    public class G_GradoAcademicoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public G_GradoAcademicoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<G_GradoAcademicoModel>>> G_GradoAcademicoGetAll()
        {
            var funcion = new G_GradoAcademicoData();

            return await funcion.G_GradoAcademicoSelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<G_GradoAcademicoModel>> G_GradoAcademicoGetId(string id)
        {
            var funcion = new G_GradoAcademicoData();

            return await funcion.G_GradoAcademicoSelectId(id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseSP>> G_GradoAcademicoPost([FromBody]G_GradoAcademicoModelDTO g_GradoAcademicoModelDTO)
        {
            var funcion = new G_GradoAcademicoData();
            G_GradoAcademicoModel g_GradoAcademicoModel = _mapper.Map<G_GradoAcademicoModel>(g_GradoAcademicoModelDTO);

            return await funcion.G_GradoAcademicoInsert(g_GradoAcademicoModel);
        }
        [HttpPut("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_GradoAcademicoPut(string id, string version, [FromBody] G_GradoAcademicoModelDTO g_GradoAcademicoModelDTO)
        {
            var funcion = new G_GradoAcademicoData();
            G_GradoAcademicoModel g_GradoAcademicoModel = _mapper.Map<G_GradoAcademicoModel>(g_GradoAcademicoModelDTO);
            g_GradoAcademicoModel.IdGradoAcademico = id;
            g_GradoAcademicoModel.CVersion = version;

            return await funcion.G_GradoAcademicoUpdate(g_GradoAcademicoModel);
        }
        [HttpDelete("{id}/{version}")]
        public async Task<ActionResult<ResponseSP>>G_GradoAcademicoDelete(string id, string version)
        {
            var funcion = new G_GradoAcademicoData();

            return await funcion.G_GradoAcademicoDelete(id, version);
        }
    }    
}
