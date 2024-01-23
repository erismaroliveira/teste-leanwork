using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeanWork.Atividade3.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatoController : ControllerBase
{
    private readonly ICandidatoService candidatoService;

    public CandidatoController(ICandidatoService candidatoService)
    {
        this.candidatoService = candidatoService;
    }

    [HttpPost("Cadastrar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> CadastrarAsync([FromBody] CandidatoInputModel cadastroCandidato)
    {
        var resultado = await candidatoService.Cadastrar(cadastroCandidato).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpPost("Atualizar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> AtualizarAsync([FromBody] CandidatoInputModel atualizaCandidato)
    {
        var resultado = await candidatoService.Atualizar(atualizaCandidato).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet("ConsultarCandidato/{idCandidato}")]
    [ProducesResponseType(typeof(CandidatoInputModel), 200)]
    public async Task<ActionResult> ConsultarCandidato([FromRoute] int idCandidato)
    {
        var resultado = await candidatoService.ObterPorID(idCandidato).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CandidatoInputModel>), 200)]
    public async Task<ActionResult> Obter()
    {
        var resultado = await candidatoService.Obter();

        return Ok(resultado);
    }

    [HttpPost("DeleteAsync/{idCandidato}")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int idCandidato)
    {
        var resultado = await candidatoService.Deletar(idCandidato).ConfigureAwait(true);

        return Ok(resultado);
    }
}
