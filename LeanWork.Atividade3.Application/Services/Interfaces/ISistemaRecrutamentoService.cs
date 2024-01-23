using LeanWork.Atividade3.Shared.InputModels;
using LeanWork.Atividade3.Shared.Models;

namespace LeanWork.Atividade3.Application.Services.Interfaces;

public interface ISistemaRecrutamentoService
{
    Task<ResponseModel> CadastrarPesoTecnologiaVaga(PesoTecnologiaVagaInputModel cadastroPesoTecnologia);
    Task<List<CandidatoInputModel>> GerarRelatorioPontuacao();
}
