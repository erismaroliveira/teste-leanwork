using LeanWork.Atividade3.Application.Services;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeanWork.Atividade3.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VagaController : ControllerBase
{
    private readonly IVagaService vagaService;

    public VagaController(IVagaService vagaService)
    {
        this.vagaService = vagaService;
    }

    [HttpPost("Cadastrar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> CadastrarAsync([FromBody] VagaInputModel cadastroVaga)
    {
        var resultado = await vagaService.Cadastrar(cadastroVaga).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpPost("Atualizar")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> AtualizarAsync([FromBody] VagaInputModel atualizaVaga)
    {
        var resultado = await vagaService.Atualizar(atualizaVaga).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet("ConsultarVaga/{idVaga}")]
    [ProducesResponseType(typeof(VagaInputModel), 200)]
    public async Task<ActionResult> ConsultarVaga([FromRoute] int idVaga)
    {
        var resultado = await vagaService.ObterPorID(idVaga).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<VagaInputModel>), 200)]
    public async Task<ActionResult> Obter()
    {
        var resultado = await vagaService.Obter();

        return Ok(resultado);
    }

    [HttpPost("DeleteAsync/{idVaga}")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int idVaga)
    {
        var resultado = await vagaService.Deletar(idVaga).ConfigureAwait(true);

        return Ok(resultado);
    }
}
