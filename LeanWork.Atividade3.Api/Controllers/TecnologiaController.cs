using LeanWork.Atividade3.Application.Services;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeanWork.Atividade3.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TecnologiaController : ControllerBase
{
    private readonly ITecnologiaService tecnologiaService;

    public TecnologiaController(ITecnologiaService tecnologiaService)
    {
        this.tecnologiaService = tecnologiaService;
    }

    [HttpPost("Cadastrar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> CadastrarAsync([FromBody] TecnologiaInputModel cadastroTecnologia)
    {
        var resultado = await tecnologiaService.Cadastrar(cadastroTecnologia).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpPost("Atualizar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> AtualizarAsync([FromBody] TecnologiaInputModel atualizaTecnologia)
    {
        var resultado = await tecnologiaService.Atualizar(atualizaTecnologia).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet("ConsultarTecnologia/{idTecnologia}")]
    [ProducesResponseType(typeof(TecnologiaInputModel), 200)]
    public async Task<ActionResult> ConsultarTecnologia([FromRoute] int idTecnologia)
    {
        var resultado = await tecnologiaService.ObterPorID(idTecnologia).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<TecnologiaInputModel>), 200)]
    public async Task<ActionResult> Obter()
    {
        var resultado = await tecnologiaService.Obter();

        return Ok(resultado);
    }

    [HttpPost("DeleteAsync/{idTecnologia}")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int idTecnologia)
    {
        var resultado = await tecnologiaService.Deletar(idTecnologia).ConfigureAwait(true);

        return Ok(resultado);
    }
}
