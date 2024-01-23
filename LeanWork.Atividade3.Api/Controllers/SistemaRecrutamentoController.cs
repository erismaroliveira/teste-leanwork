using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeanWork.Atividade3.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemaRecrutamentoController : ControllerBase
{
    private readonly ISistemaRecrutamentoService sistemaRecrutamentoService;

    public SistemaRecrutamentoController(ISistemaRecrutamentoService sistemaRecrutamento)
    {
        this.sistemaRecrutamentoService = sistemaRecrutamento;
    }

    [HttpPost("CadastrarPesoTecnologia")]
    [ProducesResponseType(typeof(ResponseModel), 200)]
    public async Task<IActionResult> CadastrarPesoTecnologia([FromBody] PesoTecnologiaVagaInputModel cadastroPesoTecnologia)
    {
        var resultado = await sistemaRecrutamentoService.CadastrarPesoTecnologiaVaga(cadastroPesoTecnologia).ConfigureAwait(true);

        return Ok(resultado);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CandidatoInputModel>), 200)]
    public async Task<ActionResult> GerarRelatorio()
    {
        var resultado = await sistemaRecrutamentoService.GerarRelatorioPontuacao();

        return Ok(resultado);
    }
}
